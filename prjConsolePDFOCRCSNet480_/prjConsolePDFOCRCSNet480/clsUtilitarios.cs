using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjConsolePDFOCRCSNet480
{
    internal class clsUtilitarios
    {
        public string mtdMaiusculo(string Texto)
        {
            return Texto.ToUpper();
        }

        public string mtdMinusculo(string Texto)
        {
            return Texto.ToLower();
        }

        public string mtdRetirarAcentos(string Texto)
        {
            string Retorno = string.Empty;

            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= Texto.Length - 1; i++)
            {
                chrCarac = System.Convert.ToChar(Texto.Substring(i, 1));
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

            Retorno = strTextoTemporario;

            return Retorno;
        }

        public string mtdRetirarCaractereInvalido(string Texto)
        {
            string Retorno = string.Empty;

            // char chrCarac = '\0';
            char chrCarac = ' ';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= Texto.Length - 1; i++)
            {
                chrCarac = System.Convert.ToChar(Texto.Substring(i, 1));
                Index = System.Convert.ToInt32(chrCarac);
                if 
                    (!(
                        Index == 34 | 
                        Index == 39 | 
                        Index == (int)'-' | 
                        Index == (int)'/' | 
                        Index == (int)'.' | 
                        Index == (int)',' | 
                        Index == (int)'(' | 
                        Index == (int)')' |
                        Index == (int)'\n' |
                        Index == (int)'\r' |
                        Index == (int)'\t' 
                    ))
                {
                    strTextoTemporario += chrCarac;
                }
                else
                {
                    strTextoTemporario += System.Convert.ToChar(32);
                }
            }
            Retorno = strTextoTemporario.Trim();
            return Retorno;
        }
       
        public string mtdRetirarEspacoExtra(string Texto)
        {
            string Retorno = string.Empty;

            bool Verificador = false;
            char chrCarac = '\0';
            int Index = 0;
            string strTextoTemporario = string.Empty;
            for (int i = 0; i <= Texto.Length - 1; i += 1)
            {
                chrCarac = System.Convert.ToChar(Texto.Substring(i, 1));
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
            Retorno = strTextoTemporario.Trim();

            return Retorno;
        }

        public string mtdExecutarTudo(string Texto)
        {
            return mtdMaiusculo(mtdRetirarAcentos(mtdRetirarEspacoExtra(mtdRetirarCaractereInvalido(Texto))));
        }
    }
}
