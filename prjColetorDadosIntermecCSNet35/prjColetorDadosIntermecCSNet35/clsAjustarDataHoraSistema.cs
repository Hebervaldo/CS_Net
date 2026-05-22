using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace prjColetorDadosIntermecCSNet35
{
    class clsAjustarDataHoraSistema
    {
        //necessário privilégio administrador
        [System.Runtime.InteropServices.DllImport("coredll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SystemTime sysTime);

        [System.Runtime.InteropServices.DllImport("coredll", EntryPoint = "GetSystemTime", SetLastError = true)]
        public extern static void Win32GetSystemTime(ref SystemTime sysTime);

        public struct SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Millisecond;
        }

        public bool mtdAjustarDataHoraSistema()
        {
            return mtdObterServidorNTPAjustarDataHora();
        }

        private bool mtdObterServidorNTPAjustarDataHora()
        {
            //servidor intranet "user-PC" (local)
            //a.ntp.br (internet) 
            //var localDateTime = PegarDtHoraRedeLocal("user-PC");
            var horaAtual = mtdObterDataHoraAtualizada("a.ntp.br");

            //AJUSTA HORA BASEADO NO FUSO HORARIO DO COMPUTADOR LOCAL
            return mtdAjustarDataHora(horaAtual.ToLocalTime());
        }

        private DateTime mtdObterDataHoraAtualizada(string ntpServer)
        {
            var ntpData = new byte[48];
            ntpData[0] = 0x1B; //LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)

            //somente IPV4
            var addresses = System.Net.Dns.GetHostEntry(ntpServer).AddressList.First(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            var ipEndPoint = new System.Net.IPEndPoint(addresses, 123);
            var socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);

            // socket.ReceiveTimeout = 5000; //5 segundos timeout
            socket.Connect(ipEndPoint);
            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | ntpData[43];
            ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | ntpData[47];

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds).ToLocalTime();

            //ajustando para hora brasil teste ajuste independente do fuso horario
            //networkDateTime = DateTime.ParseExact(networkDateTime.ToString(), "dd/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            return networkDateTime;
        }

        private bool mtdAjustarDataHora(DateTime dataHoraAtualizada)
        {
            // Prepare native method with the defined structure.
            var st = new SystemTime
            {
                Year = (ushort)(dataHoraAtualizada.Year),
                Month = (ushort)(dataHoraAtualizada.Month),
                Hour = (ushort)(dataHoraAtualizada.Hour),
                Day = (ushort)(dataHoraAtualizada.Day),
                Minute = (ushort)(dataHoraAtualizada.Minute),
                Second = (ushort)(dataHoraAtualizada.Second)
            };

            // Set the system date time.
            var resp = Win32SetSystemTime(ref st);

            return resp;
        }
    }
}
