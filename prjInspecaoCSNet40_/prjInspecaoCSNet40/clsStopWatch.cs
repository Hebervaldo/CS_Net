using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjInspecaoCSNet40
{
    class clsStopWatch
    {
        private bool blnExecutando = false;
        private bool blnReset = false;
        private long lngDiferencaTempo = 0;
        private long lngDiferencaTempoAcumulado = 0;

        private System.DateTime dtTempoInicio = new System.DateTime();
        private System.DateTime dtTempoIntermediario = new System.DateTime();

        public clsStopWatch()
        {
            mtdReset();
        }

        ~clsStopWatch()
        {
        }

        public void mtdReset()
        {
            blnExecutando = false;
            lngDiferencaTempoAcumulado = 0;
            dtTempoInicio = System.DateTime.Now;
            dtTempoIntermediario = dtTempoInicio;
            blnReset = true;
        }

        public void mtdStart()
        {
            if (!blnExecutando)
            {
                blnExecutando = true;
                blnReset = false;
                dtTempoInicio = System.DateTime.Now;
                dtTempoIntermediario = dtTempoInicio;
            }
        }

        public void mtdStop()
        {
            if (blnExecutando)
            {
                mtdObterTempoMilisegundos();
                blnExecutando = false;
                lngDiferencaTempoAcumulado = lngDiferencaTempoAcumulado + MillisecondsBetween(dtTempoIntermediario, dtTempoInicio);
            }
        }

        // Uses DateTimeToTimeStamp, TimeStampToMilliseconds, and DateTimeToMilliseconds.
        public long MillisecondsBetween(System.DateTime anow, System.DateTime athen)
        {
            long Result = 0;

            if (anow > athen)
            {
                Result = (long)(anow.TimeOfDay.TotalMilliseconds - athen.TimeOfDay.TotalMilliseconds);
            }
            else
            {
                Result = (long)(athen.TimeOfDay.TotalMilliseconds - anow.TimeOfDay.TotalMilliseconds);
            }

            return Result;
        }

        public long mtdObterTempoMilisegundos()
        {
            long Result = 0;

            if (blnExecutando | blnReset)
            {
                if (!blnReset)
                {
                    dtTempoIntermediario = System.DateTime.Now;
                }

                lngDiferencaTempo = lngDiferencaTempoAcumulado + MillisecondsBetween(dtTempoIntermediario, dtTempoInicio);
                blnReset = false;
            }

            Result = lngDiferencaTempo;

            return Result;
        }

        public string mtdObterTempoMilisegundosString()
        {
            string Result = string.Empty;

            Result = System.String.Format("Tempo transcorrido: {0} (ms).", System.Convert.ToString(mtdObterTempoMilisegundos()));

            return Result;
        }

        public long mtdObterTempoSegundos()
        {
            long Result = 0;

            Result = System.Convert.ToInt64(System.Convert.ToDecimal(mtdObterTempoMilisegundos() / 1000));

            return Result;
        }

        public string mtdObterTempoSegundosString()
        {
            string Result = string.Empty;

            Result = System.String.Format("Tempo transcorrido: {0} (s).", System.Convert.ToString(mtdObterTempoSegundos()));

            return Result;
        }
    }
}
