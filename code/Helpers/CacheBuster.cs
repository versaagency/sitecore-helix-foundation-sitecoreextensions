using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Web;

namespace Sitecore.Foundation.SitecoreExtensions.Helpers
{
    public static class CacheBuster
    {
        static IDictionary<string, string> _fileHashCache = new ConcurrentDictionary<string, string>();

        public static string Bust(string path)
        {
            return string.Format("{0}?h={1}", path, FileHash("~" + path));
        }

        static string FileHash(string path)
        {
            try
            {
                if (!_fileHashCache.ContainsKey(path))
                {
                    lock (_fileHashCache)
                    {
                        if (!_fileHashCache.ContainsKey(path))
                        {
                            if (!path.StartsWith("~"))
                            {
                                return null;
                            }

                            var absPath = HttpContext.Current.Server.MapPath(path);

                            if (!File.Exists(absPath))
                            {
                                return null;
                            }

                            using (var stream = new FileStream(absPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            using (var cryptoProvider = new SHA1CryptoServiceProvider())
                            {
                                _fileHashCache.Add(path, BitConverter.ToString(cryptoProvider.ComputeHash(stream)).Replace("-", string.Empty).ToLower());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Hashing failed
            }

            if (_fileHashCache.ContainsKey(path))
            {
                return _fileHashCache[path];
            }
            else
            {
                return null;
            }
        }
    }
}
