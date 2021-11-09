// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("miiriJqnrKOALOIsXaerq6uvqqnpeniB5Ig1RGqBU/nx8HOB4AUlC7PkAUey6O79NoGjBzRNcgyPzrAQQ9uAvGC0Acl1iikF/wNoc9qIu0QPmYTNBqIyyhJEO+TcAOC4I3V+/fUMIScYLEVIUEf5GTEPHb6WMCUoy13MFFVggyw5XSxD2Ag3WKIyGkGkGGCEO9uitfvDoJ4E2UZ6A6Xnso2qjBkZBTlVOOLVCFfVsfhlHNtxitV2QedfSzI4Laeg5boF9GYcSOgoq6WqmiiroKgoq6uqPN37NOfFSW3vX2vqp8mSrkhu0+VIcmegRa7mDDmDuHsHZiRhcAv4Wo4xB7hyIy3es5P3t6Dvva5v+F5WO8X9JtBWn+Lz3/XkW24Gyaipq6qr");
        private static int[] order = new int[] { 0,11,10,8,6,12,13,9,8,9,11,11,12,13,14 };
        private static int key = 170;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
