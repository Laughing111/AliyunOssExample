using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aliyun.OSS;
using System.Text;
using System.IO;
using Aliyun.OSS.Common;

public class UploadObject : MonoBehaviour {

    private OssClient client;
    private void Awake()
    {
        client = new OssClient(AddressConfig.EndPoint, AddressConfig.AccessKeyId, AddressConfig.AccessKeySecret);
    }
    // Use this for initialization
    void Start()
    {
        //PutObjWithStr("testText.txt", "test123");
        PutObjFromLocal(@"C:\Users\laughing\Desktop\nick.jpg", "1/nick.jpg");
    }
    //字符串上传
    private void PutObjWithStr(string fileName,string text)
    {
      
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(text);
                using (Stream stream = new MemoryStream(data))
                {
                    if(client!=null)
                    {
                        //Bucket名称.Endpoint / Object名称
                        client.PutObject(AddressConfig.Bucket, fileName, stream);
                        Debug.Log("字符串上传成功:" + text);
                    Debug.LogFormat("url:" + "https://{0}.{1}/{2}", AddressConfig.Bucket, AddressConfig.EndPoint, fileName);
                    }
                }
            }
            catch (OssException e)
            {
                Debug.Log("字符串上传错误：" + e);
            }
            catch(System.Exception e)
            {
                Debug.Log("字符串上传错误：" + e);
            }
    }
    //本地上传
    public void PutObjFromLocal(string localPath,string fileName)
    {
        try
        {
            client.PutObject(AddressConfig.Bucket, fileName, localPath);
            Debug.Log("本地文件上传成功:" + localPath);
            Debug.LogFormat("url:" + "https://{0}.{1}/{2}", AddressConfig.Bucket, AddressConfig.EndPoint, fileName);
        }
        catch(OssException e)
        {
            Debug.Log("本地上传报错：" + e.Message);
        }
        catch (System.Exception e)
        {
            Debug.Log("本地上传报错：" + e.Message);
        }
    }
	
}
