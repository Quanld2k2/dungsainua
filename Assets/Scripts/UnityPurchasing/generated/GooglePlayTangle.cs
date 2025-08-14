// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("YvLlPEETV3Rg+7wP8ds3tUoS7MnxQ8Dj8czHyOtHiUc2zMDAwMTBwiPeSlYifp4lNBCSPJX5dAhIK4b68jVokGrrSAyvJzDdT0kdNy2m6jZZhuB83aDOTAhmHuz14+5uwNF00lCvw90JEzSfJGVTDpyUUvh504op5sbelu+f9VZnx46MKs4eTmhnkyy+XbOVM55QtVMHw388yp33BL+SaUPAzsHxQ8DLw0PAwMFlkOPVnO2uFuQq5+ieeaBihMv7Qo1F+aLRCjNocw4eJDW5vdheKV/LTbeNUnz6aQTHdE/4FCan9bzSO6Xo8vYLVr853KbDoyeYeCW9CRsCU/gOR51lytXr8kGl44kFmPQ8wwPhpAejTRNd13uLkv7vq9ILUMPCwMHA");
        private static int[] order = new int[] { 11,11,6,4,9,7,10,9,11,12,10,13,12,13,14 };
        private static int key = 193;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
