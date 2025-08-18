// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("++JRtfOZFYjkLNMT8bQXs10DTcdJlvBszbDeXBh2Dvzl8/5+0MFkwhTXZF/oBDa35azCK7X44uYbRq8pBvQ69/iOabBylNvrUp1V6bLBGiPMttOzN4hoNa0ZCxJD6B5XjXXaxfbWzob/j+VGd9eenDreDl54d4M8eGMeDjQlqa3ITjlP212nnUJs6nnhU9Dz4dzX2PtXmVcm3NDQ0NTR0q5No4UjjkClQxfTbyzajecUr4J5cuL1LFEDR2Rw66wf4csnpVoC/NniJXiAevtYHL83IM1fWQ0nPbb6JjPOWkYybo41JACCLIXpZBhYO5bqQL/TzRkDJI80dUMejIRC6GnDmjlT0N7R4VPQ29NT0NDRdYDzxYz9vmubgu7/u8IbQNPS0NHQ");
        private static int[] order = new int[] { 8,9,13,12,5,10,13,8,12,11,10,13,12,13,14 };
        private static int key = 209;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
