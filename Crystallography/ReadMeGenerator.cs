using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Crystallography;

public class ReadMeGenerator
{
    public static void WriteReadMeFile
        (string version, string introduction, string manual, string copyright, string condition,
        string exemption, string adress, string acknowledge, string history)
    {
        //ReadMe.txt�����݂��Ă��Ȃ����A���݂��Ă��Ă��Â��Ƃ���ReadMe.txt�𐶐�����
        if (!File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ReadMe.txt") ||
            File.GetLastWriteTime(Assembly.GetEntryAssembly().Location) > File.GetLastWriteTime(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ReadMe.txt"))
        {
            List<string> str = new List<string>();

            str.Add(version);//�^�C�g��
            str.Add(introduction);//�͂��߂�
            str.Add(manual);//������@
            str.Add(copyright);//���쌠
            str.Add(condition);//���s����
            str.Add(exemption);//�Ɛ�
            str.Add(adress);//�A����
            str.Add(acknowledge);//�ӎ�
            str.Add(history);//����

            for (int i = str.Count - 1; i >= 1; i--)
                str.Insert(i, "\r\n");

            //File.WriteAllLines(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ReadMe.txt", str.ToArray(), Encoding.Unicode);

            //File.WriteAllLines(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\History.txt", new string[] {version , history}, Encoding.Unicode);
        }
    }
}