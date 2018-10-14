using System.IO;
using UnityEditor;

namespace MorningStudio
{
    public class ExcelAssetPostProcessor : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (string imported in importedAssets)
            {
                string fileExt = Path.GetExtension(imported);
                if (fileExt.Equals(".xls") || fileExt.Equals(".xlsx"))
                {
                    ExcelImportWindow.Init();
                }
            }
        }

        private static void ProcessExcel()
        {

        }
    }
}