using System;
using System.IO;
using System.Reflection;

namespace Ikst.EmbeddedResourceReader
{

    /// <summary>
    /// 埋め込みリソースリーダー
    /// </summary>
    public static class EmbeddedResourceReader
    {

        /// <summary>
        /// 指定したリソースのストリームを取得します。
        /// </summary>
        /// <param name="asm">リソースを読み込むアセンブリ</param>
        /// <param name="resourcePath">リソースのパス</param>
        /// <returns>リソースのストリーム</returns>
        public static Stream GetEmbeddedResourceStream(this Assembly asm, string resourcePath)
        {
            var assemblyName = Path.GetFileNameWithoutExtension(asm.ManifestModule.Name);
            var resourceFullPath = $"{assemblyName}.{resourcePath}";

            var stream = asm.GetManifestResourceStream(resourceFullPath);
            if (stream == null)
                throw new ArgumentException($"引数に指定されたリソース '{resourceFullPath}' が見つかりません。", "resourcePath");
            {
                return stream;
            }
        }


        /// <summary>
        /// 指定したリソースが含む内容を文字列で取得します。
        /// </summary>
        /// <param name="asm">リソースを読み込むアセンブリ</param>
        /// <param name="resourcePath">リソースのパス</param>
        /// <returns>リソースに含まれる文字列</returns>
        public static string GetEmbeddedResourceString(this Assembly asm, string resourcePath)
        {
            using (var stream = GetEmbeddedResourceStream(asm, resourcePath))
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }


        /// <summary>
        /// 指定したリソースが含む内容をバイナリで取得します。
        /// </summary>
        /// <param name="asm">リソースを読み込むアセンブリ</param>
        /// <param name="resourcePath">リソースのパス</param>
        /// <returns>リソースのバイナリ</returns>
        public static byte[] GetEmbeddedResourceBinary(this Assembly asm, string resourcePath)
        {
            using (var st = GetEmbeddedResourceStream(asm, resourcePath))
            using (var ms = new MemoryStream())
            {
                byte[] buf = new byte[32768];
                while (true)
                {
                    int read = st.Read(buf, 0, buf.Length);

                    if (read > 0)
                    {
                        ms.Write(buf, 0, read);
                    }
                    else
                    {
                        break;
                    }
                }
                return ms.ToArray();
            }
        }

    }
}
