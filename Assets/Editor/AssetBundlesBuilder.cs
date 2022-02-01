using System;
using System.IO;
using UnityEditor;

namespace AssetBundle
{
    public class AssetBundlesBuilder
    {
        [MenuItem("Assets/ Build Windows AssetBundles")]
        private static void CreateWindowsAssets()
        {
            if (Directory.Exists(@"C:\Users\" + Environment.UserName + @"\Desktop\AssetBundles"))
                Directory.Delete(@"C:\Users\" + Environment.UserName + @"\Desktop\AssetBundles", true);

            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Desktop\AssetBundles");
            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Desktop\AssetBundles\Windows");


            BuildPipeline.BuildAssetBundles(@"C:\Users\" + Environment.UserName + @"\Desktop\AssetBundles\Windows",
                BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
            
            File.Delete(@"C:\Users\" + Environment.UserName + @"\Desktop\AssetBundles\Windows\Windows");
            File.Delete(@"C:\Users\" + Environment.UserName + @"\Desktop\AssetBundles\Windows\Windows.manifest");
        }
    }
}