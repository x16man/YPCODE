using System.Web.UI;
using System.Reflection;

//
// �йس��򼯵ĳ�����Ϣ��ͨ������
// ���Լ����Ƶġ�������Щ����ֵ���޸������
// ��������Ϣ��
//

[assembly: AssemblyTitle("Shmzh.Web.UI")]
[assembly: AssemblyDescription("Web Control Library")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Shmzh")]
[assembly: AssemblyProduct("Web UI Control Library")]
[assembly: AssemblyCopyright("Shmzh")]
[assembly: AssemblyTrademark("MzH")]
[assembly: AssemblyCulture("")]		
[assembly: TagPrefix("Shmzh.Web.UI.Controls","mzh")]
[assembly: TagPrefix("Shmzh.Web.UI.Controls.FCKeditor","mzh")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
//
// ���򼯵İ汾��Ϣ������ 4 ��ֵ���:
//
//      ���汾
//      �ΰ汾 
//      �ڲ��汾��
//      �޶���
//
// ������ָ��������Щֵ��Ҳ����ʹ�á��޶��š��͡��ڲ��汾�š���Ĭ��ֵ�������ǰ�
// ������ʾʹ�� '*':

[assembly: AssemblyVersion("2.0.0.12")]