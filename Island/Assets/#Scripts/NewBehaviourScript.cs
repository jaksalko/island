using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Security.Cryptography;
using UnityEngine;
using System.Text;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    string[] n = { "디자이너","조선공", "요리사", "낚시꾼", "농부", "건축가", "공학자", "의사", "산적" };
    string[] pop = { "보기엔 허름해 보이지만 안 입는 것보다는 훨씬 나아요....얼른 입으세요..."
    , "요즘 유행하는 걸뱅이패션으로 만들어봤어요... 당신에게는 굉장히 잘어울릴 것 같군요.. :)"
    , "통풍이 잘되는 모시로 옷을 리폼해봤어요... 입어...주실 거죠?"
    , "한국전통의상이에요... 이건 꼭 입어야되는 거에요... 병에는 더더욱 안걸릴거에요.."
    , "병균이 들어오지도 못하는 옷을 만들어봤어요.. 이걸 입고 탈출하게되면 사람들이 뭐라 생각하려나요..?"

    , "뗏목을 만들었다네!!! 이 배로 나갈 수는 있지만 나는 나가기가 싫다네!!! 너나 나가라네!!!"
    , "이제 좀 배다워 진다네!! 만반의 준비를 하고 바다로 나가면 충분히 살 것 같다네!!"
    , "이 배를 타고 나가고 싶어진다네!! 배는 어떤 팀으로 타서 역할 분배를 하느냐도 중요하다네"
    , "배를 잘 보게나! 화장실, 침실까지 만들었다네! 저 침실에서 잤다깨서 화장실을 이용하고 싶은 기분이라네!"
    , "이 배는 누가만든거지?...?.....나라네!!!! 하하하핫 내가 만든 것이라고 안 믿길정도로 너무 잘 만든것 같다네!!!"

    , "요리가 맛있어 보이지 않나요? 꺼억..~ 미안해요... 음식하다가 몇개를 집어먹어서요... 하하하핫, 농담이에요~"
    , "요리가 완성됐어요~ 식사시간이에요~"
    , "어디서 맛있는 냄새가 나지요~? 하하핫 제가 만든 음식이에요~"
    , "제가 먹어본 요리들 중 제 요리가 제일 맛있지요~"
    , "요리가 완성됐어요~ 식사시간이에요~"

    , "다음에는 광어 팔짜를 잡아올거야!! 기대들 하고 있으라고!!"
    , "이 물고기는 단번에 낚아챈 물고기고, 저 물고기는 20분간 씨름하다 낚은 물고기야! 그리고 저 물고기는 ....."
    , "지난번에 낚시잡지 표지모델로 촬영했을 때 잡은 것보다 약간 작군!! "
    , "고기를 잡으러 산으로 갈까나~ ......? 산에는 물고기가 없군!!!"
        , "다음에는 광어 팔짜를 잡아올거야!! 기대들 하고 있으라고!!"

    , "이게 농부의 땀의 결실입니다. 음식을 먹을 때 항상 감사하세요."
    , "우리 자식들 내가 수확한 쌀밖에 못먹는데... 얼른 돌아가서 쌀 보내줘야지"
    , "이 쌀은 썩었고... 이 쌀은 맛있겠네요"
              , "우리 자식들 내가 수확한 쌀밖에 못먹는데... 얼른 돌아가서 쌀 보내줘야지"
    , "이 쌀은 썩었고... 이 쌀은 맛있겠네요"


    , "허름하긴 하지만 단기간내 지은 집 치고는 잘 지었군! 누가 지었는지 궁금하군!!"
    , "이전 집보다는 훨씬 안정감이 있어.. 10년은 끄떡없을 집이야"
    , "이 집에서 쉬게되면 다음날 기분이 항상 좋을 것 같은 느낌이야!! 느낌적인 느낌이지"
    , "좋다 좋아. 이정도면 모두들 나를 건축의 신이라 부를정도의 집이지"
    , "여태까지 내가 만든 집들 중에 TOP10에 들만한 집이지, 탈출할 때 들고 가고싶을 정도군!"

    , "초등학교때 영화를 보고 모스부호를 배웠지... 그때가 재밌었는데..."
    , "치지지지직... 누군가 이 무전을 받을 수 있겠구만"
    , "띠리리리리링...여보세요! 작동을 하는지 안하는지 알 수가 없고만"
    , "삐---삐--- 주파수를 잡는 것 같은데 어느 방향이 마을인지 알 수가 없으니 원..."
    , "지구내에서보다 우주에서 신호를 보내면 누구든 볼 수 밖에 없지!"

    , "입에 쓴 것이 몸에 좋은 것이지 >.< 얼른 드셔서 나으시라능"
    , "이 약을 먹으면 병이 낫지만 부작용이 있어요... 그 부작용은 ... 바로..."
    , "내 약에는 부작용이 없다능~ 하지만 있다면 내 말투를 따라할 수도 있다능~"
             , "이 약을 먹으면 병이 낫지만 부작용이 있어요... 그 부작용은 ... 바로..."
    , "내 약에는 부작용이 없다능~ 하지만 있다면 내 말투를 따라할 수도 있다능~"


    , "이 친구가 나를 애먹였어!!! 하지만 내가 이겼지 나는 육지에서 최고이니깐!!!"
    , "으할할할할핥!!! 날 여자라고 만만하게 봤다간 큰일난다고! 난 태어나서부터 산에서 자랐으니!!"
    , "이 섬에는 사냥할 동물이 많더군! 무인도를 무생도로 바꿔버리겠어!!",
             "이 친구가 나를 애먹였어!!! 하지만 내가 이겼지 나는 육지에서 최고이니깐!!!"
    , "으할할할할핥!!! 날 여자라고 만만하게 봤다간 큰일난다고! 난 태어나서부터 산에서 자랐으니!!"
    };

    string[] c = { "(옷이름)이 완성되었습니다. 병에 걸릴 확률이 줄어듭니다.(옷이 업그레이드됨에 따라 병에 걸리는 확률이 줄어듭니다.)"
    ,"(배이름)이 완성되었습니다. 배를 이용하여 낚시와 탈출을 할 수 있습니다.(배가 업그레이드됨에 따라 낚시를 나갔을 때 잡을 수 있는 최대 물고기양과 탈출 확률이 늘어납니다)"
    ,"요리가 완성되었습니다. 요리를 먹어 포만감을 회복할 수 있습니다."
    ,"물고기를 낚았습니다. 물고기를 먹거나, 요리를 할 수 있습니다."
    ,"쌀을 수확했습니다. 쌀은 요리를 통해 먹을 수 있습니다."
    ,"(집이름)이 완성되었습니다. 낮에 집에서 쉴 수 있고, 자고나면 다음날 컨디션이 좋아질 확률이 늘어납니다.(집이 업그레이드됨에 따라 다음 날 컨디션이 좋아질 확률이 늘어납니다)"
    ,"(통신장치 이름)이(가) 완성되었습니다. 통신장치를 이용해 탈출을 시도할 수 있습니다.(통신장치가 업그레이드됨에 따라 탈출 확률이 늘어납니다)"
    ,"약이 제약되었습니다. 약을 통해 병을 치료할 수 있습니다."
    ,"수렵에 성공하였습니다. 고기 20개를 얻었습니다.(이 고기는 요리를 할 수 있습니다.)"};

    // Use this for initialization
    void Start()
    {
        

        CreateXml();
        //inout();
        //inout() -> 암호화, 복호화 
    }

    // Update is called once per frame
    void Update() {

    }
    public static string encryData(string toEncrypt)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes("dotdopdeep");

        byte[] toEmcryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
        RijndaelManaged rDel = new RijndaelManaged();

        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;

        rDel.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = rDel.CreateEncryptor();

        byte[] resultArray = cTransform.TransformFinalBlock(toEmcryptArray, 0, toEmcryptArray.Length);

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    void CreateXml()
    {
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        //루트 노드 생성
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "CharacterPopup", string.Empty);
        xmlDoc.AppendChild(root);

        for (int i = 0; i < 45; i+=5)
        {

            //자식 노드 생성
            XmlNode child1 = xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
            root.AppendChild(child1);



            //자식 노드 속성 생성
            //XmlNode child1 = xmlDoc.CreateNode(XmlNodeType.Element, "Popup/Work", string.Empty);
            //root.AppendChild(child1);

            XmlElement elem = xmlDoc.CreateElement("Name");
            elem.InnerText = n[i/5];
            child1.AppendChild(elem);

            XmlElement elem0 = xmlDoc.CreateElement("work1");
            elem0.InnerText = pop[i];
            child1.AppendChild(elem0);

            XmlElement elem1 = xmlDoc.CreateElement("work2");
            elem1.InnerText =pop[i+1];
            child1.AppendChild(elem1);

            XmlElement elem2 = xmlDoc.CreateElement("work3");
            elem2.InnerText = pop[i+2];
            child1.AppendChild(elem2);

            XmlElement elem3 = xmlDoc.CreateElement("work4");
            elem3.InnerText = pop[i+3];
            child1.AppendChild(elem3);

            XmlElement elem4 = xmlDoc.CreateElement("work5");
            elem4.InnerText = pop[i+4];
            child1.AppendChild(elem4);

            XmlElement elem5 = xmlDoc.CreateElement("common");
            elem5.InnerText = c[i/5];
            child1.AppendChild(elem5);






        }
       
        


        xmlDoc.Save("./Assets/Resources/CharacterPopup.xml");

    }

    public void xmlmod()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Character");

        
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        
        

        XmlNodeList child = xmlDoc.SelectNodes("CharacterInfo/Character");
        XmlNode character = child[0];

        character.SelectSingleNode("Name").InnerText = "wlgusdn9";

        character.SelectSingleNode("Level").InnerText = "10";
        character.SelectSingleNode("Experience").InnerText = "100";

        xmlDoc.Save("./Assets/Resources/CharacterInfo.xml");


    }

    void inout()
    {


        XmlDocument xmlDoc = new XmlDocument();
        string filepath = Application.dataPath.ToString() + "/Resources/Character.xml";
        xmlDoc.Load(filepath);
        XmlElement elmRoot = xmlDoc.DocumentElement;

        string data;
        //복호화
        //data = Decrypt(elmRoot.InnerText);
        //elmRoot.InnerXml = data;
        //xmlDoc.Save(filepath);

        XmlNodeList child = xmlDoc.SelectNodes("CharacterInfo/Character");

        int i = Convert.ToInt32(child[0].SelectSingleNode("Level").InnerText);

        // 값 수정

        Debug.Log(child[0].SelectSingleNode("Name").InnerText);
        Debug.Log(child[1].SelectSingleNode("Name").InnerText);
        Debug.Log(child[2].SelectSingleNode("Name").InnerText);
        Debug.Log(child[0].SelectSingleNode("Level").InnerText);
        Debug.Log(child[1].SelectSingleNode("Level").InnerText);
        Debug.Log(child[2].SelectSingleNode("Level").InnerText);
        Debug.Log(child[0].SelectSingleNode("Experience").InnerText);
        Debug.Log(child[1].SelectSingleNode("Experience").InnerText);
        Debug.Log(child[2].SelectSingleNode("Experience").InnerText);


        Debug.Log(i);


        //암호화
        data = encryData(elmRoot.InnerXml);
        elmRoot.RemoveAll();
        elmRoot.InnerText = data;
        xmlDoc.Save(filepath);
    }

    public static string Decrypt(string toDecrypt)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes("dotdopdeep");

        byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;

        rDel.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = rDel.CreateDecryptor();

        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return UTF8Encoding.UTF8.GetString(resultArray);
    }
}
