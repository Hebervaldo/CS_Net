//using System;
//using System.Collections.Generic;
//using System.Web;

//namespace WebServiceCSNet40
//{
//    public partial class clsMonitoramento
//    {
//        private System.Text.StringBuilder m_Sb;
//        private bool m_bDirty = false;
//        private System.IO.FileSystemWatcher m_Watcher;
//        public bool m_bIsWatching;

//        public bool mtdMonitorarDiretorioArquivo()
//        {
//            if (m_bIsWatching)
//            {
//                m_bIsWatching = false;
//                m_Watcher.EnableRaisingEvents = false;
//                m_Watcher.Dispose();
//                Default.clrMonitoramento = Color.LightSkyBlue;
//                Default.strMonitoramento = "&Iniciar Monitoramento";
//            }
//            else
//            {
//                m_bIsWatching = true;
//                Default.clrMonitoramento = Color.Red;
//                Default.strMonitoramento = "&Parar Monitoramento";
//                m_Watcher = new System.IO.FileSystemWatcher();
//                if (Default.blnMonitorarDiretorio)
//                {
//                m_Watcher.Filter = "*.*"; 
//                m_Watcher.Path = strEnderecoBancoDadosColetor;
//                }
//                else 
//                {
//                m_Watcher.Filter = strEnderecoBancoDadosColetor.Substring(strEnderecoBancoDadosColetor.LastIndexOf('\\') + 1);
//                m_Watcher.Path = strEnderecoBancoDadosColetor.Substring(0, strEnderecoBancoDadosColetor.Length - m_Watcher.Filter.Length);
//                if (Default.blnSubDiretorios) 
//                { 
//                    m_Watcher.IncludeSubdirectories = true;
//                }
//                m_Watcher.NotifyFilter = System.IO.NotifyFilters.LastAccess | System.IO.NotifyFilters.LastWrite | System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName;
//                m_Watcher.EnableRaisingEvents = true;
//            }
//            return m_bIsWatching;
//        }

//        private void OnChanged(object sender, System.IO.FileSystemEventArgs e)
//        {
//            if (!m_bDirty)
//            {
//                try
//                {
//                    m_Sb.Remove(0, m_Sb.Length);
//                    m_Sb.Append(e.FullPath);
//                    m_Sb.Append(" ");
//                    m_Sb.Append(e.ChangeType.ToString());
//                    m_Sb.Append("    ");
//                    m_Sb.Append(DateTime.Now.ToString());
//                    m_bDirty = true;
//                }
//                catch
//                {
//                }
//            }
//        }
//        private void OnRenamed(object sender, System.IO.RenamedEventArgs e)
//        {
//            if (!m_bDirty)
//            {
//                try
//                {
//                    m_Sb.Append(e.OldFullPath);
//                    m_Sb.Append(" ");
//                    m_Sb.Append(e.ChangeType.ToString());
//                    m_Sb.Append(" ");
//                    m_Sb.Append("to ");
//                    m_Sb.Append(e.Name);
//                    m_Sb.Append("    ");
//                    m_Sb.Append(DateTime.Now.ToString());
//                    m_bDirty = true;
//                    if (Default.blnMonitorarDiretorio)
//                    {
//                        m_Watcher.Filter = e.Name;
//                        m_Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - m_Watcher.Filter.Length);
//                    }
//                }
//                catch
//                {
//                }
//            }
//        }
//    }
//}