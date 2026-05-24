namespace WebServiceInspecaoCSNet40
{
    #region "RegistroWindows"
    public class clsRegistroWindows
    {
        // Variáveis de Instância.
        private bool erro = false;
        private Microsoft.Win32.RegistryValueKind TipoValor = Microsoft.Win32.RegistryValueKind.String;
        private object ChavePrincipal;
        private object Secao;
        private object Chave;
        private object Valor;
        private object Dados;
        // Variáveis encapsuladas
        private string mensagem = string.Empty;
        private string mensagemExcecao = string.Empty;
        private Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser;
        private Microsoft.Win32.RegistryKey SubRegistro = Microsoft.Win32.Registry.CurrentUser;
        // Método construtor sem parâmetros.
        public clsRegistroWindows()
        {
        }
        // Métodos construtores com parâmetros.
        public clsRegistroWindows(object Chave)
        {
            setChave = Chave;
        }
        public clsRegistroWindows(object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
        }
        public clsRegistroWindows(object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
        }
        public clsRegistroWindows(object Chave, object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
        }
        public clsRegistroWindows(object Chave, object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
        }
        public clsRegistroWindows(object Secao, object Chave, object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
        }
        public clsRegistroWindows(object Secao, object Chave, object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
        }
        public clsRegistroWindows(object ChavePrincipal, object Secao, object Chave, object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            setChavePrincipal = ChavePrincipal;
        }
        public clsRegistroWindows(object ChavePrincipal, object Secao, object Chave, object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            setChavePrincipal = ChavePrincipal;
        }
        public clsRegistroWindows(Microsoft.Win32.RegistryKey SubRegistro, object ChavePrincipal, object Secao, object Chave, object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            setChavePrincipal = ChavePrincipal;
            setSubRegistro = SubRegistro;
        }
        public clsRegistroWindows(Microsoft.Win32.RegistryKey SubRegistro, object ChavePrincipal, object Secao, object Chave, object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            setChavePrincipal = ChavePrincipal;
            setSubRegistro = SubRegistro;
        }

        // Propriedade que resgata o conteúdo da variável de instância SubRegistro.
        public Microsoft.Win32.RegistryKey getSubRegistro
        {
            get { return SubRegistro; }
        }
        // Propriedade que define o conteúdo da variável de instância SubRegistro.
        public Microsoft.Win32.RegistryKey setSubRegistro
        {
            set { SubRegistro = value; }
        }
        // Propriedade que resgata o conteúdo da variável de instância ChavePrincipal.
        public object getChavePrincipal
        {
            get
            {
                if ((System.Convert.ToString(ChavePrincipal) != string.Empty))
                {
                    mensagem = "Não ocorreu problemas.";
                }
                else
                {
                    mensagem = "Não há conteúdo na variável ChavePrincipal.";
                }
                return ChavePrincipal;
            }
        }
        // Propriedade que define o conteúdo da variável de instância ChavePrincipal.
        public object setChavePrincipal
        {
            set { ChavePrincipal = value; }
        }
        // Propriedade que resgata o conteúdo da variável de instância Secao.
        public object getSecao
        {
            get
            {
                if ((System.Convert.ToString(Secao) != string.Empty))
                {
                    mensagem = "Não ocorreu problemas.";
                }
                else
                {
                    mensagem = "Não há conteúdo na variável Secao.";
                }
                return Secao;
            }
        }
        // Propriedade que define o conteúdo da variável de instância Secao.
        public object setSecao
        {
            set { Secao = value; }
        }
        // Propriedade que resgata o conteúdo da variável de instância Chave. 
        public object getChave
        {
            get
            {
                if ((System.Convert.ToString(Chave) != string.Empty))
                {
                    mensagem = "Não ocorreu problemas.";
                }
                else
                {
                    mensagem = "Não há conteúdo na variável Chave.";
                }
                return Chave;
            }
        }
        // Propriedade que define o conteúdo da variável de instância Chave. 
        public object setChave
        {
            set { Chave = value; }
        }
        // Propriedade que resgata o conteúdo da variável de instância Valor. 
        public object getValor
        {
            get
            {
                if ((System.Convert.ToString(Valor) != string.Empty))
                {
                    mensagem = "Não ocorreu problemas.";
                }
                else
                {
                    mensagem = "Não há conteúdo na variável Valor.";
                }
                return Valor;
            }
        }
        // Propriedade que define o conteúdo da variável de instância Valor. 
        public object setValor
        {
            set { Valor = value; }
        }
        // Propriedade que resgata o conteúdo da variável de instância Secao. 
        public object getDados
        {
            get
            {
                if (!(System.Convert.ToString(Dados) != string.Empty))
                {
                    mensagem = "Não ocorreu problemas.";
                }
                else
                {
                    mensagem = "Não há conteúdo na variável Dados.";
                }
                return Dados;
            }
        }
        // Propriedade que define o conteúdo da variável de instância Secao. 
        public object setDados
        {
            set { Dados = value; }
        }
        // Propriedade que resgata o conteúdo da variável de instância TipoValor. 
        public Microsoft.Win32.RegistryValueKind getTipoValor
        {
            get { return TipoValor; }
        }
        // Propriedade que define o conteúdo da variável de instância TipoValor. 
        public Microsoft.Win32.RegistryValueKind setTipoValor
        {
            set { TipoValor = value; }
        }
        // Propriedade que resgata o conteúdo da variável de instância mensagem. 
        public string getmensagem
        {
            get
            {
                if ((mensagem != string.Empty))
                {
                    return mensagem;
                }
                else
                {
                    return "Não há conteúdo na variável mensagem.";
                }
            }
        }
        // Propriedade que define o conteúdo da variável de instância mensagem. 
        private string setmensagem
        {
            set { mensagem = value; }
        }
        // Propriedade que resgata o conteúdo da variável de instância mensagemExcecao. 
        public string getmensagemExcecao
        {
            get
            {
                if ((mensagemExcecao != string.Empty))
                {
                    return mensagemExcecao;
                }
                else
                {
                    return "Não há conteúdo na variável mensagemExcecao.";
                }
            }
        }
        // Propriedade que define o conteúdo da variável de instância mensagemExcecao. 
        private string setmensagemExcecao
        {
            set { mensagemExcecao = value; }
        }
        // Método sobrecarregado que salva os Dados no registro do Windows. 
        public bool mtdSalvarDadosRegistro()
        {
            try
            {
                regKey = getSubRegistro;
                // Cria uma referêcnia para a Valor de registro na variável getSecao.
                regKey = regKey.CreateSubKey(System.Convert.ToString(getChavePrincipal));
                regKey = regKey.CreateSubKey(System.Convert.ToString(getSecao));
                // Cria uma SubValor com o nome na variável getChave.
                regKey = regKey.CreateSubKey(System.Convert.ToString(getChave));
                // Grava o caminho na SubValor GravaRegistro.
                switch (getTipoValor)
                {
                    case Microsoft.Win32.RegistryValueKind.MultiString:
                        bool blnExisteParagrafo = false;
                        int numeroParagrafo = 0;
                        for (int contador = 0; contador <= getDados.ToString().Length - 1; contador += 1)
                        {
                            char chrCaractere = System.Convert.ToChar(getDados.ToString().Substring(contador, 1));
                            int intNumero = System.Convert.ToInt32(chrCaractere);
                            if ((intNumero == 13))
                            {
                                if ((!(intNumero == 10)))
                                {
                                    numeroParagrafo += 1;
                                }
                            }
                        }

                        string[] vetDados = new string[numeroParagrafo + 1];
                        numeroParagrafo = 0;
                        for (int contador = 0; contador <= getDados.ToString().Length - 1; contador += 1)
                        {
                            char chrCaractere = System.Convert.ToChar(getDados.ToString().Substring(contador, 1));
                            int intNumero = System.Convert.ToInt32(chrCaractere);
                            if ((!(intNumero == 13)))
                            {
                                if ((!(intNumero == 10)))
                                {
                                    if (blnExisteParagrafo == true)
                                    {
                                        numeroParagrafo += 1;
                                        blnExisteParagrafo = false;
                                    }
                                    vetDados[numeroParagrafo] += chrCaractere;
                                }
                            }
                            else
                            {
                                if ((vetDados[numeroParagrafo] != null))
                                {
                                    vetDados[numeroParagrafo] = vetDados[numeroParagrafo].ToString();
                                    blnExisteParagrafo = true;
                                }
                            }
                        }

                        string[] stringDados = new string[numeroParagrafo + 1];
                        System.Array.Copy(vetDados, stringDados, numeroParagrafo + 1);
                        regKey.SetValue(System.Convert.ToString(getValor), stringDados, getTipoValor);
                        break;
                    case Microsoft.Win32.RegistryValueKind.Binary:
                        byte[] byteDados = new byte[getDados.ToString().Length + 1];
                        for (int contador = 0; contador <= getDados.ToString().Length - 1; contador += 1)
                        {
                            byteDados[contador] = System.Convert.ToByte(System.Convert.ToInt64(getDados.ToString().Substring(contador, 1)));
                        }

                        regKey.SetValue(System.Convert.ToString(getValor), byteDados, getTipoValor);
                        break;
                    default:
                        regKey.SetValue(System.Convert.ToString(getValor), getDados, getTipoValor);
                        break;
                }
                // Fecha a Valor de Registro.
                erro = true;
                mensagem = "Os Dados foram salvos no registro.";
            }
            catch (System.Exception ex)
            {
                mensagem = "Os Dados não foram salvos no registro";
                mensagemExcecao = ex.Message;

                string strExcecao = "mtdSalvarDadosRegistro: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                erro = false;
            }
            return erro;
        }
        // Métodos que salvam os Dados no registro do Windows de acordo com os parâmetros fornecidos.
        public bool mtdSalvarDadosRegistro(object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(object Chave, object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(object Chave, object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(object Secao, object Chave, object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(object Secao, object Chave, object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(object ChavePrincipal, object Secao, object Chave, object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            setChavePrincipal = ChavePrincipal;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(object ChavePrincipal, object Secao, object Chave, object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            setChavePrincipal = ChavePrincipal;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(Microsoft.Win32.RegistryKey SubRegistro, object ChavePrincipal, object Secao, object Chave, object Valor, object Dados)
        {
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            setChavePrincipal = ChavePrincipal;
            setSubRegistro = SubRegistro;
            return mtdSalvarDadosRegistro();
        }
        public bool mtdSalvarDadosRegistro(Microsoft.Win32.RegistryKey SubRegistro, object ChavePrincipal, object Secao, object Chave, object Valor, object Dados, Microsoft.Win32.RegistryValueKind TipoValor)
        {
            setTipoValor = TipoValor;
            setDados = Dados;
            setValor = Valor;
            setChave = Chave;
            setSecao = Secao;
            setChavePrincipal = ChavePrincipal;
            setSubRegistro = SubRegistro;
            return mtdSalvarDadosRegistro();
        }
        // Método sobrecarregado que resgata os Dadoss no registro do Windows. 
        public object mtdObterDadosRegistro()
        {
            string saida = string.Empty;
            try
            {
                regKey = getSubRegistro;
                // Cria uma referência para a Valor de registro na variável 
                regKey = regKey.OpenSubKey(System.Convert.ToString(getChavePrincipal), true);
                regKey = regKey.OpenSubKey(System.Convert.ToString(getSecao), true);
                regKey = regKey.OpenSubKey(System.Convert.ToString(getChave), true);
                // realiza a leitura do registro
                saida = System.Convert.ToString(regKey.GetValue(System.Convert.ToString(getValor)));
                switch (saida)
                {
                    case "System.Byte[]":
                        object[] vet = new object[101];
                        saida = "Os dados proveem de um vetor do tipo byte, por isso não serão apresentados.";
                        break;
                    case "System.String[]":
                        saida = "Os dados proveem de um vetor do tipo string, por isso não serão apresentados.";
                        break;
                }
            }
            catch (System.Exception ex)
            {
                mensagem = "Não há Dados nos Valores a serem retornados ou não foi possível obtê-los.";
                mensagemExcecao = ex.Message;

                string strExcecao = "mtdObterDadosRegistro: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                erro = false;
            }
            return saida;
        }
        // Método sobrecarregado que resgatam os Dadoss no registro do Windows de acordo com os parâmetros fornecidos. 
        public object mtdObterDadosRegistro(object Valor)
        {
            setValor = Valor;
            return mtdObterDadosRegistro();
        }
        public object mtdObterDadosRegistro(object Chave, object Valor)
        {
            setChave = Chave;
            setValor = Valor;
            return mtdObterDadosRegistro();
        }
        public object mtdObterDadosRegistro(object Secao, object Chave, object Valor)
        {
            setSecao = Secao;
            setChave = Chave;
            setValor = Valor;
            return mtdObterDadosRegistro();
        }
        public object mtdObterDadosRegistro(object ChavePrincipal, object Secao, object Chave, object Valor)
        {
            setChavePrincipal = ChavePrincipal;
            setSecao = Secao;
            setChave = Chave;
            setValor = Valor;
            return mtdObterDadosRegistro();
        }
        public object mtdObterDadosRegistro(Microsoft.Win32.RegistryKey SubRegistro, object ChavePrincipal, object Secao, object Chave, object Valor)
        {
            setSubRegistro = SubRegistro;
            setChavePrincipal = ChavePrincipal;
            setSecao = Secao;
            setChave = Chave;
            setValor = Valor;
            return mtdObterDadosRegistro();
        }
        // Método sobrecarregado que deleta o Nome de Aplicativo conjuntamente com o seu conteúdo. 
        public bool mtdDeletarDadosRegistro()
        {
            try
            {
                regKey = getSubRegistro;
                regKey = regKey.OpenSubKey(System.Convert.ToString(getChavePrincipal), true);
                regKey = regKey.OpenSubKey(System.Convert.ToString(getSecao), true);
                regKey = regKey.OpenSubKey(System.Convert.ToString(getChave), true);
                regKey.DeleteValue(System.Convert.ToString(getValor));
                erro = true;
                mensagem = "O Dado foi deletado.";
            }
            catch (System.Exception ex)
            {
                mensagem = "Não há Dados nos Valores a serem retornados ou não foi possível deletá-los.";
                mensagemExcecao = ex.Message;

                string strExcecao = "mtdDeletarDadosRegistro: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

                erro = false;
            }
            return erro;
        }
        // Método sobrecarregado que deleta a Seção conjuntamente com a suas Valors 
        // dentro de um Nome de Aplicativo. 
        public object mtdDeletarDadosRegistro(object Valor)
        {
            setValor = Valor;
            return mtdDeletarDadosRegistro();
        }
        // Método sobrecarregado que deleta a Valor dentro da Seção.
        public bool mtdDeletarDadosRegistro(object Chave, object Valor)
        {
            setChave = Chave;
            setValor = Valor;
            return mtdDeletarDadosRegistro();
        }
        // Método sobrecarregado que deleta a Valor dentro da Seção que está contida no Nome de Aplicativo. 
        public bool mtdDeletarDadosRegistro(object Secao, object Chave, object Valor)
        {
            setSecao = Secao;
            setChave = Chave;
            setValor = Valor;
            return mtdDeletarDadosRegistro();
        }
        // Método sobrecarregado que deleta a Valor dentro da Seção que está contida no Nome de Aplicativo, detro do Tipo de Registro. 
        public bool mtdDeletarDadosRegistro(object ChavePrincipal, object Secao, object Chave, object Valor)
        {
            setChavePrincipal = ChavePrincipal;
            setSecao = Secao;
            setChave = Chave;
            setValor = Valor;
            return mtdDeletarDadosRegistro();
        }
        // Método sobrecarregado que deleta a Valor dentro da Seção que está contida no Nome de Aplicativo, detro do Tipo de Registro. 
        public bool mtdDeletarDadosRegistro(Microsoft.Win32.RegistryKey SubRegistro, object ChavePrincipal, object Secao, object Chave, object Valor)
        {
            setSubRegistro = SubRegistro;
            setChavePrincipal = ChavePrincipal;
            setSecao = Secao;
            setChave = Chave;
            setValor = Valor;
            return mtdDeletarDadosRegistro();
        }
        public bool mtdFimChaveRecursivo(string[] Chave)
        {
            bool retorno = false;
            regKey = Microsoft.Win32.Registry.CurrentUser;
            if (Chave.Length != 0)
            {
                for (int contador = 0; contador <= Chave.Length - 1; contador++)
                {
                    regKey = regKey.OpenSubKey(Chave[contador]);
                }
                if (regKey.GetSubKeyNames().Length == 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
                retorno = false;
            }
            return retorno;
        }

        ~clsRegistroWindows()
        {
            // Método Finalizador. 
            try
            {
                System.GC.Collect();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "~clsRegistroWindows: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }
        //regKey.Close()
    }
    #endregion

    #region "ManipuladorTexto"
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
                chrKeyChar = System.Convert.ToChar(value);
                intKey = value;
            }
        }
        public char getKeyChar
        {
            get
            {
                return chrKeyChar;
            }
        }
        public char setKeyChar
        {
            set
            {
                intKey = System.Convert.ToInt32(value);
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

        public string mtdRetirarEspacoExtra()
        {
            bool Verificador = false;
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= getTextoOriginal.Length - 1; i += 1)
            {
                chrCarac = System.Convert.ToChar(getTextoOriginal.Substring(i, 1));
                Index = System.Convert.ToInt32(chrCarac);
                switch (Index)
                {
                    case 32:
                        if (!Verificador)
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
            setTextoSemEspacoExtra = strTextoTemporario.Trim();
            return getTextoSemEspacoExtra;
        }
        public string mtdRetirarEspacoExtra(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdRetirarEspacoExtra();
        }
        public string mtdRetirarCaractereInvalido()
        {
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= getTextoOriginal.Length - 1; i++)
            {
                chrCarac = System.Convert.ToChar(getTextoOriginal.Substring(i, 1));
                Index = System.Convert.ToInt32(chrCarac);
                if (!(Index == 34 | Index == 39 | Index == (int)'-' | Index == (int)'/' | Index == (int)'.' | Index == (int)',' | Index == (int)'(' | Index == (int)')'))
                {
                    strTextoTemporario += chrCarac;
                }
                else
                {
                    strTextoTemporario += System.Convert.ToChar(32);
                }
            }
            setTextoSemCaractereInvalido = strTextoTemporario.Trim();
            return getTextoSemCaractereInvalido;
        }

        public string mtdRetirarCaractereInvalido(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdRetirarCaractereInvalido();
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
        public string mtdRetirarAcentos()
        {
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= getTextoOriginal.Length - 1; i++)
            {
                chrCarac = System.Convert.ToChar(getTextoOriginal.Substring(i, 1));
                Index = System.Convert.ToInt32(chrCarac);
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
        public string mtdRetirarAcentos(string Texto)
        {
            setTextoOriginal = Texto;
            return mtdRetirarAcentos();
        }
        // Essa função realiza todas as tarefas das funções anteriores, tornando todo o texto maiúsculo.
        public string mtdExecutarTudo()
        {
            setTudoExecutado = mtdMaiusculo(mtdRetirarAcentos(mtdRetirarEspacoExtra(mtdRetirarCaractereInvalido(getTextoOriginal))));
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
            //Selecione os caracteres que desejar.
            // Os valores ASC 3, 8, 22, 24 habilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente.
            string Numeros = "0123456789" + System.Convert.ToChar(3) + System.Convert.ToChar(8) + System.Convert.ToChar(22) + System.Convert.ToChar(24);
            return !Numeros.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoNumero(int Key)
        {
            //Verifica se um caracter é permitido.
            setKey = Key;
            return mtdPermitirDigitarSoNumero();
        }
        public bool mtdPermitirDigitarSoNumero(char KeyChar)
        {
            //Verifica se um caracter é permitido.
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoNumero();
        }
        // Essa função obriga somente digitar textos com caracteres sem acentos gráficos
        public bool mtdPermitirDigitarSoTexto()
        {
            //Selecione os caracteres que desejar.
            // Os valores ASC 3, 8, 22, 24 habilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente.
            string Texto = " ,.-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + System.Convert.ToChar(3) + System.Convert.ToChar(8) + System.Convert.ToChar(22) + System.Convert.ToChar(24);
            return !Texto.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoTexto(int Key)
        {
            //Verifica se um caracter é permitido.
            setKey = Key;
            return mtdPermitirDigitarSoTexto();
        }
        public bool mtdPermitirDigitarSoTexto(char KeyChar)
        {
            //Verifica se um caracter é permitido.
            setKeyChar = KeyChar;
            return mtdPermitirDigitarSoTexto();
        }
        // Essa função faz obriga somente digitar textos sem números
        public bool mtdPermitirDigitarSoNome()
        {
            //Selecione os caracteres que desejar.
            // Os valores ASC 3, 8, 22, 24 habilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente.
            string Texto = " -abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + System.Convert.ToChar(3) + System.Convert.ToChar(8) + System.Convert.ToChar(22) + System.Convert.ToChar(24);
            return !Texto.Contains(getKeyChar.ToString());
        }
        public bool mtdPermitirDigitarSoNome(int Key)
        {
            //Verifica se um caracter é permitido.
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
            //Selecione os caracteres que desejar.
            // Os valores ASC 3, 8, 22, 24 habilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente.
            string Numeros = " -abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" + System.Convert.ToChar(3) + System.Convert.ToChar(8) + System.Convert.ToChar(22) + System.Convert.ToChar(24);
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
            try
            {
                System.GC.Collect();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "~clsManipuladorTexto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }
    }
    # endregion

    //# region "Temporizador"
    //// Classe que gera um temporizador simples de ser usado, e razoavelmente preciso.
    //public class clsTemporizador
    //{
    //    // Como pode ser percebido abaixo, essa classe é inerente ao kernel32.dll, portanto, tendo sua portabilidade comprometida.
    //    // Variável de classe
    //    private static int numInstanciasCriadas = 0;
    //    // Variável de instância
    //    private double intervalo = 0;
    //    private double tempo = 0;
    //    private double tempoMax = 0;
    //    private long contadorInicial = 0;
    //    private long contador = 0;
    //    private long difcontador = 0;
    //    private long frequencia = long.MaxValue;
    //    // Número máximo que um inteiro longo sinalizado positivo pode suportar (((2^64)/2)-1).
    //    private double numLoops = 0;
    //    private string mensagemErro = "Não houve erros.";
    //    // Métodos estáticos - Static (CS.Net) ou compartilhados - Shared (VB.Net)
    //    [System.Security.SuppressUnmanagedCodeSecurity()]
    //    [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true, System.Runtime.InteropServices. DllImportAttribute.ExactSpelling = true)]
    //    private static extern bool QueryPerformanceCounter(ref long lpPerformanceCount);
    //    [System.Security.SuppressUnmanagedCodeSecurity()]
    //    [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true, System.Runtime.InteropServices. DllImportAttribute.ExactSpelling = true)]
    //    private static extern bool QueryPerformanceFrequency(ref long lpFrequency);
    //    // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
    //    public static int getnumInstanciasCriadas
    //    {
    //        get { return numInstanciasCriadas; }
    //    }
    //    // Propriedades que resgatam o valor das variáveis de instância.
    //    public double getintervalo
    //    {
    //        get { return intervalo; }
    //    }
    //    public double gettempo
    //    {
    //        get { return tempo; }
    //    }
    //    public double prptempoMax
    //    {
    //        get { return tempoMax; }
    //        set
    //        {
    //            if ((value > 0))
    //            {
    //                tempoMax = value;
    //            }
    //            else
    //            {
    //                tempoMax = 1;
    //                mensagemErro = "Ajuste o valor da variável tempoMax para que seja maior do que zero, " + "caso contrário será atribuído o tempo de um segundo a ela.";
    //            }
    //        }
    //    }
    //    public double getcontadorInicial
    //    {
    //        get { return contadorInicial; }
    //    }
    //    public double getcontador
    //    {
    //        get { return contador; }
    //    }
    //    public double getdifcontador
    //    {
    //        get { return difcontador; }
    //    }
    //    public double getfrequencia
    //    {
    //        get { return intervalo; }
    //    }
    //    public double getnumLoops
    //    {
    //        get { return numLoops; }
    //    }
    //    public string getmensagemErro
    //    {
    //        get { return mensagemErro; }
    //    }
    //    // Métodos que para serem usados, a classe deverá ser instanciada em um objeto. 
    //    // Métodos construtores sobrecarregados.
    //    public clsTemporizador()
    //    {
    //        numInstanciasCriadas += 1;
    //    }
    //    public clsTemporizador(double tempoMax)
    //    {
    //        prptempoMax = tempoMax;
    //        numInstanciasCriadas += 1;
    //    }
    //    // Métodos convencionais.
    //    public string mtdInformacao()
    //    {
    //        return "O tempo é dado em segundos, e a frequência de operação é dada em hertz.";
    //    }
    //    public bool mtdTemporizador()
    //    {
    //        bool erro = false;
    //        tempo = System.Convert.ToDouble((contador - contadorInicial) / frequencia);
    //        if (QueryPerformanceCounter(ref contadorInicial) != false)
    //        {
    //            // Início do código temporizador. 
    //            while ((tempo < tempoMax))
    //            {
    //                QueryPerformanceCounter(ref  contador);
    //                QueryPerformanceFrequency(ref  frequencia);
    //                intervalo = System.Convert.ToDouble(1.0 / frequencia);
    //                tempo = (contador - contadorInicial) * intervalo;
    //            }
    //            mensagemErro = "Não houve erros.";
    //            erro = true;
    //        }
    //        else
    //        {
    //            mensagemErro = "Resolução acima do suportado.";
    //            erro = false;
    //        }
    //        return erro;
    //    }
    //    public bool mtdTemporizador(double tempoMax)
    //    {
    //        prptempoMax = tempoMax;
    //        return mtdTemporizador();
    //    }
    //    public long mtdIniciarContador()
    //    {
    //        long retorno = 0;
    //        if (!(QueryPerformanceCounter(ref   contadorInicial)))
    //        {
    //            mensagemErro = "Resolução acima do suportado.";
    //            retorno = contadorInicial;
    //        }
    //        return retorno;
    //    }
    //    public double mtdPassoTempo()
    //    {
    //        if ((contadorInicial == -1))
    //        {
    //            contadorInicial = mtdIniciarContador();
    //        }
    //        tempo = System.Convert.ToDouble((contador - contadorInicial) / frequencia);
    //        if (!(QueryPerformanceCounter(ref contador)))
    //        {
    //            // Início do código temporizador. 
    //            QueryPerformanceCounter(ref contador);
    //            QueryPerformanceFrequency(ref frequencia);
    //            intervalo = System.Convert.ToDouble(1.0 / frequencia);
    //            tempo = (contador - contadorInicial) * intervalo;
    //        }
    //        else
    //        {
    //            mensagemErro = "Resolução acima do suportado.";
    //        }
    //        return tempo;
    //    }
    //    public double mtdPassoTempo(double tempoMax)
    //    {
    //        prptempoMax = tempoMax;
    //        return mtdPassoTempo();
    //    }
    //    public override string ToString()
    //    {
    //        string saida = "Contador Inicial: " + contadorInicial + "; Contador: " + contador + ";" + "\n" + "Tempo: " + tempo + " (s); Tempo Limite: " + tempoMax + " (s); Frequência: " + frequencia + " (Hz);" + "\n" + "Intervalo: " + intervalo + " (Hz); Diferença entre os contadores: " + difcontador + ";" + "\n" + "Números de Loops: " + numLoops + "; Número de Instâncias Criadas: " + numInstanciasCriadas + ";" + "\n" + "Mensagem de Erro: " + mensagemErro;
    //        return saida;
    //    }
    //    ~clsTemporizador()
    //    {
    //        // Método finalizador.
    //        numInstanciasCriadas -= 1;
    //        System.GC.Collect(0);
    //    }
    //}
    //# endregion

    //#region "EnderecoAplicativo"
    //public class clsEnderecoAplicativo
    //{
    //    // Variável de classe
    //    private static int numInstanciasCriadas = 0;
    //    // Método construtor sem parâmetros da classe, construção essa comum em Java
    //    public clsEnderecoAplicativo()
    //    {
    //        numInstanciasCriadas += 1;
    //        Endereco();
    //    }
    //    // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
    //    public static int getnumInstanciasCriadas
    //    {
    //        get { return numInstanciasCriadas; }
    //    }
    //    public string Endereco()
    //    {
    //        string varEnderecoAplicativo = string.Empty;
    //        char chrCaractere = '\0';
    //        int countBI = 0;
    //        int countmaxBI = 0;
    //        for (int i = 0; i <= System.Reflection.Assembly.GetEntryAssembly().Location.Length - 1; i++)
    //        {
    //            chrCaractere = System.Reflection.Assembly.GetExecutingAssembly().Location[i];
    //            if (chrCaractere.Equals('\\'))
    //            {
    //                countmaxBI += 1;
    //            }
    //        }
    //        for (int i = 0; i <= System.Reflection.Assembly.GetExecutingAssembly().Location.Length - 1; i++)
    //        {
    //            chrCaractere = System.Reflection.Assembly.GetExecutingAssembly().Location[i];
    //            varEnderecoAplicativo += chrCaractere;
    //            if (chrCaractere.Equals('\\'))
    //            {
    //                if (countmaxBI - 1 == countBI)
    //                {
    //                    break; // TODO: might not be correct. Was : Exit For
    //                }
    //                countBI += 1;
    //            }
    //        }
    //        return varEnderecoAplicativo;
    //    }
    //    ~clsEnderecoAplicativo()
    //    {
    //        numInstanciasCriadas -= 1;
    //        System.GC.Collect(0);
    //    }
    //}
    //# endregion

    //#region "Criptografia"
    ///// <summary>
    ///// Classe que inicia procedimentos relativos a Criptografia.
    ///// </summary>
    //public class clsCriptografia
    //{
    //    /// <summary>
    //    /// Variável de Classe
    //    /// </summary>
    //    private static int numInstanciasCriadas = 0;
    //    /// <summary>
    //    /// Variáveis de Instâncias
    //    /// </summary>
    //    private string senha = string.Empty;
    //    private string chave = string.Empty;
    //    private string senhaCriptografada = string.Empty;
    //    private string strMensagemErro = "Não há erros.";
    //    private Encryption.Symmetric.Provider tipoCriptografia = Encryption.Symmetric.Provider.Rijndael;
    //    /// <summary>
    //    /// Método Construtor sem argumentos.
    //    /// </summary>
    //    public clsCriptografia()
    //    {
    //        numInstanciasCriadas += 1;
    //    }
    //    /// <summary>
    //    /// Método Construtor com argumentos.
    //    /// </summary>
    //    public clsCriptografia(string senha)
    //    {
    //        numInstanciasCriadas += 1;
    //        setsenha = senha;
    //    }
    //    public clsCriptografia(string senha, string chave)
    //    {
    //        numInstanciasCriadas += 1;
    //        setsenha = senha;
    //        setchave = chave;
    //    }
    //    public clsCriptografia(string senha, string chave, Encryption.Symmetric.Provider tipoCriptografia)
    //    {
    //        numInstanciasCriadas += 1;
    //        setsenha = senha;
    //        setchave = chave;
    //        settipoCriptografia = tipoCriptografia;
    //    }
    //    /// <summary>
    //    /// Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
    //    /// </summary>
    //    public static int getnumInstanciasCriadas
    //    {
    //        get { return numInstanciasCriadas; }
    //    }
    //    /// <summary>
    //    /// Propriedade que resgata a senha.
    //    /// </summary>
    //    public string getsenha
    //    {
    //        get { return senha; }
    //    }
    //    /// <summary>
    //    /// Propriedade que ajusta a senha.
    //    /// </summary>
    //    public string setsenha
    //    {
    //        set
    //        {
    //            if (value.Length > 0)
    //            {
    //                senha = value;
    //            }
    //            else
    //            {
    //                strMensagemErro = "Digite uma senha que não seja nula.";
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// Propriedade que resgata a chave.
    //    /// </summary>
    //    public string getchave
    //    {
    //        get { return chave; }
    //    }
    //    /// <summary>
    //    /// Propriedade que ajusta a chave.
    //    /// </summary>
    //    public string setchave
    //    {
    //        set
    //        {
    //            if (value.Length > 0 & value.Length < 17)
    //            {
    //                chave = value;
    //            }
    //            else
    //            {
    //                strMensagemErro = "Digite uma chave com comprimento entre 1 e 16 caracteres.";
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// Propriedade que resgata a senha criptografada.
    //    /// </summary>
    //    public string getsenhaCriptografada
    //    {
    //        get { return senhaCriptografada; }
    //    }
    //    /// <summary>
    //    /// Propriedade que ajusta a senha criptografada.
    //    /// </summary>
    //    public string setsenhaCriptografada
    //    {
    //        set
    //        {
    //            if (value.Length > 0)
    //            {
    //                senhaCriptografada = value;
    //            }
    //            else
    //            {
    //                strMensagemErro = "Digite uma senha criptografada que não seja nula.";
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// Propriedade que resgata a mensagem de erro.
    //    /// </summary>
    //    public string getMensagemErro
    //    {
    //        get { return strMensagemErro; }
    //    }
    //    /// <summary>
    //    /// Propriedade que ajusta a mensagem de erro.
    //    /// </summary>
    //    public string setMensagemErro
    //    {
    //        set { strMensagemErro = value; }
    //    }
    //    /// <summary>
    //    /// Propriedade que resgata o tipo de criptografia.
    //    /// </summary>
    //    public Encryption.Symmetric.Provider gettipoCriptografia
    //    {
    //        get { return tipoCriptografia; }
    //    }
    //    /// <summary>
    //    /// Propriedade que ajusta o tipo de criptografia.
    //    /// </summary>
    //    public Encryption.Symmetric.Provider settipoCriptografia
    //    {
    //        set { tipoCriptografia = value; }
    //    }
    //    /// <summary>
    //    /// Métodos sobrecarregados de criptografar senha.
    //    /// </summary>
    //    public string mtdCriptografar()
    //    {
    //        string senhaCriptografada = string.Empty;
    //        Encryption.Symmetric sym = new Encryption.Symmetric(tipoCriptografia);
    //        Encryption.Data key = new Encryption.Data(chave);
    //        Encryption.Data encryptedData = default(Encryption.Data);
    //        if (!(chave == string.Empty))
    //        {
    //            if (!(senha == string.Empty))
    //            {
    //                encryptedData = sym.Encrypt(new Encryption.Data(senha), key);
    //                senhaCriptografada = encryptedData.Text;
    //            }
    //            else
    //            {
    //                senhaCriptografada = string.Empty;
    //            }
    //        }
    //        setsenhaCriptografada = senhaCriptografada;
    //        return getsenhaCriptografada;
    //    }
    //    public string mtdCriptografar(string senha)
    //    {
    //        setsenha = senha;
    //        return mtdCriptografar();
    //    }
    //    public string mtdCriptografar(string senha, string chave)
    //    {
    //        setsenha = senha;
    //        setchave = chave;
    //        return mtdCriptografar();
    //    }
    //    public string mtdCriptografar(string senha, string chave, Encryption.Symmetric.Provider tipoCriptografia)
    //    {
    //        setsenha = senha;
    //        setchave = chave;
    //        settipoCriptografia = tipoCriptografia;
    //        return mtdCriptografar();
    //    }
    //    /// <summary>
    //    /// Métodos sobrecarregados de descriptografar senha.
    //    /// </summary>
    //    public string mtdDesCriptografar()
    //    {
    //        string senhaDescriptografada = string.Empty;
    //        Encryption.Symmetric sym = new Encryption.Symmetric(tipoCriptografia);
    //        Encryption.Data key = new Encryption.Data(chave);
    //        Encryption.Data encryptedData = new Encryption.Data(senhaCriptografada);
    //        Encryption.Data decryptedData = default(Encryption.Data);
    //        if (!(chave == string.Empty))
    //        {
    //            if (!(senhaCriptografada == string.Empty))
    //            {
    //                decryptedData = sym.Decrypt(encryptedData, key);
    //                senhaDescriptografada = decryptedData.Text;
    //            }
    //            else
    //            {
    //                senhaDescriptografada = string.Empty;
    //            }
    //        }
    //        setsenha = senhaDescriptografada;
    //        return getsenha;
    //    }
    //    public string mtdDesCriptografar(string senhaCriptografada)
    //    {
    //        setsenhaCriptografada = senhaCriptografada;
    //        return mtdDesCriptografar();
    //    }
    //    public string mtdDesCriptografar(string senhaCriptografada, string chave)
    //    {
    //        setsenhaCriptografada = senhaCriptografada;
    //        setchave = chave;
    //        return mtdDesCriptografar();
    //    }
    //    public string mtdDesCriptografar(string senhaCriptografada, string chave, Encryption.Symmetric.Provider tipoCriptografia)
    //    {
    //        setsenhaCriptografada = senhaCriptografada;
    //        setchave = chave;
    //        settipoCriptografia = tipoCriptografia;
    //        return mtdDesCriptografar();
    //    }
    //    ~clsCriptografia()
    //    {
    //        /// <summary> 
    //        /// Método Finalizador.
    //        /// </summary>
    //        numInstanciasCriadas -= 1;
    //        System.GC.Collect(0);
    //    }
    //}
    //#endregion

    #region "ArquivoTXT"
    public class clsArquivoTXT : object
    {
        // Variável de classe
        private static int numInstanciasCriadas = 0;

        // Variáveis de Instância
        private string strEnderecoArquivo;
        private string strTexto;
        private System.IO.StreamWriter stwEscritorTexto;
        private System.IO.StreamReader stdLeitorTexto;
        private System.IO.BinaryWriter bnrEscritorBinario;
        private System.IO.BinaryReader bnrLeitorBinario;

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
                    return string.Empty;
                }
            }
        }
        public string setTexto
        {
            set { strTexto = value; }
        }
        public bool getFimArquivo
        {
            get { return stdLeitorTexto.EndOfStream; }
        }
        public System.IO.StreamWriter prpEscritorTexto
        {
            get { return stwEscritorTexto; }
            set { value = stwEscritorTexto; }
        }
        public System.IO.StreamReader prpLeitorTexto
        {
            get { return stdLeitorTexto; }
            set { value = stdLeitorTexto; }
        }
        public System.IO.BinaryWriter prpEscritorBinario
        {
            get { return bnrEscritorBinario; }
            set { value = bnrEscritorBinario; }
        }
        public System.IO.BinaryReader prpLeitorBinario
        {
            get { return bnrLeitorBinario; }
            set { value = bnrLeitorBinario; }
        }

        public bool mtdCriadorTexto()
        {
            stwEscritorTexto = System.IO.File.CreateText(getEnderecoArquivo);
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

        private string[] TextoTemporario = new string[100];
        private int contador = 0;

        private string mtdComposicaoBuffer(string[] Vetor, int Contador)
        {
            string Retorno = string.Empty;

            for (int i = Contador + 1; i <= Vetor.Length - 1; i++)
            {
                if (Vetor[i] != null)
                {
                    Retorno += string.Format("{0}\n\r", Vetor[i]);
                }
            }

            for (int i = 0; i <= Contador - 1; i++)
            {
                if (Vetor[i] != null)
                {
                    Retorno += string.Format("{0}\n\r", Vetor[i]);
                }
            }

            return Retorno;
        }

        public bool mtdAcrescentarTexto()
        {
            bool blnRetorno = false;
            try
            {
                if (contador > TextoTemporario.Length)
                {
                    contador = 0;
                }
                TextoTemporario[contador++] = getTexto;
                System.IO.StreamWriter stwEscritorTexto = System.IO.File.CreateText(getEnderecoArquivo);
                stwEscritorTexto.Write(mtdComposicaoBuffer(TextoTemporario, contador));
                stwEscritorTexto.Close();
                blnRetorno = true;
            }
            catch (System.Exception ex)
            {
                string strExcecao = "mtdAcrescentarTexto: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
                blnRetorno = false;
            }

            return blnRetorno;
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
            stdLeitorTexto = System.IO.File.OpenText(getEnderecoArquivo);
            setTexto = stdLeitorTexto.ReadToEnd();
            stdLeitorTexto.Close();
            return getTexto;
        }
        public string mtdLeitorTexto(string EnderecoArquivo)
        {
            setEnderecoArquivo = EnderecoArquivo;
            return mtdLeitorTexto();
        }
        public void mtdAbrirLeitorTexto()
        {
            stdLeitorTexto = System.IO.File.OpenText(getEnderecoArquivo);
        }
        public void mtdAbrirLeitorTexto(string EnderecoArquivo)
        {
            setEnderecoArquivo = EnderecoArquivo;
            stdLeitorTexto = System.IO.File.OpenText(getEnderecoArquivo);
        }
        public string mtdLeitorTextoLinha()
        {
            setTexto = stdLeitorTexto.ReadLine();
            return getTexto;
        }
        public bool mtdEscritorBinario()
        {
            bnrEscritorBinario = new System.IO.BinaryWriter(System.IO.File.OpenWrite(getEnderecoArquivo));
            bnrEscritorBinario.Write(getTexto);
            bnrEscritorBinario.Close();
            return mtdEscritorBinario();
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
            return mtdEscritorBinario();
        }
        public string mtdLeitorBinario()
        {
            bnrLeitorBinario = new System.IO.BinaryReader(System.IO.File.OpenRead(getEnderecoArquivo));
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
            try
            {
                System.GC.Collect();
            }
            catch (System.Exception ex)
            {
                string strExcecao = "~clsArquivoTXT: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(strExcecao);
                //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            }
        }
    }
    # endregion

    //#region "EnderecoAplicativo"
    //public class clsEnderecoAplicativo
    //{
    //    // Variável de classe
    //    private static int numInstanciasCriadas = 0;
    //    // Método construtor sem parâmetros da classe, construção essa comum em Java
    //    public clsEnderecoAplicativo()
    //    {
    //        numInstanciasCriadas += 1;
    //        Endereco();
    //    }
    //    // Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
    //    public static int getnumInstanciasCriadas
    //    {
    //        get { return numInstanciasCriadas; }
    //    }
    //    public string Endereco()
    //    {
    //        string varEnderecoAplicativo = string.Empty;
    //        char chrCaractere = '\0';
    //        int countBI = 0;
    //        int countmaxBI = 0;
    //        for (int i = 0; i <= System.Reflection.Assembly.GetEntryAssembly().Location.Length - 1; i++)
    //        {
    //            chrCaractere = System.Reflection.Assembly.GetExecutingAssembly().Location[i];
    //            if (chrCaractere.Equals('\\'))
    //            {
    //                countmaxBI += 1;
    //            }
    //        }
    //        for (int i = 0; i <= System.Reflection.Assembly.GetExecutingAssembly().Location.Length - 1; i++)
    //        {
    //            chrCaractere = System.Reflection.Assembly.GetExecutingAssembly().Location[i];
    //            varEnderecoAplicativo += chrCaractere;
    //            if (chrCaractere.Equals('\\'))
    //            {
    //                if (countmaxBI - 1 == countBI)
    //                {
    //                    break; // TODO: might not be correct. Was : Exit For
    //                }
    //                countBI += 1;
    //            }
    //        }
    //        return varEnderecoAplicativo;
    //    }
    //    ~clsEnderecoAplicativo()
    //    {
    //        numInstanciasCriadas -= 1;
    //        System.GC.Collect(); asdfdsfasda;
    //    }
    //}
    //# endregion

    //#region "Encryption"
    //// A simple, string-oriented wrapper class for encryption functions, including 
    //// Hashing, Symmetric Encryption, and Asymmetric Encryption.
    ////
    //// Jeff Atwood
    //// http://www.codinghorror.com/
    //namespace Encryption
    //{

    //    #region " Hash"

    //    /// <summary>
    //    /// Hash functions are fundamental to modern cryptography. These functions map binary 
    //    /// strings of an arbitrary length to small binary stringas of a fixed length, known as 
    //    /// hash values. A cryptographic hash function has the property that it is computationally
    //    /// infeasible to find two distinct inputs that hash to the same value. Hash functions 
    //    /// are commonly used with digital signatures and for data integrity.
    //    /// </summary>
    //    public class Hash
    //    {

    //        /// <summary>
    //        /// Type of hash; some are security oriented, others are fast and simple
    //        /// </summary>
    //        public enum Provider
    //        {
    //            /// <summary>
    //            /// Cyclic Redundancy Check provider, 32-bit
    //            /// </summary>
    //            CRC32,
    //            /// <summary>
    //            /// Secure Hashing Algorithm provider, SHA-1 variant, 160-bit
    //            /// </summary>
    //            SHA1,
    //            /// <summary>
    //            /// Secure Hashing Algorithm provider, SHA-2 variant, 256-bit
    //            /// </summary>
    //            SHA256,
    //            /// <summary>
    //            /// Secure Hashing Algorithm provider, SHA-2 variant, 384-bit
    //            /// </summary>
    //            SHA384,
    //            /// <summary>
    //            /// Secure Hashing Algorithm provider, SHA-2 variant, 512-bit
    //            /// </summary>
    //            SHA512,
    //            /// <summary>
    //            /// Message Digest algorithm 5, 128-bit
    //            /// </summary>
    //            MD5
    //        }

    //        private System.Security.Cryptography.HashAlgorithm _Hash;
    //        private Data _HashValue = new Data();

    //        private Hash()
    //        {
    //        }

    //        /// <summary>
    //        /// Instantiate a new hash of the specified type
    //        /// </summary>
    //        public Hash(Provider p)
    //        {
    //            switch (p)
    //            {
    //                case Provider.CRC32:
    //                    _Hash = new CRC32();
    //                    break;
    //                case Provider.MD5:
    //                    _Hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
    //                    break;
    //                case Provider.SHA1:
    //                    _Hash = new System.Security.Cryptography.SHA1Managed();
    //                    break;
    //                case Provider.SHA256:
    //                    _Hash = new System.Security.Cryptography.SHA256Managed();
    //                    break;
    //                case Provider.SHA384:
    //                    _Hash = new System.Security.Cryptography.SHA384Managed();
    //                    break;
    //                case Provider.SHA512:
    //                    _Hash = new System.Security.Cryptography.SHA512Managed();
    //                    break;
    //            }
    //        }

    //        /// <summary>
    //        /// Returns the previously calculated hash
    //        /// </summary>
    //        public Data Value
    //        {
    //            get { return _HashValue; }
    //        }

    //        /// <summary>
    //        /// Calculates hash on a stream of arbitrary length
    //        /// </summary>
    //        public Data Calculate(ref System.IO.Stream s)
    //        {
    //            _HashValue.Bytes = _Hash.ComputeHash(s);
    //            return _HashValue;
    //        }

    //        /// <summary>
    //        /// Calculates hash for fixed length <see cref="Data"/>
    //        /// </summary>
    //        public Data Calculate(Data d)
    //        {
    //            return CalculatePrivate(d.Bytes);
    //        }

    //        /// <summary>
    //        /// Calculates hash for a string with a prefixed salt value. 
    //        /// A "salt" is random data prefixed to every hashed value to prevent 
    //        /// common dictionary attacks.
    //        /// </summary>
    //        public Data Calculate(Data d, Data salt)
    //        {
    //            byte[] nb = new byte[d.Bytes.Length + salt.Bytes.Length];
    //            salt.Bytes.CopyTo(nb, 0);
    //            d.Bytes.CopyTo(nb, salt.Bytes.Length);
    //            return CalculatePrivate(nb);
    //        }

    //        /// <summary>
    //        /// Calculates hash for an System.Array of bytes
    //        /// </summary>
    //        private Data CalculatePrivate(byte[] b)
    //        {
    //            _HashValue.Bytes = _Hash.ComputeHash(b);
    //            return _HashValue;
    //        }

    //        #region " CRC32 HashAlgorithm"
    //        private class CRC32 : System.Security.Cryptography.HashAlgorithm
    //        {

    //            private int result = System.Convert.ToInt32(0xffffffff);

    //            protected override void HashCore(byte[] Array, int ibStart, int cbSize)
    //            {
    //                int lookup = 0;
    //                for (int i = ibStart; i <= cbSize - 1; i++)
    //                {
    //                    lookup = (result & 0xff) ^ Array[i];
    //                    result = (int)((result & 0xffffff00) / 0x100) & 0xffffff;
    //                    result = result ^ (int)crcLookup[lookup];
    //                }
    //            }

    //            protected override byte[] HashFinal()
    //            {
    //                byte[] b = System.BitConverter.GetBytes(~result);
    //                System.Array.Reverse(b);
    //                return b;
    //            }

    //            public override void Initialize()
    //            {
    //                result = System.Convert.ToInt32(0xffffffff);
    //            }

    //            private uint[] crcLookup = { 0x0, 0x77073096, 0xee0e612c, 0x990951ba, 0x76dc419, 0x706af48f, 0xe963a535, 0x9e6495a3, 0xedb8832, 0x79dcb8a4, 
    //        0xe0d5e91e, 0x97d2d988, 0x9b64c2b, 0x7eb17cbd, 0xe7b82d07, 0x90bf1d91, 0x1db71064, 0x6ab020f2, 0xf3b97148, 0x84be41de, 
    //        0x1adad47d, 0x6ddde4eb, 0xf4d4b551, 0x83d385c7, 0x136c9856, 0x646ba8c0, 0xfd62f97a, 0x8a65c9ec, 0x14015c4f, 0x63066cd9, 
    //        0xfa0f3d63, 0x8d080df5, 0x3b6e20c8, 0x4c69105e, 0xd56041e4, 0xa2677172, 0x3c03e4d1, 0x4b04d447, 0xd20d85fd, 0xa50ab56b, 
    //        0x35b5a8fa, 0x42b2986c, 0xdbbbc9d6, 0xacbcf940, 0x32d86ce3, 0x45df5c75, 0xdcd60dcf, 0xabd13d59, 0x26d930ac, 0x51de003a, 
    //        0xc8d75180, 0xbfd06116, 0x21b4f4b5, 0x56b3c423, 0xcfba9599, 0xb8bda50f, 0x2802b89e, 0x5f058808, 0xc60cd9b2, 0xb10be924, 
    //        0x2f6f7c87, 0x58684c11, 0xc1611dab, 0xb6662d3d, 0x76dc4190, 0x1db7106, 0x98d220bc, 0xefd5102a, 0x71b18589, 0x6b6b51f, 
    //        0x9fbfe4a5, 0xe8b8d433, 0x7807c9a2, 0xf00f934, 0x9609a88e, 0xe10e9818, 0x7f6a0dbb, 0x86d3d2d, 0x91646c97, 0xe6635c01, 
    //        0x6b6b51f4, 0x1c6c6162, 0x856530d8, 0xf262004e, 0x6c0695ed, 0x1b01a57b, 0x8208f4c1, 0xf50fc457, 0x65b0d9c6, 0x12b7e950, 
    //        0x8bbeb8ea, 0xfcb9887c, 0x62dd1ddf, 0x15da2d49, 0x8cd37cf3, 0xfbd44c65, 0x4db26158, 0x3ab551ce, 0xa3bc0074, 0xd4bb30e2, 
    //        0x4adfa541, 0x3dd895d7, 0xa4d1c46d, 0xd3d6f4fb, 0x4369e96a, 0x346ed9fc, 0xad678846, 0xda60b8d0, 0x44042d73, 0x33031de5, 
    //        0xaa0a4c5f, 0xdd0d7cc9, 0x5005713c, 0x270241aa, 0xbe0b1010, 0xc90c2086, 0x5768b525, 0x206f85b3, 0xb966d409, 0xce61e49f, 
    //        0x5edef90e, 0x29d9c998, 0xb0d09822, 0xc7d7a8b4, 0x59b33d17, 0x2eb40d81, 0xb7bd5c3b, 0xc0ba6cad, 0xedb88320, 0x9abfb3b6, 
    //        0x3b6e20c, 0x74b1d29a, 0xead54739, 0x9dd277af, 0x4db2615, 0x73dc1683, 0xe3630b12, 0x94643b84, 0xd6d6a3e, 0x7a6a5aa8, 
    //        0xe40ecf0b, 0x9309ff9d, 0xa00ae27, 0x7d079eb1, 0xf00f9344, 0x8708a3d2, 0x1e01f268, 0x6906c2fe, 0xf762575d, 0x806567cb, 
    //        0x196c3671, 0x6e6b06e7, 0xfed41b76, 0x89d32be0, 0x10da7a5a, 0x67dd4acc, 0xf9b9df6f, 0x8ebeeff9, 0x17b7be43, 0x60b08ed5, 
    //        0xd6d6a3e8, 0xa1d1937e, 0x38d8c2c4, 0x4fdff252, 0xd1bb67f1, 0xa6bc5767, 0x3fb506dd, 0x48b2364b, 0xd80d2bda, 0xaf0a1b4c, 
    //        0x36034af6, 0x41047a60, 0xdf60efc3, 0xa867df55, 0x316e8eef, 0x4669be79, 0xcb61b38c, 0xbc66831a, 0x256fd2a0, 0x5268e236, 
    //        0xcc0c7795, 0xbb0b4703, 0x220216b9, 0x5505262f, 0xc5ba3bbe, 0xb2bd0b28, 0x2bb45a92, 0x5cb36a04, 0xc2d7ffa7, 0xb5d0cf31, 
    //        0x2cd99e8b, 0x5bdeae1d, 0x9b64c2b0, 0xec63f226, 0x756aa39c, 0x26d930a, 0x9c0906a9, 0xeb0e363f, 0x72076785, 0x5005713, 
    //        0x95bf4a82, 0xe2b87a14, 0x7bb12bae, 0xcb61b38, 0x92d28e9b, 0xe5d5be0d, 0x7cdcefb7, 0xbdbdf21, 0x86d3d2d4, 0xf1d4e242, 
    //        0x68ddb3f8, 0x1fda836e, 0x81be16cd, 0xf6b9265b, 0x6fb077e1, 0x18b74777, 0x88085ae6, 0xff0f6a70, 0x66063bca, 0x11010b5c, 
    //        0x8f659eff, 0xf862ae69, 0x616bffd3, 0x166ccf45, 0xa00ae278, 0xd70dd2ee, 0x4e048354, 0x3903b3c2, 0xa7672661, 0xd06016f7, 
    //        0x4969474d, 0x3e6e77db, 0xaed16a4a, 0xd9d65adc, 0x40df0b66, 0x37d83bf0, 0xa9bcae53, 0xdebb9ec5, 0x47b2cf7f, 0x30b5ffe9, 
    //        0xbdbdf21c, 0xcabac28a, 0x53b39330, 0x24b4a3a6, 0xbad03605, 0xcdd70693, 0x54de5729, 0x23d967bf, 0xb3667a2e, 0xc4614ab8, 
    //        0x5d681b02, 0x2a6f2b94, 0xb40bbe37, 0xc30c8ea1, 0x5a05df1b, 0x2d02ef8d };

    //            public override byte[] Hash
    //            {
    //                get
    //                {
    //                    byte[] b = System.BitConverter.GetBytes(~result);
    //                    System.Array.Reverse(b);
    //                    return b;
    //                }
    //            }
    //        }

    //        #endregion

    //    }
    //    #endregion

    //    #region " Symmetric"

    //    /// <summary>
    //    /// Symmetric encryption uses a single key to encrypt and decrypt. 
    //    /// Both parties (encryptor and decryptor) must share the same secret key.
    //    /// </summary>
    //    public class Symmetric
    //    {

    //        private const string _DefaultIntializationVector = "%1Az=-@qT";
    //        private const int _BufferSize = 2048;

    //        public enum Provider
    //        {
    //            /// <summary>
    //            /// The Data Encryption Standard provider supports a 64 bit key only
    //            /// </summary>
    //            DES,
    //            /// <summary>
    //            /// The Rivest Cipher 2 provider supports keys ranging from 40 to 128 bits, default is 128 bits
    //            /// </summary>
    //            RC2,
    //            /// <summary>
    //            /// The Rijndael (also known as AES) provider supports keys of 128, 192, or 256 bits with a default of 256 bits
    //            /// </summary>
    //            Rijndael,
    //            /// <summary>
    //            /// The TripleDES provider (also known as 3DES) supports keys of 128 or 192 bits with a default of 192 bits
    //            /// </summary>
    //            TripleDES
    //        }

    //        private Data _key;
    //        private Data _iv;
    //        private System.Security.Cryptography.SymmetricAlgorithm _crypto;

    //        private Symmetric()
    //        {
    //        }

    //        /// <summary>
    //        /// Instantiates a new symmetric encryption object using the specified provider.
    //        /// </summary>
    //        public Symmetric(Provider provider)
    //            : this(provider, true)
    //        {
    //        }

    //        /// <summary>
    //        /// Instantiates overloaded a new symmetric encryption object using the specified provider.
    //        /// </summary>
    //        public Symmetric(Provider provider, bool useDefaultInitializationVector)
    //        {
    //            switch (provider)
    //            {
    //                case Provider.DES:
    //                    _crypto = new System.Security.Cryptography.DESCryptoServiceProvider();
    //                    break;
    //                case Provider.RC2:
    //                    _crypto = new System.Security.Cryptography.RC2CryptoServiceProvider();
    //                    break;
    //                case Provider.Rijndael:
    //                    _crypto = new System.Security.Cryptography.RijndaelManaged();
    //                    break;
    //                case Provider.TripleDES:
    //                    _crypto = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
    //                    break;
    //            }

    //            //-- make sure key and IV are always set, no matter what
    //            this.Key = RandomKey();
    //            if (useDefaultInitializationVector)
    //            {
    //                this.IntializationVector = new Data(_DefaultIntializationVector);
    //            }
    //            else
    //            {
    //                this.IntializationVector = RandomInitializationVector();
    //            }
    //        }


    //        /// <summary>
    //        /// Key size in bytes. We use the default key size for any given provider; if you 
    //        /// want to force a specific key size, set this property
    //        /// </summary>
    //        public int KeySizeBytes
    //        {
    //            get { return _crypto.KeySize / 8; }
    //            set
    //            {
    //                _crypto.KeySize = value * 8;
    //                _key.MaxBytes = value;
    //            }
    //        }

    //        /// <summary>
    //        /// Key size in bits. We use the default key size for any given provider; if you 
    //        /// want to force a specific key size, set this property
    //        /// </summary>
    //        public int KeySizeBits
    //        {
    //            get { return _crypto.KeySize; }
    //            set
    //            {
    //                _crypto.KeySize = value;
    //                _key.MaxBits = value;
    //            }
    //        }

    //        /// <summary>
    //        /// The key used to encrypt/decrypt data
    //        /// </summary>
    //        public Data Key
    //        {
    //            get { return _key; }
    //            set
    //            {
    //                _key = value;
    //                _key.MaxBytes = _crypto.LegalKeySizes[0].MaxSize / 8;
    //                _key.MinBytes = _crypto.LegalKeySizes[0].MinSize / 8;
    //                _key.StepBytes = _crypto.LegalKeySizes[0].SkipSize / 8;
    //            }
    //        }

    //        /// <summary>
    //        /// Using the default Cipher Block Chaining (CBC) mode, all data blocks are processed using
    //        /// the value derived from the previous block; the first data block has no previous data block
    //        /// to use, so it needs an InitializationVector to feed the first block
    //        /// </summary>
    //        public Data IntializationVector
    //        {
    //            get { return _iv; }
    //            set
    //            {
    //                _iv = value;
    //                _iv.MaxBytes = _crypto.BlockSize / 8;
    //                _iv.MinBytes = _crypto.BlockSize / 8;
    //            }
    //        }

    //        /// <summary>
    //        /// generates a random Initialization Vector, if one was not provided
    //        /// </summary>
    //        public Data RandomInitializationVector()
    //        {
    //            _crypto.GenerateIV();
    //            Data d = new Data(_crypto.IV);
    //            return d;
    //        }

    //        /// <summary>
    //        /// generates a random Key, if one was not provided
    //        /// </summary>
    //        public Data RandomKey()
    //        {
    //            _crypto.GenerateKey();
    //            Data d = new Data(_crypto.Key);
    //            return d;
    //        }

    //        /// <summary>
    //        /// Ensures that _crypto object has valid Key and IV
    //        /// prior to any attempt to encrypt/decrypt anything
    //        /// </summary>
    //        private void ValidateKeyAndIv(bool isEncrypting)
    //        {
    //            if (_key.IsEmpty)
    //            {
    //                if (isEncrypting)
    //                {
    //                    _key = RandomKey();
    //                }
    //                else
    //                {
    //                    throw new System.Security.Cryptography.CryptographicException("No key was provided for the decryption operation!");
    //                }
    //            }
    //            if (_iv.IsEmpty)
    //            {
    //                if (isEncrypting)
    //                {
    //                    _iv = RandomInitializationVector();
    //                }
    //                else
    //                {
    //                    throw new System.Security.Cryptography.CryptographicException("No initialization vector was provided for the decryption operation!");
    //                }
    //            }
    //            _crypto.Key = _key.Bytes;
    //            _crypto.IV = _iv.Bytes;
    //        }

    //        /// <summary>
    //        /// Encrypts the specified Data using provided key
    //        /// </summary>
    //        public Data Encrypt(Data d, Data key)
    //        {
    //            this.Key = key;
    //            return Encrypt(d);
    //        }

    //        /// <summary>
    //        /// Encrypts the specified Data using preset key and preset initialization vector
    //        /// </summary>
    //        public Data Encrypt(Data d)
    //        {
    //            System.IO.MemoryStream ms = new System.IO.MemoryStream();

    //            ValidateKeyAndIv(true);

    //            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, _crypto.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
    //            cs.Write(d.Bytes, 0, d.Bytes.Length);
    //            cs.Close();
    //            ms.Close();

    //            return new Data(ms.ToArray());
    //        }

    //        /// <summary>
    //        /// Encrypts the stream to memory using provided key and provided initialization vector
    //        /// </summary>
    //        public Data Encrypt(System.IO.Stream s, Data key, Data iv)
    //        {
    //            this.IntializationVector = iv;
    //            this.Key = key;
    //            return Encrypt(s);
    //        }

    //        /// <summary>
    //        /// Encrypts the stream to memory using specified key
    //        /// </summary>
    //        public Data Encrypt(System.IO.Stream s, Data key)
    //        {
    //            this.Key = key;
    //            return Encrypt(s);
    //        }

    //        /// <summary>
    //        /// Encrypts the specified stream to memory using preset key and preset initialization vector
    //        /// </summary>
    //        public Data Encrypt(System.IO.Stream s)
    //        {
    //            System.IO.MemoryStream ms = new System.IO.MemoryStream();
    //            byte[] b = new byte[_BufferSize + 1];
    //            int i = 0;

    //            ValidateKeyAndIv(true);

    //            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, _crypto.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
    //            i = s.Read(b, 0, _BufferSize);
    //            while (i > 0)
    //            {
    //                cs.Write(b, 0, i);
    //                i = s.Read(b, 0, _BufferSize);
    //            }

    //            cs.Close();
    //            ms.Close();

    //            return new Data(ms.ToArray());
    //        }

    //        /// <summary>
    //        /// Decrypts the specified data using provided key and preset initialization vector
    //        /// </summary>
    //        public Data Decrypt(Data encryptedData, Data key)
    //        {
    //            this.Key = key;
    //            return Decrypt(encryptedData);
    //        }

    //        /// <summary>
    //        /// Decrypts the specified stream using provided key and preset initialization vector
    //        /// </summary>
    //        public Data Decrypt(System.IO.Stream encryptedStream, Data key)
    //        {
    //            this.Key = key;
    //            return Decrypt(encryptedStream);
    //        }

    //        /// <summary>
    //        /// Decrypts the specified stream using preset key and preset initialization vector
    //        /// </summary>
    //        public Data Decrypt(System.IO.Stream encryptedStream)
    //        {
    //            System.IO.MemoryStream ms = new System.IO.MemoryStream();
    //            byte[] b = new byte[_BufferSize + 1];

    //            ValidateKeyAndIv(false);
    //            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(encryptedStream, _crypto.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Read);

    //            int i = 0;
    //            i = cs.Read(b, 0, _BufferSize);

    //            while (i > 0)
    //            {
    //                ms.Write(b, 0, i);
    //                i = cs.Read(b, 0, _BufferSize);
    //            }
    //            cs.Close();
    //            ms.Close();

    //            return new Data(ms.ToArray());
    //        }

    //        /// <summary>
    //        /// Decrypts the specified data using preset key and preset initialization vector
    //        /// </summary>
    //        public Data Decrypt(Data encryptedData)
    //        {
    //            System.IO.MemoryStream ms = new System.IO.MemoryStream(encryptedData.Bytes, 0, encryptedData.Bytes.Length);
    //            byte[] b = new byte[encryptedData.Bytes.Length];

    //            ValidateKeyAndIv(false);
    //            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, _crypto.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Read);

    //            try
    //            {
    //                cs.Read(b, 0, encryptedData.Bytes.Length - 1);
    //            }
    //            catch (System.Security.Cryptography.CryptographicException ex)
    //            {
    //                throw new System.Security.Cryptography.CryptographicException("Unable to decrypt data. The provided key may be invalid.", ex);
    //            }
    //            finally
    //            {
    //                cs.Close();
    //            }
    //            return new Data(b);
    //        }

    //    }

    //    #endregion

    //    #region " Asymmetric"

    //    /// <summary>
    //    /// Asymmetric encryption uses a pair of keys to encrypt and decrypt.
    //    /// There is a "public" key which is used to encrypt. Decrypting, on the other hand, 
    //    /// requires both the "public" key and an additional "private" key. The advantage is 
    //    /// that people can send you encrypted messages without being able to decrypt them.
    //    /// </summary>
    //    /// <remarks>
    //    /// The only provider supported is the <see cref="RSACryptoServiceProvider"/>
    //    /// </remarks>
    //    public class Asymmetric
    //    {

    //        private System.Security.Cryptography.RSACryptoServiceProvider _rsa;
    //        private string _KeyContainerName = "Encryption.AsymmetricEncryption.DefaultContainerName";
    //        private int _KeySize = 1024;

    //        private const string _ElementParent = "RSAKeyValue";
    //        private const string _ElementModulus = "Modulus";
    //        private const string _ElementExponent = "Exponent";
    //        private const string _ElementPrimeP = "P";
    //        private const string _ElementPrimeQ = "Q";
    //        private const string _ElementPrimeExponentP = "DP";
    //        private const string _ElementPrimeExponentQ = "DQ";
    //        private const string _ElementCoefficient = "InverseQ";
    //        private const string _ElementPrivateExponent = "D";

    //        //-- http://forum.java.sun.com/thread.jsp?forum=9&thread=552022&tstart=0&trange=15 
    //        private const string _KeyModulus = "PublicKey.Modulus";
    //        private const string _KeyExponent = "PublicKey.Exponent";
    //        private const string _KeyPrimeP = "PrivateKey.P";
    //        private const string _KeyPrimeQ = "PrivateKey.Q";
    //        private const string _KeyPrimeExponentP = "PrivateKey.DP";
    //        private const string _KeyPrimeExponentQ = "PrivateKey.DQ";
    //        private const string _KeyCoefficient = "PrivateKey.InverseQ";
    //        private const string _KeyPrivateExponent = "PrivateKey.D";

    //        #region " PublicKey Class"
    //        /// <summary>
    //        /// Represents a public encryption key. Intended to be shared, it 
    //        /// contains only the Modulus and Exponent.
    //        /// </summary>
    //        public class PublicKey
    //        {
    //            public string Modulus;
    //            public string Exponent;

    //            public PublicKey()
    //            {
    //            }

    //            public PublicKey(string KeyXml)
    //            {
    //                LoadFromXml(KeyXml);
    //            }

    //            /// <summary>
    //            /// Load public key from App.config or Web.config file
    //            /// </summary>
    //            public void LoadFromConfig()
    //            {
    //                this.Modulus = Utils.GetConfigString(_KeyModulus);
    //                this.Exponent = Utils.GetConfigString(_KeyExponent);
    //            }

    //            /// <summary>
    //            /// Returns *.config file XML section representing this public key
    //            /// </summary>
    //            public string ToConfigSection()
    //            {
    //                System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //                {
    //                    sb.Append(Utils.WriteConfigKey(_KeyModulus, this.Modulus));
    //                    sb.Append(Utils.WriteConfigKey(_KeyExponent, this.Exponent));
    //                }
    //                return sb.ToString();
    //            }

    //            /// <summary>
    //            /// Writes the *.config file representation of this public key to a file
    //            /// </summary>
    //            public void ExportToConfigFile(string filePath)
    //            {
    //                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false);
    //                sw.Write(this.ToConfigSection());
    //                sw.Close();
    //            }

    //            /// <summary>
    //            /// Loads the public key from its XML string
    //            /// </summary>
    //            public void LoadFromXml(string keyXml)
    //            {
    //                this.Modulus = Utils.GetXmlElement(keyXml, "Modulus");
    //                this.Exponent = Utils.GetXmlElement(keyXml, "Exponent");
    //            }

    //            /// <summary>
    //            /// System.Converts this public key to an RSAParameters object
    //            /// </summary>
    //            public System.Security.Cryptography.RSAParameters ToParameters()
    //            {
    //                System.Security.Cryptography.RSAParameters r = new System.Security.Cryptography.RSAParameters();
    //                r.Modulus = System.Convert.FromBase64String(this.Modulus);
    //                r.Exponent = System.Convert.FromBase64String(this.Exponent);
    //                return r;
    //            }

    //            /// <summary>
    //            /// System.Converts this public key to its XML string representation
    //            /// </summary>
    //            public string ToXml()
    //            {
    //                System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //                {
    //                    sb.Append(Utils.WriteXmlNode(_ElementParent));
    //                    sb.Append(Utils.WriteXmlElement(_ElementModulus, this.Modulus));
    //                    sb.Append(Utils.WriteXmlElement(_ElementExponent, this.Exponent));
    //                    sb.Append(Utils.WriteXmlNode(_ElementParent, true));
    //                }
    //                return sb.ToString();
    //            }

    //            /// <summary>
    //            /// Writes the Xml representation of this public key to a file
    //            /// </summary>
    //            public void ExportToXmlFile(string filePath)
    //            {
    //                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false);
    //                sw.Write(this.ToXml());
    //                sw.Close();
    //            }

    //        }
    //        #endregion

    //        #region " PrivateKey Class"

    //        /// <summary>
    //        /// Represents a private encryption key. Not intended to be shared, as it 
    //        /// contains all the elements that make up the key.
    //        /// </summary>
    //        public class PrivateKey
    //        {
    //            public string Modulus;
    //            public string Exponent;
    //            public string PrimeP;
    //            public string PrimeQ;
    //            public string PrimeExponentP;
    //            public string PrimeExponentQ;
    //            public string Coefficient;
    //            public string PrivateExponent;

    //            public PrivateKey()
    //            {
    //            }

    //            public PrivateKey(string keyXml)
    //            {
    //                LoadFromXml(keyXml);
    //            }

    //            /// <summary>
    //            /// Load private key from App.config or Web.config file
    //            /// </summary>
    //            public void LoadFromConfig()
    //            {
    //                this.Modulus = Utils.GetConfigString(_KeyModulus);
    //                this.Exponent = Utils.GetConfigString(_KeyExponent);
    //                this.PrimeP = Utils.GetConfigString(_KeyPrimeP);
    //                this.PrimeQ = Utils.GetConfigString(_KeyPrimeQ);
    //                this.PrimeExponentP = Utils.GetConfigString(_KeyPrimeExponentP);
    //                this.PrimeExponentQ = Utils.GetConfigString(_KeyPrimeExponentQ);
    //                this.Coefficient = Utils.GetConfigString(_KeyCoefficient);
    //                this.PrivateExponent = Utils.GetConfigString(_KeyPrivateExponent);
    //            }

    //            /// <summary>
    //            /// System.Converts this private key to an RSAParameters object
    //            /// </summary>
    //            public System.Security.Cryptography.RSAParameters ToParameters()
    //            {
    //                System.Security.Cryptography.RSAParameters r = new System.Security.Cryptography.RSAParameters();
    //                r.Modulus = System.Convert.FromBase64String(this.Modulus);
    //                r.Exponent = System.Convert.FromBase64String(this.Exponent);
    //                r.P = System.Convert.FromBase64String(this.PrimeP);
    //                r.Q = System.Convert.FromBase64String(this.PrimeQ);
    //                r.DP = System.Convert.FromBase64String(this.PrimeExponentP);
    //                r.DQ = System.Convert.FromBase64String(this.PrimeExponentQ);
    //                r.InverseQ = System.Convert.FromBase64String(this.Coefficient);
    //                r.D = System.Convert.FromBase64String(this.PrivateExponent);
    //                return r;
    //            }

    //            /// <summary>
    //            /// Returns *.config file XML section representing this private key
    //            /// </summary>
    //            public string ToConfigSection()
    //            {
    //                System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //                {
    //                    sb.Append(Utils.WriteConfigKey(_KeyModulus, this.Modulus));
    //                    sb.Append(Utils.WriteConfigKey(_KeyExponent, this.Exponent));
    //                    sb.Append(Utils.WriteConfigKey(_KeyPrimeP, this.PrimeP));
    //                    sb.Append(Utils.WriteConfigKey(_KeyPrimeQ, this.PrimeQ));
    //                    sb.Append(Utils.WriteConfigKey(_KeyPrimeExponentP, this.PrimeExponentP));
    //                    sb.Append(Utils.WriteConfigKey(_KeyPrimeExponentQ, this.PrimeExponentQ));
    //                    sb.Append(Utils.WriteConfigKey(_KeyCoefficient, this.Coefficient));
    //                    sb.Append(Utils.WriteConfigKey(_KeyPrivateExponent, this.PrivateExponent));
    //                }
    //                return sb.ToString();
    //            }

    //            /// <summary>
    //            /// Writes the *.config file representation of this private key to a file
    //            /// </summary>
    //            public void ExportToConfigFile(string strFilePath)
    //            {
    //                System.IO.StreamWriter sw = new System.IO.StreamWriter(strFilePath, false);
    //                sw.Write(this.ToConfigSection());
    //                sw.Close();
    //            }

    //            /// <summary>
    //            /// Loads the private key from its XML string
    //            /// </summary>
    //            public void LoadFromXml(string keyXml)
    //            {
    //                this.Modulus = Utils.GetXmlElement(keyXml, "Modulus");
    //                this.Exponent = Utils.GetXmlElement(keyXml, "Exponent");
    //                this.PrimeP = Utils.GetXmlElement(keyXml, "P");
    //                this.PrimeQ = Utils.GetXmlElement(keyXml, "Q");
    //                this.PrimeExponentP = Utils.GetXmlElement(keyXml, "DP");
    //                this.PrimeExponentQ = Utils.GetXmlElement(keyXml, "DQ");
    //                this.Coefficient = Utils.GetXmlElement(keyXml, "InverseQ");
    //                this.PrivateExponent = Utils.GetXmlElement(keyXml, "D");
    //            }

    //            /// <summary>
    //            /// System.Converts this private key to its XML string representation
    //            /// </summary>
    //            public string ToXml()
    //            {
    //                System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //                {
    //                    sb.Append(Utils.WriteXmlNode(_ElementParent));
    //                    sb.Append(Utils.WriteXmlElement(_ElementModulus, this.Modulus));
    //                    sb.Append(Utils.WriteXmlElement(_ElementExponent, this.Exponent));
    //                    sb.Append(Utils.WriteXmlElement(_ElementPrimeP, this.PrimeP));
    //                    sb.Append(Utils.WriteXmlElement(_ElementPrimeQ, this.PrimeQ));
    //                    sb.Append(Utils.WriteXmlElement(_ElementPrimeExponentP, this.PrimeExponentP));
    //                    sb.Append(Utils.WriteXmlElement(_ElementPrimeExponentQ, this.PrimeExponentQ));
    //                    sb.Append(Utils.WriteXmlElement(_ElementCoefficient, this.Coefficient));
    //                    sb.Append(Utils.WriteXmlElement(_ElementPrivateExponent, this.PrivateExponent));
    //                    sb.Append(Utils.WriteXmlNode(_ElementParent, true));
    //                }
    //                return sb.ToString();
    //            }

    //            /// <summary>
    //            /// Writes the Xml representation of this private key to a file
    //            /// </summary>
    //            public void ExportToXmlFile(string filePath)
    //            {
    //                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false);
    //                sw.Write(this.ToXml());
    //                sw.Close();
    //            }

    //        }

    //        #endregion

    //        /// <summary>
    //        /// Instantiates a new asymmetric encryption session using the default key size; 
    //        /// this is usally 1024 bits
    //        /// </summary>
    //        public Asymmetric()
    //        {
    //            _rsa = GetRSAProvider();
    //        }

    //        /// <summary>
    //        /// Instantiates a new asymmetric encryption session using a specific key size
    //        /// </summary>
    //        public Asymmetric(int keySize)
    //        {
    //            _KeySize = keySize;
    //            _rsa = GetRSAProvider();
    //        }

    //        /// <summary>
    //        /// Sets the name of the key container used to store this key on disk; this is an 
    //        /// unavoidable side effect of the underlying Microsoft CryptoAPI. 
    //        /// </summary>
    //        /// <remarks>
    //        /// http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q322/3/71.asp&amp;NoWebContent=1
    //        /// </remarks>
    //        public string KeyContainerName
    //        {
    //            get { return _KeyContainerName; }
    //            set { _KeyContainerName = value; }
    //        }

    //        /// <summary>
    //        /// Returns the current key size, in bits
    //        /// </summary>
    //        public int KeySizeBits
    //        {
    //            get { return _rsa.KeySize; }
    //        }

    //        /// <summary>
    //        /// Returns the maximum supported key size, in bits
    //        /// </summary>
    //        public int KeySizeMaxBits
    //        {
    //            get { return _rsa.LegalKeySizes[0].MaxSize; }
    //        }

    //        /// <summary>
    //        /// Returns the minimum supported key size, in bits
    //        /// </summary>
    //        public int KeySizeMinBits
    //        {
    //            get { return _rsa.LegalKeySizes[0].MinSize; }
    //        }

    //        /// <summary>
    //        /// Returns valid key step sizes, in bits
    //        /// </summary>
    //        public int KeySizeStepBits
    //        {
    //            get { return _rsa.LegalKeySizes[0].SkipSize; }
    //        }

    //        /// <summary>
    //        /// Returns the default public key as stored in the *.config file
    //        /// </summary>
    //        public PublicKey DefaultPublicKey
    //        {
    //            get
    //            {
    //                PublicKey pubkey = new PublicKey();
    //                pubkey.LoadFromConfig();
    //                return pubkey;
    //            }
    //        }

    //        /// <summary>
    //        /// Returns the default private key as stored in the *.config file
    //        /// </summary>
    //        public PrivateKey DefaultPrivateKey
    //        {
    //            get
    //            {
    //                PrivateKey privkey = new PrivateKey();
    //                privkey.LoadFromConfig();
    //                return privkey;
    //            }
    //        }

    //        /// <summary>
    //        /// Generates a new public/private key pair as objects
    //        /// </summary>
    //        public void GenerateNewKeyset(ref PublicKey publicKey, ref PrivateKey privateKey)
    //        {
    //            string PublicKeyXML = null;
    //            string PrivateKeyXML = null;
    //            GenerateNewKeyset(ref PublicKeyXML, ref PrivateKeyXML);
    //            publicKey = new PublicKey(PublicKeyXML);
    //            privateKey = new PrivateKey(PrivateKeyXML);
    //        }

    //        /// <summary>
    //        /// Generates a new public/private key pair as XML strings
    //        /// </summary>
    //        public void GenerateNewKeyset(ref string publicKeyXML, ref string privateKeyXML)
    //        {
    //            System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSACryptoServiceProvider.Create();
    //            publicKeyXML = rsa.ToXmlString(false);
    //            privateKeyXML = rsa.ToXmlString(true);
    //        }

    //        /// <summary>
    //        /// Encrypts data using the default public key
    //        /// </summary>
    //        public Data Encrypt(Data d)
    //        {
    //            PublicKey PublicKey = DefaultPublicKey;
    //            return Encrypt(d, PublicKey);
    //        }

    //        /// <summary>
    //        /// Encrypts data using the provided public key
    //        /// </summary>
    //        public Data Encrypt(Data d, PublicKey publicKey)
    //        {
    //            _rsa.ImportParameters(publicKey.ToParameters());
    //            return EncryptPrivate(d);
    //        }

    //        /// <summary>
    //        /// Encrypts data using the provided public key as XML
    //        /// </summary>
    //        public Data Encrypt(Data d, string publicKeyXML)
    //        {
    //            LoadKeyXml(publicKeyXML, false);
    //            return EncryptPrivate(d);
    //        }

    //        private Data EncryptPrivate(Data d)
    //        {
    //            try
    //            {
    //                return new Data(_rsa.Encrypt(d.Bytes, false));
    //            }
    //            catch (System.Security.Cryptography.CryptographicException ex)
    //            {
    //                if (ex.Message.ToLower().IndexOf("bad length") > -1)
    //                {
    //                    throw new System.Security.Cryptography.CryptographicException("Your data is too large; RSA encryption is designed to encrypt relatively small amounts of data. The exact byte limit depends on the key size. To encrypt more data, use symmetric encryption and then encrypt that symmetric key with asymmetric RSA encryption.", ex);
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //        }

    //        /// <summary>
    //        /// Decrypts data using the default private key
    //        /// </summary>
    //        public Data Decrypt(Data encryptedData)
    //        {
    //            PrivateKey PrivateKey = new PrivateKey();
    //            PrivateKey.LoadFromConfig();
    //            return Decrypt(encryptedData, PrivateKey);
    //        }

    //        /// <summary>
    //        /// Decrypts data using the provided private key
    //        /// </summary>
    //        public Data Decrypt(Data encryptedData, PrivateKey PrivateKey)
    //        {
    //            _rsa.ImportParameters(PrivateKey.ToParameters());
    //            return DecryptPrivate(encryptedData);
    //        }

    //        /// <summary>
    //        /// Decrypts data using the provided private key as XML
    //        /// </summary>
    //        public Data Decrypt(Data encryptedData, string PrivateKeyXML)
    //        {
    //            LoadKeyXml(PrivateKeyXML, true);
    //            return DecryptPrivate(encryptedData);
    //        }

    //        private void LoadKeyXml(string keyXml, bool isPrivate)
    //        {
    //            try
    //            {
    //                _rsa.FromXmlString(keyXml);
    //            }
    //            catch (System.Security.XmlSyntaxException ex)
    //            {
    //                string s = null;
    //                if (isPrivate)
    //                {
    //                    s = "private";
    //                }
    //                else
    //                {
    //                    s = "public";
    //                }
    //                throw new System.Security.XmlSyntaxException(string.Format("The provided {0} encryption key XML does not appear to be valid.", s), ex);
    //            }
    //        }

    //        private Data DecryptPrivate(Data encryptedData)
    //        {
    //            return new Data(_rsa.Decrypt(encryptedData.Bytes, false));
    //        }

    //        /// <summary>
    //        /// gets the default RSA provider using the specified key size; 
    //        /// note that Microsoft's CryptoAPI has an underlying file system dependency that is unavoidable
    //        /// </summary>
    //        /// <remarks>
    //        /// http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q322/3/71.asp&amp;NoWebContent=1
    //        /// </remarks>
    //        private System.Security.Cryptography.RSACryptoServiceProvider GetRSAProvider()
    //        {
    //            System.Security.Cryptography.RSACryptoServiceProvider rsa = null;
    //            System.Security.Cryptography.CspParameters csp = null;
    //            try
    //            {
    //                csp = new System.Security.Cryptography.CspParameters();
    //                csp.KeyContainerName = _KeyContainerName;
    //                rsa = new System.Security.Cryptography.RSACryptoServiceProvider(_KeySize, csp);
    //                rsa.PersistKeyInCsp = false;
    //                System.Security.Cryptography.RSACryptoServiceProvider.UseMachineKeyStore = true;
    //                return rsa;
    //            }
    //            catch (System.Security.Cryptography.CryptographicException ex)
    //            {
    //                if (ex.Message.ToLower().IndexOf("csp for this implementation could not be acquired") > -1)
    //                {
    //                    throw new System.Exception("Unable to obtain Cryptographic Service Provider. " + "Either the permissions are incorrect on the " + "'C:\\Documents and Settings\\All Users\\Application Data\\Microsoft\\Crypto\\RSA\\MachineKeys' " + "folder, or the current security context '" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "'" + " does not have Principal to this folder.", ex);
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            finally
    //            {
    //                if ((rsa != null))
    //                {
    //                    rsa = null;
    //                }
    //                if ((csp != null))
    //                {
    //                    csp = null;
    //                }
    //            }
    //        }

    //    }

    //    #endregion

    //    #region " Data"

    //    /// <summary>
    //    /// represents Hex, Byte, Base64, or String data to encrypt/decrypt;
    //    /// use the .Text property to set/get a string representation 
    //    /// use the .Hex property to set/get a string-based Hexadecimal representation 
    //    /// use the .Base64 to set/get a string-based Base64 representation 
    //    /// </summary>
    //    public class Data
    //    {
    //        private byte[] _b;
    //        private int _MaxBytes = 0;
    //        private int _MinBytes = 0;
    //        private int _StepBytes = 0;

    //        /// <summary>
    //        /// Determines the default text encoding across ALL Data instances
    //        /// </summary>
    //        public static System.Text.Encoding DefaultEncoding = System.Text.Encoding.GetEncoding("Windows-1252");

    //        /// <summary>
    //        /// Determines the default text encoding for this Data instance
    //        /// </summary>
    //        public System.Text.Encoding Encoding = DefaultEncoding;

    //        /// <summary>
    //        /// Creates new, empty encryption data
    //        /// </summary>
    //        public Data()
    //        {
    //        }

    //        /// <summary>
    //        /// Creates new encryption data with the specified byte System.Array
    //        /// </summary>
    //        public Data(byte[] b)
    //        {
    //            _b = b;
    //        }

    //        /// <summary>
    //        /// Creates new encryption data with the specified string; 
    //        /// will be System.Converted to byte System.Array using default encoding
    //        /// </summary>
    //        public Data(string s)
    //        {
    //            this.Text = s;
    //        }

    //        /// <summary>
    //        /// Creates new encryption data using the specified string and the 
    //        /// specified encoding to System.Convert the string to a byte System.Array.
    //        /// </summary>
    //        public Data(string s, System.Text.Encoding encoding)
    //        {
    //            this.Encoding = encoding;
    //            this.Text = s;
    //        }

    //        /// <summary>
    //        /// returns true if no data is present
    //        /// </summary>
    //        public bool IsEmpty
    //        {
    //            get
    //            {
    //                if (_b == null)
    //                {
    //                    return true;
    //                }
    //                if (_b.Length == 0)
    //                {
    //                    return true;
    //                }
    //                return false;
    //            }
    //        }

    //        /// <summary>
    //        /// allowed step interval, in bytes, for this data; if 0, no limit
    //        /// </summary>
    //        public int StepBytes
    //        {
    //            get { return _StepBytes; }
    //            set { _StepBytes = value; }
    //        }

    //        /// <summary>
    //        /// allowed step interval, in bits, for this data; if 0, no limit
    //        /// </summary>
    //        public int StepBits
    //        {
    //            get { return _StepBytes * 8; }
    //            set { _StepBytes = value / 8; }
    //        }

    //        /// <summary>
    //        /// minimum number of bytes allowed for this data; if 0, no limit
    //        /// </summary>
    //        public int MinBytes
    //        {
    //            get { return _MinBytes; }
    //            set { _MinBytes = value; }
    //        }

    //        /// <summary>
    //        /// minimum number of bits allowed for this data; if 0, no limit
    //        /// </summary>
    //        public int MinBits
    //        {
    //            get { return _MinBytes * 8; }
    //            set { _MinBytes = value / 8; }
    //        }

    //        /// <summary>
    //        /// maximum number of bytes allowed for this data; if 0, no limit
    //        /// </summary>
    //        public int MaxBytes
    //        {
    //            get { return _MaxBytes; }
    //            set { _MaxBytes = value; }
    //        }

    //        /// <summary>
    //        /// maximum number of bits allowed for this data; if 0, no limit
    //        /// </summary>
    //        public int MaxBits
    //        {
    //            get { return _MaxBytes * 8; }
    //            set { _MaxBytes = value / 8; }
    //        }

    //        /// <summary>
    //        /// Returns the byte representation of the data; 
    //        /// This will be padded to MinBytes and trimmed to MaxBytes as necessary!
    //        /// </summary>
    //        public byte[] Bytes
    //        {
    //            get
    //            {
    //                if (_MaxBytes > 0)
    //                {
    //                    if (_b.Length > _MaxBytes)
    //                    {
    //                        byte[] b = new byte[_MaxBytes];
    //                        System.Array.Copy(_b, b, b.Length);
    //                        _b = b;
    //                    }
    //                }
    //                if (_MinBytes > 0)
    //                {
    //                    if (_b.Length < _MinBytes)
    //                    {
    //                        byte[] b = new byte[_MinBytes];
    //                        System.Array.Copy(_b, b, _b.Length);
    //                        _b = b;
    //                    }
    //                }
    //                return _b;
    //            }
    //            set { _b = value; }
    //        }

    //        /// <summary>
    //        /// Sets or returns text representation of bytes using the default text encoding
    //        /// </summary>
    //        public string Text
    //        {
    //            get
    //            {
    //                if (_b == null)
    //                {
    //                    return "";
    //                }
    //                else
    //                {
    //                    //-- need to handle nulls here; oddly, C# will happily System.Convert
    //                    //-- nulls into the string whereas VB stops System.Converting at the
    //                    //-- first null!
    //                    int i = System.Array.IndexOf(_b, (byte)0);
    //                    if (i >= 0)
    //                    {
    //                        return this.Encoding.GetString(_b, 0, i);
    //                    }
    //                    else
    //                    {
    //                        return this.Encoding.GetString(_b);
    //                    }
    //                }
    //            }
    //            set { _b = this.Encoding.GetBytes(value); }
    //        }

    //        /// <summary>
    //        /// Sets or returns Hex string representation of this data
    //        /// </summary>
    //        public string Hex
    //        {
    //            get { return Utils.ToHex(_b); }
    //            set { _b = Utils.FromHex(value); }
    //        }

    //        /// <summary>
    //        /// Sets or returns Base64 string representation of this data
    //        /// </summary>
    //        public string Base64
    //        {
    //            get { return Utils.ToBase64(_b); }
    //            set { _b = Utils.FromBase64(value); }
    //        }

    //        /// <summary>
    //        /// Returns text representation of bytes using the default text encoding
    //        /// </summary>
    //        public new string ToString()
    //        {
    //            return this.Text;
    //        }

    //        /// <summary>
    //        /// returns Base64 string representation of this data
    //        /// </summary>
    //        public string ToBase64()
    //        {
    //            return this.Base64;
    //        }

    //        /// <summary>
    //        /// returns Hex string representation of this data
    //        /// </summary>
    //        public string ToHex()
    //        {
    //            return this.Hex;
    //        }

    //    }

    //    #endregion

    //    #region " Utils"

    //    /// <summary>
    //    /// Friend class for shared utility methods used by multiple Encryption classes
    //    /// </summary>
    //    internal class Utils
    //    {

    //        /// <summary>
    //        /// System.Converts an System.Array of bytes to a string Hex representation
    //        /// </summary>
    //        static internal string ToHex(byte[] ba)
    //        {
    //            if (ba == null || ba.Length == 0)
    //            {
    //                return "";
    //            }
    //            const string HexFormat = "{0:X2}";
    //            System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //            foreach (byte b in ba)
    //            {
    //                sb.Append(string.Format(HexFormat, b));
    //            }
    //            return sb.ToString();
    //        }

    //        /// <summary>
    //        /// System.Converts from a string Hex representation to an System.Array of bytes
    //        /// </summary>
    //        static internal byte[] FromHex(string hexEncoded)
    //        {
    //            if (hexEncoded == null || hexEncoded.Length == 0)
    //            {
    //                return null;
    //            }
    //            try
    //            {
    //                int l = System.Convert.ToInt32(hexEncoded.Length / 2);
    //                byte[] b = new byte[l];
    //                for (int i = 0; i <= l - 1; i++)
    //                {
    //                    b[i] = System.Convert.ToByte(hexEncoded.Substring(i * 2, 2), 16);
    //                }
    //                return b;
    //            }
    //            catch (System.Exception ex)
    //            {
    //                throw new System.FormatException("The provided string does not appear to be Hex encoded:" + System.Environment.NewLine + hexEncoded + System.Environment.NewLine, ex);
    //            }
    //        }

    //        /// <summary>
    //        /// System.Converts from a string Base64 representation to an System.Array of bytes
    //        /// </summary>
    //        static internal byte[] FromBase64(string base64Encoded)
    //        {
    //            if (base64Encoded == null || base64Encoded.Length == 0)
    //            {
    //                return null;
    //            }
    //            try
    //            {
    //                return System.Convert.FromBase64String(base64Encoded);
    //            }
    //            catch (System.FormatException ex)
    //            {
    //                throw new System.FormatException("The provided string does not appear to be Base64 encoded:" + System.Environment.NewLine + base64Encoded + System.Environment.NewLine, ex);
    //            }
    //        }

    //        /// <summary>
    //        /// System.Converts from an System.Array of bytes to a string Base64 representation
    //        /// </summary>
    //        static internal string ToBase64(byte[] b)
    //        {
    //            if (b == null || b.Length == 0)
    //            {
    //                return "";
    //            }
    //            return System.Convert.ToBase64String(b);
    //        }

    //        /// <summary>
    //        /// retrieve an element from an XML string
    //        /// </summary>
    //        static internal string GetXmlElement(string xml, string element)
    //        {
    //            System.Text.RegularExpressions.Match m = default(System.Text.RegularExpressions.Match);
    //            m = System.Text.RegularExpressions.Regex.Match(xml, "<" + element + ">(?<Element>[^>]*)</" + element + ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    //            if (m == null)
    //            {
    //                throw new System.Exception("Could not find <" + element + "></" + element + "> in provided Public Key XML.");
    //            }
    //            return m.Groups["Element"].ToString();
    //        }

    //        /// <summary>
    //        /// Returns the specified string value from the application .config file
    //        /// </summary>
    //        static internal string GetConfigString(string key)
    //        {
    //            return GetConfigString(key, true);
    //        }

    //        /// <summary>
    //        /// Overloaded method returns the specified string value from the application .config file
    //        /// </summary>
    //        static internal string GetConfigString(string key, bool isRequired)
    //        {
    //            string s = (string)System.Configuration.ConfigurationManager.AppSettings.Get(key);
    //            if (s == null)
    //            {
    //                if (isRequired)
    //                {
    //                    throw new System.Configuration.ConfigurationErrorsException("key <" + key + "> is missing from .config file");
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            else
    //            {
    //                return s;
    //            }
    //        }

    //        static internal string WriteConfigKey(string key, string value)
    //        {
    //            string s = "<add key=\"{0}\" value=\"{1}\" />" + System.Environment.NewLine;
    //            return string.Format(s, key, value);
    //        }

    //        static internal string WriteXmlElement(string element, string value)
    //        {
    //            string s = "<{0}>{1}</{0}>" + System.Environment.NewLine;
    //            return string.Format(s, element, value);
    //        }

    //        static internal string WriteXmlNode(string element)
    //        {
    //            return WriteXmlNode(element, false);
    //        }

    //        static internal string WriteXmlNode(string element, bool isClosing)
    //        {
    //            string s = null;
    //            if (isClosing)
    //            {
    //                s = "</{0}>" + System.Environment.NewLine;
    //            }
    //            else
    //            {
    //                s = "<{0}>" + System.Environment.NewLine;
    //            }
    //            return string.Format(s, element);
    //        }

    //    }
    //    #endregion
    //}
    //#endregion

    //public class clsVerificarConexao
    //{
    //    private string strEnderecoProxy;
    //    private string strPortaProxy;
    //    private string strUsuarioProxy;
    //    private string strSenhaProxy;
    //    private string strDominioProxy;

    //    public string prpEnderecoProxy
    //    {
    //        get
    //        {
    //            return strEnderecoProxy;
    //        }
    //        set
    //        {
    //            strEnderecoProxy = value;
    //        }
    //    }

    //    public string prpPortaProxy
    //    {
    //        get
    //        {
    //            return strPortaProxy;
    //        }
    //        set
    //        {
    //            strPortaProxy = value;
    //        }
    //    }

    //    public string prpUsuarioProxy
    //    {
    //        get
    //        {
    //            return strUsuarioProxy;
    //        }
    //        set
    //        {
    //            strUsuarioProxy = value;
    //        }
    //    }

    //    public string prpSenhaProxy
    //    {
    //        get
    //        {
    //            return strSenhaProxy;
    //        }
    //        set
    //        {
    //            strSenhaProxy = value;
    //        }
    //    }

    //    public string prpDominioProxy
    //    {
    //        get
    //        {
    //            return strDominioProxy;
    //        }
    //        set
    //        {
    //            strDominioProxy = value;
    //        }
    //    }

    //    public System.Net.WebProxy mtdAjustarPoxy()
    //    {
    //        return mtdAjustarPoxy
    //                 (
    //                 strEnderecoProxy,
    //                 strPortaProxy,
    //                 strUsuarioProxy,
    //                 strSenhaProxy,
    //                 strDominioProxy
    //                 );
    //    }

    //    public System.Net.WebProxy mtdAjustarPoxy
    //     (
    //     string EnderecoProxy,
    //     string PortaProxy,
    //     string UsuarioProxy,
    //     string SenhaProxy,
    //     string DominioProxy
    //     )
    //    {
    //        System.Net.WebProxy Proxy = new System.Net.WebProxy();
    //        System.Net.CredentialCache Cache = new System.Net.CredentialCache();

    //        string strTipoAutenticacao = "Digest";

    //        Cache.Add
    //            (
    //            new System.Uri
    //                (
    //                string.Format(@"{0}:{1}", EnderecoProxy, PortaProxy)
    //                ),
    //            strTipoAutenticacao,
    //            new System.Net.NetworkCredential
    //                (
    //                UsuarioProxy,
    //                SenhaProxy,
    //                DominioProxy
    //                )
    //            );

    //        Proxy.Credentials = Cache;

    //        return Proxy;
    //    }

    //    public bool mtdChecarInternet(string EntradaHost)
    //    {
    //        bool saida = false;

    //        try
    //        {
    //            System.Net.WebRequest objRequest = System.Net.WebRequest.Create(new System.Uri(EntradaHost));
    //            objRequest.Proxy = mtdAjustarPoxy();

    //            saida = true;
    //        }
    //        catch (System.Exception ex)
    //        {
    //            string strExcecao = "mtdChecarInternet: " + ex.Message;
    //            System.Diagnostics.Debug.WriteLine(strExcecao);
    //            frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

    //            saida = false;
    //        }

    //        return saida;
    //    }

    //    public bool mtdChecarRede(string EntradaHost)
    //    {
    //        bool saida = false;

    //        try
    //        {
    //            System.Net.IPHostEntry oIPHostEntry = System.Net.Dns.GetHostEntry(EntradaHost);

    //            saida = true;
    //        }
    //        catch (System.Exception ex)
    //        {
    //            string strExcecao = "mtdChecarRede: " + ex.Message;
    //            System.Diagnostics.Debug.WriteLine(strExcecao);
    //            frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);

    //            saida = false;
    //        }

    //        return saida;
    //    }
    //}

    //public class clsDataTempoSistema
    //{
    //    [System.Runtime.InteropServices.DllImport("coredll.dll")]
    //    private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);
    //    [System.Runtime.InteropServices.DllImport("coredll.dll")]
    //    private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

    //    private struct SYSTEMTIME
    //    {
    //        public ushort wYear;
    //        public ushort wMonth;
    //        public ushort wDayOfWeek;
    //        public ushort wDay;
    //        public ushort wHour;
    //        public ushort wMinute;
    //        public ushort wSecond;
    //        public ushort wMilliseconds;
    //    }

    //    public static void mtdObterDataTempoSistema(ref System.DateTime DataTempoSistema)
    //    {
    //        SYSTEMTIME Now = new SYSTEMTIME();

    //        GetSystemTime(ref Now);

    //        DataTempoSistema = new System.DateTime
    //            (
    //            Now.wYear,
    //            Now.wMonth,
    //            Now.wDay,
    //            Now.wHour,
    //            Now.wMinute,
    //            Now.wSecond,
    //            Now.wMilliseconds
    //            );
    //    }

    //    public static void mtdAjustarDataTempoSistema(ref System.DateTime DataTempoSistema)
    //    {
    //        SYSTEMTIME Now = new SYSTEMTIME();

    //        GetSystemTime(ref Now);

    //        Now.wYear = System.Convert.ToUInt16(DataTempoSistema.Year);
    //        Now.wMonth = System.Convert.ToUInt16(DataTempoSistema.Month);
    //        Now.wDay = System.Convert.ToUInt16(DataTempoSistema.Day);
    //        Now.wHour = System.Convert.ToUInt16(DataTempoSistema.Hour);
    //        Now.wMinute = System.Convert.ToUInt16(DataTempoSistema.Minute);
    //        Now.wSecond = System.Convert.ToUInt16(DataTempoSistema.Second);
    //        Now.wMilliseconds = System.Convert.ToUInt16(DataTempoSistema.Millisecond);

    //        SetSystemTime(ref Now);
    //    }

    //    private static System.Net.WebProxy wp = null;

    //    public static void mtdAjustarProxy
    //        (
    //        string Host,
    //        int Porta,
    //        string NomeUsuario,
    //        string Senha,
    //        string Dominio
    //        )
    //    {
    //        wp = new System.Net.WebProxy(Host, Porta);
    //        wp.Credentials = new System.Net.NetworkCredential(NomeUsuario, Senha, Dominio);
    //    }

    //    private static string strEnderecoInternet = "http://www.timeapi.org/utc/now";
    //    private static string strEnderecoRede = string.Empty;

    //    public string prpEnderecoInternet
    //    {
    //        get
    //        {
    //            return strEnderecoInternet;
    //        }
    //        set
    //        {
    //            strEnderecoInternet = value;
    //        }
    //    }

    //    public string prpEnderecoRede
    //    {
    //        get
    //        {
    //            return strEnderecoRede;
    //        }
    //        set
    //        {
    //            strEnderecoRede = value;
    //        }
    //    }

    //    public static bool mtdAjustarDataTempoSistema()
    //    {
    //        return mtdAjustarDataTempoSistema(strEnderecoInternet, strEnderecoRede, false);
    //    }

    //    public static bool mtdAjustarDataTempoSistema(string EnderecoRede)
    //    {
    //        strEnderecoRede = EnderecoRede;

    //        return mtdAjustarDataTempoSistema(strEnderecoInternet, EnderecoRede, true);
    //    }

    //    public static bool mtdAjustarDataTempoSistema(string EnderecoInternet, string EnderecoRede, bool ForcarWebService)
    //    {
    //        bool saida = false;

    //        strEnderecoInternet = EnderecoInternet;
    //        strEnderecoRede = EnderecoRede;

    //        try
    //        {
    //            SYSTEMTIME Now = new SYSTEMTIME();

    //            clsVerificarConexao objVerificarConexao = new clsVerificarConexao();

    //            if (objVerificarConexao.mtdChecarInternet(EnderecoInternet) && !ForcarWebService)
    //            {
    //                byte[] Buffer = new byte[25];
    //                string DateString;
    //                string[] DateItems = new string[8];
    //                char[] Separators = new char[7] { '-', '-', 'T', ':', ':', '+', ':' };

    //                GetSystemTime(ref Now);

    //                System.Uri uri = new System.Uri(strEnderecoInternet);

    //                System.IO.Stream ResponseStream = System.Net.WebRequest.Create(uri).GetResponse().GetResponseStream();

    //                ResponseStream.Read(Buffer, 0, 25);
    //                ResponseStream.Close();
    //                DateString = System.Text.Encoding.UTF8.GetString(Buffer, 0, 25);
    //                DateItems = DateString.Split(Separators);
    //                Now.wYear = System.Convert.ToUInt16(DateItems[0]);
    //                Now.wMonth = System.Convert.ToUInt16(DateItems[1]);
    //                Now.wDay = System.Convert.ToUInt16(DateItems[2]);
    //                Now.wHour = System.Convert.ToUInt16(DateItems[3]);
    //                Now.wMinute = System.Convert.ToUInt16(DateItems[4]);
    //                Now.wSecond = System.Convert.ToUInt16(DateItems[5]);
    //                Now.wMilliseconds = 0;
    //            }
    //            else
    //            {
    //                Program.objPrincipal.objWebServiceInspecao.Url = strEnderecoRede;

    //                Now.wYear = System.Convert.ToUInt16(Program.objPrincipal.objWebServiceInspecao.mtdObterDataTempoSistemaUtc().Year);
    //                Now.wMonth = System.Convert.ToUInt16(Program.objPrincipal.objWebServiceInspecao.mtdObterDataTempoSistemaUtc().Month);
    //                Now.wDay = System.Convert.ToUInt16(Program.objPrincipal.objWebServiceInspecao.mtdObterDataTempoSistemaUtc().Day);
    //                Now.wHour = System.Convert.ToUInt16(Program.objPrincipal.objWebServiceInspecao.mtdObterDataTempoSistemaUtc().Hour);
    //                Now.wMinute = System.Convert.ToUInt16(Program.objPrincipal.objWebServiceInspecao.mtdObterDataTempoSistemaUtc().Minute);
    //                Now.wSecond = System.Convert.ToUInt16(Program.objPrincipal.objWebServiceInspecao.mtdObterDataTempoSistemaUtc().Second);
    //                Now.wMilliseconds = System.Convert.ToUInt16(Program.objPrincipal.objWebServiceInspecao.mtdObterDataTempoSistemaUtc().Millisecond);

    //                Program.objPrincipal.objWebServiceInspecao.Dispose();
    //            }

    //            SetSystemTime(ref Now);
    //            saida = true;
    //        }
    //        catch
    //        {
    //            saida = false;
    //            //System.Windows.Forms.MessageBox.Show(ex.Message);
    //        }

    //        return saida;
    //    }
    //}

    //public class clsShutdownDevice
    //{
    //    private const uint FILE_DEVICE_HAL = 0x00000101;
    //    private const uint METHOD_BUFFERED = 0;
    //    private const uint FILE_ANY_ACCESS = 0;

    //    private const int POWER_STATE_ON = 0x00010000;
    //    private const int POWER_STATE_OFF = 0x00020000;
    //    private const int POWER_STATE_SUSPEND = 0x00200000;
    //    private const int POWER_FORCE = 4096;
    //    private const int POWER_STATE_RESET = 0x00800000;

    //    private static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
    //    {
    //        return ((DeviceType << 16) | (Access << 14) | (Function << 2) | Method);
    //    }

    //    [System.Runtime.InteropServices.DllImport("coredll.dll")]
    //    private extern static uint SetSystemPowerState
    //    (
    //        System.String psState,
    //        System.Int32 StateFlags,
    //        System.Int32 Options
    //    );

    //    [System.Runtime.InteropServices.DllImport("coredll.dll")]
    //    private extern static uint KernelIoControl
    //    (
    //        uint dwIoControlCode,
    //        System.IntPtr lpInBuf,
    //        uint nInBufSize,
    //        System.IntPtr lpOutBuf,
    //        uint nOutBufSize,
    //        ref uint lpBytesReturned
    //    );

    //    [System.Runtime.InteropServices.DllImport("coredll.dll")]
    //    private extern static void SetCleanRebootFlag();

    //    [System.Runtime.InteropServices.DllImport("aygshell.dll", SetLastError = true)]
    //    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    //    private static extern bool ExitWindowsEx([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]uint dwFlags, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]uint dwReserved);

    //    private enum ExitWindowsAction : uint
    //    {
    //        EWX_LOGOFF = 0,
    //        EWX_SHUTDOWN = 1,
    //        EWX_REBOOT = 2,
    //        EWX_FORCE = 4,
    //        EWX_POWEROFF = 8
    //    }

    //    public static uint mtdForcePowerOff()
    //    {
    //        uint uintRetorno = 0;

    //        try
    //        {
    //            uintRetorno = SetSystemPowerState(null, POWER_STATE_OFF, POWER_FORCE);
    //        }
    //        catch (System.Exception ex)
    //        {
    //            string strExcecao = "mtdForcePowerOff: " + ex.Message;
    //            System.Diagnostics.Debug.WriteLine(strExcecao);
    //            //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
    //        }

    //        return uintRetorno;
    //    }

    //    public static uint mtdColdReset()
    //    {
    //        uint uintRetorno = 0;

    //        try
    //        {
    //            SetCleanRebootFlag();
    //            uintRetorno = SetSystemPowerState(null, POWER_STATE_RESET, POWER_FORCE);
    //        }
    //        catch (System.Exception ex)
    //        {
    //            string strExcecao = "mtdColdReset: " + ex.Message;
    //            System.Diagnostics.Debug.WriteLine(strExcecao);
    //            //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
    //        }

    //        return uintRetorno;
    //    }

    //    /// <summary>
    //    /// Causes the CE device to soft/warm reset
    //    /// </summary>
    //    public static uint mtdSoftReset()
    //    {
    //        uint uintRetorno = 0;

    //        try
    //        {
    //            uint bytesReturned = 0;
    //            uint IOCTL_HAL_REBOOT = CTL_CODE(FILE_DEVICE_HAL, 15, METHOD_BUFFERED, FILE_ANY_ACCESS);
    //            SetCleanRebootFlag();

    //            uintRetorno = KernelIoControl(IOCTL_HAL_REBOOT, System.IntPtr.Zero, 0, System.IntPtr.Zero, 0, ref bytesReturned);
    //        }
    //        catch (System.Exception ex)
    //        {
    //            string strExcecao = "mtdColdReset: " + ex.Message;
    //            System.Diagnostics.Debug.WriteLine(strExcecao);
    //            //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
    //        }

    //        return uintRetorno;
    //    }

    //    //public static uint mtdSoftReset()
    //    //{
    //    //    // Though I guess this will never really return anything
    //    //    return SetSystemPowerState(null, POWER_STATE_RESET, POWER_FORCE);
    //    //}

    //    public static uint mtdHardReset()
    //    {
    //        uint uintRetorno = 0;

    //        try
    //        {
    //            int IOCTL_HAL_REBOOT = 0x101003C;
    //            uint bytesReturned = 0;
    //            SetCleanRebootFlag();
    //            uintRetorno = KernelIoControl((uint)IOCTL_HAL_REBOOT, System.IntPtr.Zero, 0, System.IntPtr.Zero, 0, ref bytesReturned);
    //        }
    //        catch (System.Exception ex)
    //        {
    //            string strExcecao = "mtdColdReset: " + ex.Message;
    //            System.Diagnostics.Debug.WriteLine(strExcecao);
    //            //frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
    //        }

    //        return uintRetorno;
    //    }
    //}
}