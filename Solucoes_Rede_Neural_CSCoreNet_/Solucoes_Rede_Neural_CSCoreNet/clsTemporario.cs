using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;

namespace Solucoes_Rede_Neural_CSCoreNet
{
    public class clsArquivoTXT : object
    {
        // Variável de classe 
        private static int numInstanciasCriadas = 0;

        // Variáveis de Instância 
        private string strEnderecoArquivo;
        private string strTexto;

        // Implementação dos Métodos. 
        // Método Construtor sem argumentos. 
        public clsArquivoTXT()
        {
            numInstanciasCriadas += 1;
        }
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        public string getEnderecoArquivo
        {
            get
            {
                if (!(strEnderecoArquivo == string.Empty))
                {
                    return strEnderecoArquivo;
                }
                else
                {
                    return "Digite um endereço e um nome de arquivo válidos.";
                }
            }
        }
        public string setEnderecoArquivo
        {
            set { strEnderecoArquivo = value; }
        }
        public string getTexto
        {
            get
            {
                if (!(strTexto == string.Empty))
                {
                    return strTexto;
                }
                else
                {
                    return "Não há conteúdo.";
                }
            }
        }
        public string setTexto
        {
            set { strTexto = value; }
        }
        public bool mtdCriadorTexto()
        {
            StreamWriter stwEscritorTexto = File.CreateText(getEnderecoArquivo);
            stwEscritorTexto.WriteLine(getTexto);
            stwEscritorTexto.Close();
            return true;
        }
        public bool mtdCriadorTexto(string Texto)
        {
            setTexto = Texto;
            return mtdCriadorTexto();
        }
        public bool mtdCriadorTexto(string EnderecoArquivo, string Texto)
        {
            setEnderecoArquivo = EnderecoArquivo;
            setTexto = Texto;
            return mtdCriadorTexto();
        }
        public bool mtdAcrescentarTexto()
        {
            string TextoTemporario = string.Empty;
            try
            {
                StreamReader stdLeitorTexto = File.OpenText(getEnderecoArquivo);
                TextoTemporario = stdLeitorTexto.ReadToEnd();
                stdLeitorTexto.Close();
            }
            catch
            {
            }
            finally
            {

                StreamWriter stwEscritorTexto = File.CreateText(getEnderecoArquivo);
                stwEscritorTexto.Write(TextoTemporario + getTexto);
                stwEscritorTexto.Close();
            }
            return true;
        }
        public bool mtdAcrescentarTexto(string Texto)
        {
            setTexto = Texto;
            return mtdAcrescentarTexto();
        }
        public bool mtdAcrescentarTexto(string EnderecoArquivo, string Texto)
        {
            setEnderecoArquivo = EnderecoArquivo;
            setTexto = Texto;
            return mtdAcrescentarTexto();
        }
        public string mtdLeitorTexto()
        {
            StreamReader stdLeitorTexto = File.OpenText(getEnderecoArquivo);
            setTexto = stdLeitorTexto.ReadToEnd();
            stdLeitorTexto.Close();
            return getTexto;
        }
        public string mtdLeitorTexto(string EnderecoArquivo)
        {
            setEnderecoArquivo = EnderecoArquivo;
            return mtdLeitorTexto();
        }
        public bool mtdEscritorBinario()
        {
            BinaryWriter EscritorBinario = new BinaryWriter(File.OpenWrite(getEnderecoArquivo));
            EscritorBinario.Write(getTexto);
            EscritorBinario.Close();
            return true;
        }
        public bool mtdEscritorBinario(string Texto)
        {
            setTexto = Texto;
            return mtdEscritorBinario();
        }
        public bool mtdEscritorBinario(string EnderecoArquivo, string Texto)
        {
            setEnderecoArquivo = EnderecoArquivo;
            setTexto = Texto;
            return true;
        }
        public string mtdLeitorBinario()
        {
            BinaryReader bnrLeitorBinario = new BinaryReader(File.OpenRead(getEnderecoArquivo));
            setTexto = bnrLeitorBinario.ReadString();
            bnrLeitorBinario.Close();
            return getTexto;
        }
        public string mtdLeitorBinario(string EnderecoArquivo)
        {
            setEnderecoArquivo = EnderecoArquivo;
            return mtdLeitorBinario();
        }
        ~clsArquivoTXT()
        {
            // Método Finalizador 
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }

    public class clsManipuladorTexto
    {
        // Variável de classe 
        private static int numInstanciasCriadas = 0;
        // Variáveis de Instância 
        private int intKey;
        private char chrKeyChar;
        private string strTextoOriginal;
        private string strTextoSemEspacoExtra;
        private string strTextoSemCaractereInvalido;
        private string strSemAcentos;
        private string strTudoExecutado;
        // Método construtor sem parâmetros. 
        public clsManipuladorTexto()
        {
            numInstanciasCriadas += 1;
        }
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        public int getKey
        {
            get { return intKey; }
        }
        public int setKey
        {
            set
            {
                chrKeyChar = Convert.ToChar(value);
                intKey = value;
            }
        }
        public char getKeyChar
        {
            get { return chrKeyChar; }
        }
        public char setKeyChar
        {
            set
            {
                intKey = Convert.ToInt32(value);
                chrKeyChar = value;
            }
        }
        public string getTextoOriginal
        {
            get { return strTextoOriginal; }
        }
        public string setTextoOriginal
        {
            set { strTextoOriginal = value; }
        }
        public string getTextoSemEspacoExtra
        {
            get { return strTextoSemEspacoExtra; }
        }
        public string setTextoSemEspacoExtra
        {
            set { strTextoSemEspacoExtra = value; }
        }
        public string getTextoSemCaractereInvalido
        {
            get { return strTextoSemCaractereInvalido; }
        }
        public string setTextoSemCaractereInvalido
        {
            set { strTextoSemCaractereInvalido = value; }
        }
        public string getTextoMaiusculo
        {
            get { return strTextoSemCaractereInvalido; }
        }
        public string setTextoMaiusculo
        {
            set { strTextoSemCaractereInvalido = value; }
        }
        public string getTextoMinusculo
        {
            get { return strTextoSemCaractereInvalido; }
        }
        public string setTextoMinusculo
        {
            set { strTextoSemCaractereInvalido = value; }
        }
        public string getSemAcentos
        {
            get { return strSemAcentos; }
        }
        public string setSemAcentos
        {
            set { strSemAcentos = value; }
        }
        public string getTudoExecutado
        {
            get { return strTudoExecutado; }
        }
        public string setTudoExecutado
        {
            set { strTudoExecutado = value; }
        }
        public string mtdTiradorEspacoExtra()
        {
            bool Verificador = false;
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            if (Index == 0)
            {
                for (int i = 0; i <= getTextoOriginal.Length - 1; i++)
                {
                    chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1));
                    Index = Convert.ToInt32(chrCarac);
                    switch (Index)
                    {
                        case 32:
                            if (Verificador == false)
                            {
                                strTextoTemporario += chrCarac;
                                Verificador = true;
                            }

                            break;
                        default:
                            strTextoTemporario += chrCarac;
                            Verificador = false;
                            break;
                    }
                }
            }
            setTextoSemEspacoExtra = strTextoTemporario.Trim();
            return getTextoSemEspacoExtra;
        }
        public string mtdTiradorEspacoExtra(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdTiradorEspacoExtra();
        }
        public string mtdTiradorCaractereInvalido()
        {
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= getTextoOriginal.Length - 1; i++)
            {
                chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1));
                Index = Convert.ToInt32(chrCarac);
                if (!(Index == 34 | Index == 39 | Index == 45 | Index == 47))
                {
                    strTextoTemporario += chrCarac;
                }
            }
            setTextoSemCaractereInvalido = strTextoTemporario.Trim();
            return getTextoSemCaractereInvalido;
        }
        public string mtdTiradorCaractereInvalido(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdTiradorCaractereInvalido();
        }
        // Essa função devolve os caracteres digatados do texto em maiúsculo. 
        public string mtdMaiusculo()
        {
            setTextoMaiusculo = getTextoOriginal.ToUpper();
            return getTextoMaiusculo;
        }
        public string mtdMaiusculo(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdMaiusculo();
        }
        // Essa função devolve os caracteres digatados do texto em minúsculo. 
        public string mtdMinusculo()
        {
            setTextoMinusculo = getTextoOriginal.ToLower();
            return getTextoMinusculo;
        }
        public string mtdMinusculo(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdMinusculo();
        }
        // Essa função retira todos os acentos gráficos atinentes aos caracteres digitados. 
        public string mtdTiradorAcentos()
        {
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= getTextoOriginal.Length - 1; i++)
            {
                chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1));
                Index = Convert.ToInt32(chrCarac);
                switch (Index)
                {
                    case 192:
                    case 193:
                    case 194:
                    case 195:
                    case 196:
                    case 197:
                    case 198:
                        strTextoTemporario += "A";
                        break;
                    case 199:
                        strTextoTemporario += "C";
                        break;
                    case 200:
                    case 201:
                    case 202:
                    case 203:
                        strTextoTemporario += "E";
                        break;
                    case 204:
                    case 205:
                    case 206:
                    case 207:
                        strTextoTemporario += "I";
                        break;
                    case 210:
                    case 211:
                    case 212:
                    case 213:
                    case 214:
                        strTextoTemporario += "O";
                        break;
                    case 217:
                    case 218:
                    case 219:
                    case 220:
                        strTextoTemporario += "U";
                        break;
                    case 224:
                    case 225:
                    case 226:
                    case 227:
                    case 228:
                    case 229:
                        strTextoTemporario += "a";
                        break;
                    case 231:
                        strTextoTemporario += "c";
                        break;
                    case 232:
                    case 233:
                    case 234:
                    case 235:
                        strTextoTemporario += "e";
                        break;
                    case 236:
                    case 237:
                    case 238:
                    case 239:
                        strTextoTemporario += "i";
                        break;
                    case 242:
                    case 243:
                    case 244:
                    case 245:
                    case 246:
                        strTextoTemporario += "o";
                        break;
                    case 249:
                    case 250:
                    case 251:
                    case 252:
                        strTextoTemporario += "u";
                        break;
                    default:
                        strTextoTemporario += chrCarac;
                        break;
                }
            }
            setSemAcentos = strTextoTemporario;
            return getSemAcentos;
        }
        public string mtdTiradorAcentos(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdTiradorAcentos();
        }
        // Essa função realiza todas as tarefas das funções anteriores, tornando todo o texto maiúsculo. 
        public string mtdExecutarTudo()
        {
            setTudoExecutado = mtdMaiusculo(mtdTiradorAcentos(mtdTiradorCaractereInvalido(mtdTiradorEspacoExtra(getTextoOriginal))));
            return getTudoExecutado;
        }
        public string mtdExecutarTudo(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdExecutarTudo();
        }
        // Essa função obriga somente digitar textos com números 
        public bool mtdPermitirDigitarSoNumero()
        {
            // Verifica se um caracter é permitido. 
            // Selecione os caracteres que desejar. 
            // Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente. 
            string Numeros = "0123456789" + Convert.ToChar(3) + Convert.ToChar(8) + Convert.ToChar(22) + Convert.ToChar(24);
            return !Numeros.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoNumero(int Key)
        {
            // Verifica se um caracter é permitido. 
            setKey = Key;
            return mtdPermitirDigitarSoNumero();
        }
        public bool mtdPermitirDigitarSoNumero(char KeyChar)
        {
            // Verifica se um caracter é permitido. 
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoNumero();
        }
        // Essa função obriga somente digitar textos com caracteres sem acentos gráficos 
        public bool mtdPermitirDigitarSoTexto()
        {
            // Verifica se um caracter é permitido. 
            // Selecione os caracteres que desejar. 
            // Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente. 
            string Texto = " ,.-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + Convert.ToChar(3) + Convert.ToChar(8) + Convert.ToChar(22) + Convert.ToChar(24);
            return !Texto.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoTexto(int Key)
        {
            // Verifica se um caracter é permitido. 
            setKey = Key;
            return mtdPermitirDigitarSoTexto();
        }
        public bool mtdPermitirDigitarSoTexto(char KeyChar)
        {
            // Verifica se um caracter é permitido. 
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoTexto();
        }
        // Essa função faz obriga somente digitar textos sem números 
        public bool mtdPermitirDigitarSoNome()
        {
            // Verifica se um caracter é permitido. 
            // Selecione os caracteres que desejar. 
            // Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente. 
            string Texto = " -abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + Convert.ToChar(3) + Convert.ToChar(8) + Convert.ToChar(22) + Convert.ToChar(24);
            return !Texto.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoNome(int Key)
        {
            // Verifica se um caracter é permitido. 
            setKey = Key;
            return mtdPermitirDigitarSoNome();
        }
        public bool mtdPermitirDigitarSoNome(char KeyChar)
        {
            //Verifica se um caracter é permitido. 
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoNome();
        }
        // Essa função faz obriga somente digitar textos que sejam atinentes a datas 
        public bool mtdPermitirDigitarSoData()
        {
            // Verifica se um caracter é permitido. 
            // Selecione os caracteres que desejar. 
            // Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente. 
            string Numeros = " -abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + Convert.ToChar(3) + Convert.ToChar(8) + Convert.ToChar(22) + Convert.ToChar(24);
            return !Numeros.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoData(int Key)
        {
            //Verifica se um caracter é permitido. 
            setKey = Key;
            return mtdPermitirDigitarSoData();
        }
        public bool mtdPermitirDigitarSoData(char KeyChar)
        {
            //Verifica se um caracter é permitido. 
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoData();
        }
        ~clsManipuladorTexto()
        {
            // Método Finalizador. 
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }

    // Classe que gera um temporizador simples de ser usado, e razoavelmente preciso. 
    public class clsTemporizador
    {
        // Como pode ser percebido abaixo, essa classe é inerente ao kernel32.dll, portanto, tendo sua portabilidade comprometida. 
        // Variável de classe 
        private static int numInstanciasCriadas = 0;
        // Variável de instância 
        private double intervalo = 0;
        private double tempo = 0;
        private double tempoMax = 0;
        private long contadorInicial = 0;
        private long contador = 0;
        private long difcontador = 0;
        private long frequencia = long.MaxValue;
        // Número máximo que um inteiro longo sinalizado positivo pode suportar (((2^64)/2)-1). 
        private double numLoops = 0;
        private string mensagemErro = "Não houve erros.";
        // Métodos estáticos - Static (CS.Net) ou compartilhados - Shared (VB.Net) 
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern bool QueryPerformanceCounter(ref long lpPerformanceCount);
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern bool QueryPerformanceFrequency(ref long lpFrequency);
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        // Propriedades que resgatam o valor das variáveis de instância. 
        public double getintervalo
        {
            get { return intervalo; }
        }
        public double gettempo
        {
            get { return tempo; }
        }
        public double prptempoMax
        {
            get { return tempoMax; }
            set
            {
                if ((value > 0))
                {
                    tempoMax = value;
                }
                else
                {
                    tempoMax = 1;
                    mensagemErro = "Ajuste o valor da variável tempoMax para que seja maior do que zero, " + "caso contrário será atribuído o tempo de um segundo a ela.";
                }
            }
        }
        public double getcontadorInicial
        {
            get { return contadorInicial; }
        }
        public double getcontador
        {
            get { return contador; }
        }
        public double getdifcontador
        {
            get { return difcontador; }
        }
        public double getfrequencia
        {
            get { return intervalo; }
        }
        public double getnumLoops
        {
            get { return numLoops; }
        }
        public string getmensagemErro
        {
            get { return mensagemErro; }
        }
        // Métodos que para serem usados, a classe deverá ser instanciada em um objeto. 
        // Métodos construtores sobrecarregados. 
        public clsTemporizador()
        {
            numInstanciasCriadas += 1;
        }
        public clsTemporizador(double tempoMax)
        {
            prptempoMax = tempoMax;
            numInstanciasCriadas += 1;
        }
        // Métodos convencionais. 
        public string mtdInformacao()
        {
            return "O tempo é dado em segundos, e a frequência de operação é dada em hertz.";
        }
        public bool mtdTemporizador()
        {
            bool erro = false;
            tempo = Convert.ToDouble((contador - contadorInicial) / frequencia);
            if (QueryPerformanceCounter(ref contadorInicial) != false)
            {
                // Início do código temporizador. 
                while ((tempo < tempoMax))
                {
                    QueryPerformanceCounter(ref contador);
                    QueryPerformanceFrequency(ref frequencia);
                    intervalo = Convert.ToDouble(1.0 / frequencia);
                    tempo = (contador - contadorInicial) * intervalo;
                }
                mensagemErro = "Não houve erros.";
                erro = true;
            }
            else
            {
                mensagemErro = "Resolução acima do suportado.";
                erro = false;
            }
            return erro;
        }
        public bool mtdTemporizador(double tempoMax)
        {
            prptempoMax = tempoMax;
            return mtdTemporizador();
        }
        public long mtdIniciarContador()
        {
            contadorInicial = 0;
            if ((QueryPerformanceCounter(ref contadorInicial) == false))
            {
                mensagemErro = "Resolução acima do suportado.";
            }
            return contadorInicial;
        }
        public double mtdPassoTempo()
        {
            if ((contadorInicial == -1))
            {
                contadorInicial = mtdIniciarContador();
            }
            tempo = Convert.ToDouble((contador - contadorInicial) / frequencia);
            if ((QueryPerformanceCounter(ref contador) != false))
            {
                // Início do código temporizador. 
                QueryPerformanceCounter(ref contador);
                QueryPerformanceFrequency(ref frequencia);
                intervalo = Convert.ToDouble(1.0 / frequencia);
                tempo = (contador - contadorInicial) * intervalo;
            }
            else
            {
                mensagemErro = "Resolução acima do suportado.";
            }
            return tempo;
        }
        public double mtdPassoTempo(double tempoMax)
        {
            prptempoMax = tempoMax;
            return mtdPassoTempo();
        }
        public override string ToString()
        {
            string saida = "Contador Inicial: " + contadorInicial + "; Contador: " + contador + ";" + "\n" + "Tempo: " + tempo + " (s); Tempo Limite: " + tempoMax + " (s); Frequência: " + frequencia + " (Hz);" + "\\n" + "Intervalo: " + intervalo + " (Hz); Diferença entre os contadores: " + difcontador + ";" + "\n" + "Números de Loops: " + numLoops + "; Número de Instâncias Criadas: " + numInstanciasCriadas + ";" + "\\n" + "Mensagem de Erro: " + mensagemErro;
            return saida;
        }
        ~clsTemporizador()
        {
            // Método finalizador. 
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }

    public class clsEnderecoAplicativo
    {
        // Variável de classe 
        private static int numInstanciasCriadas = 0;
        // Método construtor sem parâmetros da classe, construção essa comum em Java 
        public clsEnderecoAplicativo()
        {
            numInstanciasCriadas += 1;
            Endereco();
        }
        // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe. 
        public static int getnumInstanciasCriadas
        {
            get { return numInstanciasCriadas; }
        }
        public string Endereco()
        {
            string varEnderecoAplicativo = string.Empty;
            char chrCaractere = '\0';
            int countBI = 0;
            int countmaxBI = 0;
            for (int i = 0; i <= Assembly.GetExecutingAssembly().Location.Length - 1; i++)
            {
                chrCaractere = Convert.ToChar(Assembly.GetExecutingAssembly().Location.Substring(i, 1));
                if (chrCaractere == '\\')
                {
                    countmaxBI += 1;
                }
            }
            for (int i = 0; i <= Assembly.GetExecutingAssembly().Location.Length - 1; i++)
            {
                chrCaractere = Convert.ToChar(Assembly.GetExecutingAssembly().Location.Substring(i, 1));
                varEnderecoAplicativo += chrCaractere;
                if (chrCaractere == '\\')
                {
                    if (countmaxBI - 1 == countBI)
                    {
                        break; // TODO: might not be correct. Was : Exit For 
                    }
                    countBI += 1;
                }
            }
            return varEnderecoAplicativo;
        }
        ~clsEnderecoAplicativo()
        {
            numInstanciasCriadas -= 1;
            System.GC.Collect(0);
        }
    }
}
