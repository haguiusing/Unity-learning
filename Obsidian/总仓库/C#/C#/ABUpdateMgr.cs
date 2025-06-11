using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ABUpdateMgr : MonoBehaviour
{
    private static ABUpdateMgr instance;

    public static ABUpdateMgr Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject obj = new GameObject("ABUpdateMgr");
                instance = obj.AddComponent<ABUpdateMgr>();
            }
            return instance;
        }
    }

    //���ڴ洢Զ��AB����Ϣ���ֵ� ֮�� �ͱ��ؽ��жԱȼ������ ���� ��������߼�
    private Dictionary<string, ABInfo> remoteABInfo = new Dictionary<string, ABInfo>();

    //���ڴ洢����AB����Ϣ���ֵ� ��Ҫ���ں�Զ����Ϣ�Ա�
    private Dictionary<string, ABInfo> localABInfo = new Dictionary<string, ABInfo>();

    //����Ǵ����ص�AB���б��ļ� �洢AB��������
    private List<string> downLoadList = new List<string>();

    //��Դ������IP
    private string serverIP = "ftp://192.168.1.4";

    /// <summary>
    /// ���ڼ���ȸ��µĺ���
    /// </summary>
    /// <param name="overCallBack"></param>
    /// <param name="updateInfoCallBack"></param>
    public void CheckUpdate(UnityAction<bool> overCallBack, UnityAction<string> updateInfoCallBack, UnityAction<float, float> updateProCallBack)
    {
        //Ϊ�˱���������һ�α��� ��������Ϣ �������������
        remoteABInfo.Clear();
        localABInfo.Clear();
        downLoadList.Clear();

        //1.����Զ����Դ�Ա��ļ�
        DownLoadABCompareFile((isOver) =>
        {
            updateInfoCallBack("��ʼ������Դ");
            if (isOver)
            {
                updateProCallBack(1f, 5f);
                updateInfoCallBack("�Ա��ļ����ؽ���");
                string remoteInfo = File.ReadAllText(Application.persistentDataPath + "/ABCompareInfo_TMP.txt");
                updateInfoCallBack("����Զ�˶Ա��ļ�");
                GetRemoteABCompareFileInfo(remoteInfo, remoteABInfo);
                updateInfoCallBack("����Զ�˶Ա��ļ����");

                //2.���ر�����Դ�Ա��ļ�
                GetLocalABCompareFileInfo((isOver)=> {
                    if (isOver)
                    {
                        updateInfoCallBack("�������ضԱ��ļ����");
                        //3.�Ա����� Ȼ�����AB������
                        updateInfoCallBack("��ʼ�Ա�");
                        updateProCallBack(2f, 5f);
                        foreach (string abName in remoteABInfo.Keys)
                        {
                            //1.�ж� ��Щ��Դʱ�µ� Ȼ���¼ ֮����������
                            //�����ڱ��ضԱ���Ϣ��û�н�������ֵ�AB�� �������Ǽ�¼������
                            if (!localABInfo.ContainsKey(abName))
                                downLoadList.Add(abName);
                            //���ֱ�����ͬ��AB�� Ȼ���������
                            else
                            {
                                //2.�ж� ��Щ��Դ����Ҫ���µ� Ȼ���¼ ֮����������
                                //�Ա�md5�� �ж��Ƿ���Ҫ����
                                if (localABInfo[abName].md5 != remoteABInfo[abName].md5)
                                    downLoadList.Add(abName);
                                //���md5����� ֤����ͬһ����Դ ����Ҫ����

                                //3.�ж� ��Щ��Դ��Ҫɾ��
                                //ÿ�μ����һ�����ֵ�AB�� ���Ƴ����ص���Ϣ ��ô����ʣ��������Ϣ ����Զ��û�е�����
                                //���ǾͿ��԰�����ɾ����
                                localABInfo.Remove(abName);
                            }
                        }
                        updateProCallBack(3f, 5f);
                        updateInfoCallBack("�Ա����");
                        updateInfoCallBack("ɾ�����õ�AB���ļ�");
                        //����Ա����� ��ô���Ǿ���ɾ��û�õ����� ������AB��
                        //ɾ�����õ�AB��
                        foreach (string abName in localABInfo.Keys)
                        {
                            //����ɶ�д�ļ����������� ���Ǿ�ɾ���� 
                            //Ĭ����Դ�е� ��Ϣ ����û�취ɾ��
                            if (File.Exists(Application.persistentDataPath + "/" + abName))
                                File.Delete(Application.persistentDataPath + "/" + abName);
                        }
                        updateProCallBack(4f, 5f);
                        updateInfoCallBack("���غ͸���AB���ļ�");
                        //���ش������б��е�����AB��
                        //����
                        DownLoadABFile((isOver) =>
                        {
                            if (isOver)
                            {
                                //����������AB���ļ���
                                //�ѱ��ص�AB���Ա��ļ� ����Ϊ����
                                //��֮ǰ��ȡ������ Զ�˶Ա��ļ���Ϣ �洢�� ���� 
                                updateInfoCallBack("���±���AB���Ա��ļ�Ϊ����");
                                File.WriteAllText(Application.persistentDataPath + "/ABCompareInfo.txt", remoteInfo);
                            }
                            updateProCallBack(5f, 5f);
                            overCallBack(isOver);
                        }, updateInfoCallBack);
                    }
                    else
                    {
                        updateProCallBack(5f, 5f);
                        overCallBack(false);
                    }
                        
                });
            }
            else
            {
                overCallBack(false);
            }
        });
    }

    /// <summary>
    /// ����AB���Ա��ļ�
    /// </summary>
    /// <param name="overCallBack"></param>
    public async void DownLoadABCompareFile(UnityAction<bool> overCallBack)
    {
        //1.����Դ������������Դ�Ա��ļ�
        // www UnityWebRequest ftp���api
        print(Application.persistentDataPath);
        bool isOver = false;
        int reDownLoadMaxNum = 5;
        //���������߳��з���Unity���̵߳� Application ���� ����������
        string localPath = Application.persistentDataPath;
        while (!isOver && reDownLoadMaxNum > 0)
        {
            await Task.Run(() => {
                isOver = DownLoadFile("ABCompareInfo.txt", localPath + "/ABCompareInfo_TMP.txt");
            });
            --reDownLoadMaxNum;
        }

        //�����ⲿ�ɹ����
        overCallBack?.Invoke(isOver);
    }

    /// <summary>
    /// ��ȡ����������AB���е���Ϣ
    /// </summary>
    public void GetRemoteABCompareFileInfo(string info, Dictionary<string, ABInfo> ABInfo)
    {
        //2.���ǻ�ȡ��Դ�Ա��ļ��е� �ַ�����Ϣ ���в��
        //��Ͳ�ȥ��ȡ�ļ��� ֱ�����ⲿ������ ������
        //string info = File.ReadAllText(Application.persistentDataPath + "/ABCompareInfo_TMP.txt");
        string[] strs = info.Split('|');//ͨ��|����ַ��� ��һ����AB����Ϣ��ֳ���
        string[] infos = null;
        for (int i = 0; i < strs.Length; i++)
        {
            infos = strs[i].Split(' ');//�ְ�һ��AB����ϸ��Ϣ��ֳ���
                                       //��¼ÿһ��Զ��AB������Ϣ ֮�� �������Ա�
            ABInfo.Add(infos[0], new ABInfo(infos[0], infos[1], infos[2]));
        }
    }

    /// <summary>
    /// ����AB���Ա��ļ����� ������Ϣ
    /// </summary>
    public void GetLocalABCompareFileInfo(UnityAction<bool> overCallBack)
    {
        //Application.persistentDataPath;
        //����ɶ���д�ļ����� ���ڶԱ��ļ� ˵��֮ǰ�����Ѿ����ظ��¹���
        if (File.Exists(Application.persistentDataPath + "/ABCompareInfo.txt"))
        {
            StartCoroutine(GetLocalABCOmpareFileInfo("file:///" + Application.persistentDataPath + "/ABCompareInfo.txt", overCallBack));
        }
        //ֻ�е��ɶ���д��û�жԱ��ļ�ʱ  �Ż�������Ĭ����Դ����һ�ν���Ϸʱ�Żᷢ����
        else if (File.Exists(Application.streamingAssetsPath + "/ABCompareInfo.txt"))
        {
            string path =
                #if UNITY_ANDROID
                Application.streamingAssetsPath;
                #else
                "file:///" + Application.streamingAssetsPath;
                #endif
            StartCoroutine(GetLocalABCOmpareFileInfo(path + "/ABCompareInfo.txt", overCallBack));
        }
        //������������� ֤����һ�β���û��Ĭ����Դ 
        else
            overCallBack(true);
    }

    /// <summary>
    /// Эͬ���� ���ر�����Ϣ ���ҽ��������ֵ�
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    private IEnumerator GetLocalABCOmpareFileInfo(string filePath, UnityAction<bool> overCallBack)
    {
        //ͨ�� UnityWebRequest ȥ���ر����ļ�
        UnityWebRequest req = UnityWebRequest.Get(filePath);
        yield return req.SendWebRequest();
        //��ȡ�ļ��ɹ� ��������ִ��
        if (req.result == UnityWebRequest.Result.Success)
        {
            GetRemoteABCompareFileInfo(req.downloadHandler.text, localABInfo);
            overCallBack(true);
        }
        else
            overCallBack(false);
    }

    /// <summary>
    /// ���ش������б��е�AB���ļ�
    /// </summary>
    /// <param name="overCallBack"></param>
    /// <param name="updatePro"></param>
    public async void DownLoadABFile(UnityAction<bool> overCallBack, UnityAction<string> updatePro)
    {
        ////1.�����ֵ�ļ� �����ļ��� ȥ����AB��������
        //foreach (string name in remoteABInfo.Keys)
        //{
        //    //ֱ�ӷ��� �������б���
        //    downLoadList.Add(name);
        //}
        //���ش洢��·�� ���ڶ��̲߳��ܷ���Unity��ص�һЩ���ݱ���Application �����������ⲿ
        string localPath = Application.persistentDataPath + "/";
        //�Ƿ����سɹ�
        bool isOver = false;
        //���سɹ����б� ֮�������Ƴ����سɹ�������
        List<string> tempList = new List<string>();
        //�������ص�������
        int reDownLoadMaxNum = 5;
        //���سɹ�����Դ��
        int downLoadOverNum = 0;
        //��һ��������Ҫ���ض��ٸ���Դ
        int downLoadMaxNum = downLoadList.Count;
        //whileѭ����Ŀ�� �ǽ���n���������� ���������쳣ʱ ����ʧ��
        while (downLoadList.Count > 0 && reDownLoadMaxNum > 0)
        {
            for (int i = 0; i < downLoadList.Count; i++)
            {
                isOver = false;
                await Task.Run(() => {
                    isOver = DownLoadFile(downLoadList[i], localPath + downLoadList[i]);
                });
                if (isOver)
                {
                    //2.Ҫ֪�����������˶��� �������
                    updatePro(++downLoadOverNum + "/" +downLoadMaxNum);
                    tempList.Add(downLoadList[i]);//���سɹ���¼����
                }
            }
            //�����سɹ����ļ��� �Ӵ������б����Ƴ�
            for (int i = 0; i < tempList.Count; i++)
                downLoadList.Remove(tempList[i]);

            --reDownLoadMaxNum;
        }

        //�������ݶ��������� �����ⲿ�Ƿ��������
        overCallBack(downLoadList.Count == 0);
    }

    /// <summary>
    /// �����ļ�
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="localPath"></param>
    /// <returns></returns>
    private bool DownLoadFile(string fileName, string localPath)
    {
        try
        {
            string pInfo =
#if UNITY_IOS
            "IOS";
#elif UNITY_ANDROID
            "Android";
#else
            "PC";
#endif
            //1.����һ��FTP���� ��������
            FtpWebRequest req = FtpWebRequest.Create(new Uri(serverIP + "/AB/" + pInfo + "/" + fileName)) as FtpWebRequest;
            //2.����һ��ͨ��ƾ֤ �����������أ�����������˺� ���Բ�����ƾ֤ ����ʵ�ʿ����� ���� ���ǲ�Ҫ���������˺ţ�
            NetworkCredential n = new NetworkCredential("MrTang", "123123123");
            req.Credentials = n;
            //3.��������
            //  ���ô���Ϊnull
            req.Proxy = null;
            //  ������Ϻ� �Ƿ�رտ�������
            req.KeepAlive = false;
            //  ��������-����
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            //  ָ����������� 2����
            req.UseBinary = true;
            //4.�����ļ�
            //  ftp��������
            FtpWebResponse res = req.GetResponse() as FtpWebResponse;
            Stream downLoadStream = res.GetResponseStream();
            using (FileStream file = File.Create(localPath))
            {
                //һ��һ�����������
                byte[] bytes = new byte[2048];
                //����ֵ �����ȡ�˶��ٸ��ֽ�
                int contentLength = downLoadStream.Read(bytes, 0, bytes.Length);

                //ѭ����������
                while (contentLength != 0)
                {
                    //д�뵽�����ļ�����
                    file.Write(bytes, 0, contentLength);
                    //д���ٶ�
                    contentLength = downLoadStream.Read(bytes, 0, bytes.Length);
                }

                //ѭ����Ϻ� ֤�����ؽ���
                file.Close();
                downLoadStream.Close();

                return true;
            }
        }
        catch (Exception ex)
        {
            print(fileName + "����ʧ��" + ex.Message);
            return false;
        }

    }


    private void OnDestroy()
    {
        instance = null;
    }

    /// <summary>
    /// AB����Ϣ��
    /// </summary>
    public class ABInfo
    {
        public string name;//AB������
        public long size;//AB����С
        public string md5;//AB��md5��

        public ABInfo(string name, string size, string md5)
        {
            this.name = name;
            this.size = long.Parse(size);
            this.md5 = md5;
        }
    }
}


