# Coletor de Dados Intermec para Windows Mobile 6.5

Sistema desenvolvido em C# utilizando .NET Framework 3.5 para coletores de dados Intermec/Honeywell com Windows Mobile 6.5, voltado para operações de coleta móvel, inventário patrimonial, automação logística e sincronização corporativa de dados.

O projeto foi criado para execução em dispositivos industriais móveis da linha Intermec, permitindo coleta de informações em campo através de leitura de código de barras, armazenamento local, sincronização remota e integração com sistemas corporativos.

A solução possui suporte a comunicação via WebService e FTP, permitindo transferência de arquivos, sincronização de bases de dados e envio/recebimento de informações entre o coletor móvel e servidores corporativos.

---

## ✨ Principais Recursos

- Coleta de dados em dispositivos móveis industriais
- Leitura integrada de código de barras
- Compatibilidade com Windows Mobile 6.5
- Integração com SDKs Intermec/Honeywell
- Operação offline com armazenamento local
- Upload e download de dados
- Transferência de arquivos via FTP
- Transferência de bases de dados
- Integração com WebServices corporativos
- Sincronização híbrida via FTP e WebService
- Processamento estruturado das coletas
- Estrutura modular em C#

---

## 📦 Funcionalidades

O sistema permite:

- captura rápida de informações em campo;
- leitura automatizada de códigos de barras;
- armazenamento local de registros;
- sincronização entre dispositivo e servidor;
- transferência de arquivos via FTP;
- envio e recebimento de bases de dados;
- integração com WebServices corporativos;
- sincronização híbrida via FTP e WebService;
- automação de processos patrimoniais e logísticos;
- suporte a inventários e auditorias;
- organização estruturada das informações coletadas.

---

## 🏗️ Estrutura do Projeto

O projeto foi organizado de forma modular para facilitar manutenção e expansão.

### Componentes Principais

| Componente | Função |
|---|---|
| `Program.cs` | Inicialização da aplicação |
| `ColetorDados.cs` | Rotinas principais de coleta |
| `LeitorCodigoBarras.cs` | Integração com scanner |
| `SincronizacaoFTP.cs` | Transferência de arquivos via FTP |
| `IntegracaoWebService.cs` | Comunicação com WebServices |
| `Configuracao.cs` | Configurações do sistema |
| `Util.cs` | Funções auxiliares |
| `Bibliotecas/itc` | SDKs Intermec |
| `Bibliotecas/hsm` | Bibliotecas Honeywell |

---

## 🔧 Tecnologias Utilizadas

- C#
- .NET Framework 3.5
- Windows Mobile 6.5
- Windows Forms
- Intermec SDK
- Honeywell Embedded SDK
- FTP
- WebServices
- Manipulação de Arquivos
- Programação Orientada a Objetos

---

## 📱 Ambiente de Execução

O sistema foi desenvolvido para:

- coletores industriais Intermec;
- dispositivos móveis corporativos;
- operações logísticas;
- inventários patrimoniais;
- sincronização corporativa de dados;
- transmissão remota de arquivos;
- ambientes industriais e operacionais.

---

## 📂 Estrutura Geral

Arquivos identificados no projeto:

- `AC_Backup.bmp`
- `AC_Offline.bmp`
- `AC_Online.bmp`
- `AC_Unknown.bmp`
- `AssemblyInfo.cs`
- `Barcode.ico`
- `Battery.pdn`
- `BatteryStatus.ico`
- `Battery_Charging.bmp`
- `Battery_Charging.pdn`
- `Battery_Charging_Original.bmp`
- `Battery_Critical.bmp`
- `Battery_Critical_Original.bmp`
- `Battery_High.bmp`
- `Battery_Low.bmp`
- `Battery_No_Battery.bmp`
- `Battery_No_Battery.pdn`
- `Battery_Unknown.bmp`
- `Compas.cs`
- `Compas.designer.cs`
- `DistanceCalculator.cs`
- `Enums.cs`
- `FTP.cs`
- `FTPException.cs`
- `FTPFile.cs`
- `FTPFiles.cs`
- `HSM.Embedded.Decoding.DecodeAssembly.dll`
- `HSM.Embedded.Decoding.DecodeAssembly.xml`
- `HSM.Embedded.Imaging.CameraAssembly.dll`
- `HSM.Embedded.Imaging.CameraAssembly.xml`
- `HSM.Embedded.Utility.SystemNotificationAssembly.dll`
- `HSM.Embedded.Utility.SystemNotificationAssembly.xml`
- `HSM.Embedded.UtilityAssembly.dll`
- `HSM.Embedded.UtilityAssembly.xml`
- `HSM.Embedded.Wireless.NetworkAssembly.dll`
- `HSM.Embedded.Wireless.NetworkAssembly.xml`
- `HSM.Embedded.WirelessAssembly.dll`
- `HSM.Embedded.WirelessAssembly.xml`
- `ITC.Embedded.Camera.dll`
- `ITC.Embedded.Decoding.dll`
- `ITC.Embedded.Utility.dll`
- `ITC.Embedded.WirelessAssembly.dll`
- `ITCCamera.dll`
- `ITCImager.dll`
- `ITCScan.dll`
- `Intermec.DataCollection.CF3.5.dll`
- `Intermec.DeviceManagement.SmartSystem.ITCSSApi.dll`
- `Intermec.Multimedia.Camera.CF35.dll`
- `MS.Embedded.Wireless.Network.dll`
- `Microsoft.WindowsMobile.Forms.dll`
- `Microsoft.WindowsMobile.PocketOutlook.dll`
- `Microsoft.WindowsMobile.PocketOutlook.xml`
- `Microsoft.WindowsMobile.Samples.Location.dll`
- `Microsoft.WindowsMobile.Status.dll`
- `Microsoft.WindowsMobile.dll`
- `Microsoft.Windowsce.Forms.dll`
- `Program.cs`
- `Reference.cs`
- `Reference.map`
- `ResolveAssemblyReference.cache`
- `Resources.Designer.cs`
- `Resources.resx`
- `System.Data.SqlServerCe.dll`
- `Web References.WebService.Reference.cs.dll`
- `Web References.WebService1.Reference.cs.dll`
- `Web References.WebServicoBancoDados.Reference.cs.dll`
- `WebServicoBancoDados.disco`
- `WebServicoBancoDados.wsdl`
- `Win32.dll`
- `clsAjustarDataHoraSistema.cs`
- `clsBDSQLServerCE.cs`
- `clsBancoDados.cs`
- `clsConexaoBancoDados.cs`
- `clsImplementacaoBancoDados.cs`
- `clsSendMail.cs`
- `clsUtilitarios.cs`
- `db2hc.ico`
- `frmAlterarDeletarItem.cs`
- `frmAlterarDeletarItem.designer.cs`
- `frmAlterarDeletarItem.resx`

---

## 📊 Objetivos do Projeto

O projeto foi desenvolvido para:

- automatizar processos de coleta móvel;
- reduzir erros operacionais;
- agilizar inventários patrimoniais;
- integrar coletores móveis com sistemas corporativos;
- sincronizar arquivos e bases de dados;
- facilitar transmissão remota de informações;
- estruturar operações móveis industriais.

---

## 🚀 Melhorias Futuras

- Compatibilidade com Android Industrial
- API REST para sincronização
- Criptografia avançada de dados
- Dashboard administrativo
- Logs centralizados
- Processamento em tempo real
- Integração com protocolos modernos de transferência
- Sincronização online automática

---

## 📄 Licença

Projeto desenvolvido para automação corporativa, inventário patrimonial e aplicações móveis industriais utilizando C# e Windows Mobile.
