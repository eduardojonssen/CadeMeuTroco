using Dlp.Framework.Container;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Util {

    public class FileLog : ILog {

        /// <summary>
        /// Caminho da pasta sem o nome do arquivo
        /// </summary>
        private string LogPath { get; set; }

        /// <summary>
        /// Nome do arquivo de log.
        /// </summary>
        private string FileName { get; set; }

        /// <summary>
        /// Retorna o caminho completo do arquivo de log.
        /// </summary>
        public string FullPath {
            get {
                return Path.Combine(LogPath, FileName);
            }
        }

        public FileLog() {

            IConfigurationUtility configurationUtility = IocFactory.Resolve<IConfigurationUtility>();

            this.LogPath = configurationUtility.LogPath;
            this.FileName = DateTime.Now.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Log no arquivo
        /// </summary>
        /// <param name="data">Dados a serem logados</param>
        /// <returns></returns>
        public bool Save(string methodName, string logData, CategoryType categoryType) {

            try {
                // Cria o diretório de logs, caso não exista.
                if (Directory.Exists(this.LogPath) == false) {
                    Directory.CreateDirectory(this.LogPath);
                }

                // Verifica se o arquivo já existe. Caso negativo, cria o arquivo.
                if (File.Exists(this.FullPath) == false) {
                    File.Create(this.FullPath).Close();
                }

                using (FileStream fs = new FileStream(this.FullPath, FileMode.Append)) {

                    using (StreamWriter writer = new StreamWriter(fs)) {

                        writer.WriteLine(string.Format("{0}: {1}", DateTime.Now, logData));
                                                
                        writer.Close();
                    }
                    fs.Close();
                }

                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
