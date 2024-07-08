using System.IO.Compression;

namespace EldenRingQuickPasswd
{
    internal class ChangeSaves
    {
        public static void BakupSaves(string steamID)
        {
            string datetime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string zipFileName = $"EldenRingBackup_{steamID}_{datetime}.zip";
            string savePath = GetSavesPath(steamID);
            string bakupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldenRing");
            if (savePath != null)  ZipFile.CreateFromDirectory(savePath, bakupPath + @"\" + zipFileName, CompressionLevel.Optimal, false);
            else return;
        }

        public static string GetSavesPath(string steamID)
        {
            string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldenRing", steamID);
            if (Directory.Exists(savePath))
            {
                //MessageBox.Show(savePath, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return savePath;
            }
            else
            {
                //MessageBox.Show(savePath, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"无法查询到用户 {steamID} 的存档文件夹，确认是否选择正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
