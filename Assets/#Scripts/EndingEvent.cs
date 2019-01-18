using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class All
{
    public TF tf;
    public P p;
    public Day day;
    public All(TF t, P t1, Day t2)
    {
        tf = t;
        p = t1;
        day = t2;
    }
}

public class TF
{
    public bool WhaleTF, BottleTF, EngineTF, ShipTF, MerTF, HeroTF, DreamTF, WingTF, RainBowTF, TimeTF, SpaceTF, IceTF, LeafTF, EagleTF;
    
    public TF()
    {
        WhaleTF = BottleTF = EngineTF = ShipTF = MerTF = HeroTF = DreamTF = RainBowTF = IceTF = LeafTF = EagleTF = true;
        SpaceTF = WingTF = TimeTF = false;
    }
   

}
public class P
{
   public int WhaleP, BottleP, EngineP, ShipP, MerP, HeroP, DreamP, WingP, RainBowP, TimeP, SpaceP, IceP, LeafP, EagleP;

    public P()
    {
        WhaleP = BottleP = EngineP = ShipP = MerP = HeroP = DreamP = WingP = RainBowP = TimeP = SpaceP = IceP = LeafP = EagleP = 0;

    }
}
public class Day
{
    public int WhaleDay, BottleDay, EngineDay, ShipDay, MerDay, HeroDay, DreamDay, WingDay, RainBowDay, TimeDay, SpaceDay, IceDay, LeafDay, EagleDay;
    public Day()
    {
        WhaleDay = BottleDay = EngineDay = ShipDay = MerDay = HeroDay = DreamDay = WingDay = RainBowDay = TimeDay = SpaceDay = IceDay = LeafDay = EagleDay = 0;

    }
}

public class EndingEvent : SingleTon<EndingEvent>
{

    string Whale1 = "5%(섬이 흔들리는 만화컷) 으어어어어어 땅이 흔들린다!!! 이봐! 위험하니까 다들 하던일 멈추고 피해있자고!(선택지) 1. 지진인가?  // 2. 지진과는 뭔가 다른 느낌인데?";
    string Whale2 = "10%(섬이 흔들리는 만화컷) 따.... 땅이 흔들... 저기 좀 봐!... 저 멀리 다른 섬이 보이기 시작했어... 섬이 움직이는 걸까?(선택지) 1. 섬이 움직인다 // 2. 날이 좋아서 멀리있는 섬이 보이는 것 뿐이야";
    string Whale3 = "20%(고래등 위에 섬이 있는 만화컷)이건 섬이 아니야...! 고래의 등 위야!!! 앞을 봐. 고래가 저 섬쪽으로 이동하고 있어. 섬 주변에서 떨어져서 헤엄쳐서 섬의 마을로 가자!!우리가 살았어..! 살았다고!!!(저 멀리 섬의 마을이 보이는 만화컷)";
    string WhaleEnding = "이 세상에는 말도 안되는 현상도 많이 일어나고 인간이 본 적 없는 신비한 동물들도 많다.인간이 발견한 동물들은 세상에 존재하는 동물의 약간에 불과한다.'인생이 충만하게 발전할 수 있도록, 현명한 사람들은 모든 살아 있는 생명체의 친구가 된다.' - 알버트 슈바이쳐";

    string Bottle1 = "(탐험시 1%)	(물병을 손에 들고있는 컷{있어도 되고 없어도 되고}) 빈 물병이다... 전혀 필요없을 것 같은 데...?(선택지) 1. 가져간다 // 2. 그냥 둔다";
    string Bottle1_1 = "1번 선택 후	(팝업) 맞아... 영화에서 본 것 같아. 물병안에 구조요청 편지를 넣어서 바다에 떠내려보내면 누군가 보지 않을까?";
    string Bottle2 = "1번 선택 후 50Day 후(1%)    (멀리 배가 오는 만화컷) 이봐들!! 이리로 와서 저기 좀 보라고!! 저기 배가 우리쪽으로 다가오고 있어!! 구조선같아!!(선택지) 1. 탄다 // 2. 안 타고 그냥 보낸다";
    string Bottle2_1 = "(1/3%성공)	(일반 배 만화컷)우리가 흘려보낸 물병을 보고 왔다구요??!! 와주셔서 정말 감사합니다...!!";
    string Bottle2_2 = "(1/3%실패)	(해적선 만화컷) 이 배는 해적선..??! 위장을 하다니...!! 안돼!!!";
    string Bottle2_3 = "(1/3%실패)	(선장의 옷과 배 파편이 떠내려오는 만화컷) 뭐지? 이 옷은? ........ 우리에게 오던 구조대가 난파되었다...(선택지) 1.떠내려온 식량을 챙긴다. // 2. 떠내려온 식량을 그냥 둔다.";
    string Bottle2_3_1 = "1번 선택 후 	(팝업) 정말 죄송하지만 산 사람은 살아야지... 여기서 너무 오래 있었다구...";
    string Bottle2_3_2 = "2번 선택 후	(팝업) 우리를 구하기 위해 오다가 난파됐는데 나만 살겠다고 저 식량들을 먹을 순 없어...";
    string BottleEnding = "쓸모없어 보이던 물병 하나로 이 섬에서 나가게 되다니!사소한 것 하나도 쓸모가 있듯 세상에 필요없는 사람은 없어!'끝날 때까지는 끝난 게 아니다' - 요기 베라";
    string PirateEnding = "요즘 시대에 아직도 해적이 존재하다니... 대체 이 해역은 어디란 말인가... 살기 위해 아둥바둥 몸부림쳤는데 아무 의심없이 배를 탄 죄가 이렇게 크단 말인가!'언제나 의심하고 경계하여야 한다.' - 손자병법";

    string Engine0 = "여기서 나가기 위해서 통신 장치를 만들어서 구조요청 신호를 보내는 것도 시도해보자!";
    string Engine1 = "(통신장치 완성 후 사용시)	(통신장치를 작동시키는 만화컷) 제발... 누구든 들어줬으면 좋겠다...";
    string Engine1_1 = "(성공확률로 성공)		(통신장치 만화컷) 여보세요??!! 들리십니까?!! 저희가 어떤 섬에 조난을 당했습니다..! 구하러 와주실 수 있으십니까?...이 섬의 위치는........네?! 오시는 데에 20일이 걸린다구요? 기다리겠습니다.! 감사합니다!!";
    string Engine1_2 = "(실패시)			(통신장치가 망가지는 만화컷)	간단하게 만든 통신장치라... 제대로 작동이 되지 않는 것 같다...다시 한번 만들어봐야지....어쩔수 없다 이 섬에서 나가기 위해서는 뭐라도 해보는 수 밖에....";
    string Engine2 = "(50% 성공)		(멀리 배가 오는 만화컷) 이봐들!! 이리로 와서 저기 좀 보라고!! 저기 배가 우리쪽으로 다가오고 있어!! 구조선같아!!(선택지) 1. 탄다 // 2. 안 타고 그냥 보낸다";
    string Engine2_1 = "(1/3%성공)	(일반 배 만화컷)통신을 듣고 왔다구요??!! 와주셔서 정말 감사합니다...!!";
    string Engine2_2;
    string Engine2_3;
    string Engine2_3_1;
    string Engine2_3_2;
    string EngineEnding = "위험을 무릅쓰고 이 위험한 바다를 지나서 우리를 구하러 와줬다니...만약 내가 구조요청을 받았다면 이 분들처럼 올 수 있었을까..?			'그들이 걸어온 길은 고난과 자기 희생의 길이었다.' - G.E.레싱";

    string Ship0 = "배를 직접 만들어서 여기서 탈출하는 것이 가장 먼저 떠오른 생각이니 배를 만들기 시작해볼까?";
    string Ship1 = "(배 완성 후 탈출 시)		(바다에 배를 띄우는 만화컷) 이 배가 버텨주길 바랄뿐..... 가보자...";
    string Ship1_1 = "(성공확률로 성공)		(저 멀리 섬의 마을이 보이는 만화컷) 저기 마을이 보인다!!! 우리가 탈출했어!! 탈출했다고!!! 가족들을 볼 수 있게 됐어...";
    string Ship1_2 = "(실패시)			(배가 난파된 만화컷) 역시 이 배로는 무리였나... 난.... 살고.. 싶어..";
    string ShipEnding = "저기 마을이 보인다!!! 우리가 탈출했어!! 탈출했다고!!! 가족들을 볼 수 있게 됐어... 힘들었지만 배를 만들어서 탈출에 성공했어! 모두가 힘을 합해 일을 한 덕분이야.처음에는 이 배로 탈출할 수 없을 것이라 생각했는데 말이야...'성공하기 전에는 항상 그것이 불가능한 것처럼 보이기 마련이다.' -넬슨 만델라";
    string ShipFail = "무슨 일을 할 때는 충분히 생각 해보고 시도를 했어야했어... 계획을 짜던가 말이야...누가봐도 무리한 도전이었다고 생각해...'계획 없는 목표는 한낱 꿈에 불과하다.' - 생텍쥐페리";

    string Mer0 = "이곳은 지도에도 존재하지 않는 섬인 것 같아... 한번도 본적이 없거든.. 이 주변 바다에는 처음보는 생명체들이 많겠지? ";
    string Mer1 = "(낚시 시 1%)	(저멀리 바다에서 사람이 수영하는 만화컷) 저기 사람이?! 저기요!!!! 저기요!!!! ...... 못들었나..? (선택지) 1. 이 주변에 마을이 있나? // 2. 저 사람은 뭐지..?";
    string Mer2 = "(낚시 시 5%)	(저멀리 바다에서 사람이 수영하는 만화컷) 저기요!!! 제말 들리시나요??!!! ...?! 눈이 마주쳤다... 근데 왜이렇게 느낌이 싸하지..?(선택지) 1. 감기기운이 도나보군 가서 약을 먹어야겠어. // 2. 뭔가 오싹한 느낌이다.";
    string Mer3 = "(평상 시 10%)	(해변가에서 인어맨 발견 만화컷) ?! 인... 인어? 근데 인어공주가 아니라... 남자잖아?! ...... 뭐라고? 인어가 말을 하는 것 같은데?인어맨 : !#$#@$%&#$% 사람말을 못하나보다...들을수는 있니?인어맨 : (고개를 끄덕이며) @$@!%#!$% 우리는 여기에 조난을 당했어 우리를 구해줄 수 있겠니?이해하지 못한 건가...후.....(인어맨이 점점 멀어져가는 만화컷 있어도되고 없어도됨)";
    string Mer4 = "그냥 5Day 후	(해변가에서 인어맨 발견 만화컷) 이봐들 며칠 전 인어가 우리를 도와주러 왔다고!!!(물고기 다리가 생긴 만화컷) 이 물고기들을 타면 된다나봐!!(선택지) 1. 탄다 // 2. 안 탄다.";
    string MerEnding = "(저 멀리 섬의 마을이 보이는 만화컷) 저기 마을이 보인다!! 고마워 물고기들아! 그리고 인어맨!! 덕분에 살았어!!처음엔 무서웠지만...그는 착한 인어였어... 그리고 우리가 그토록 잡아 먹었던 물고기들마저 우리를 도와주다니..앞으로는 물고기를 못 먹겠어... 우리는 물고기들에게 큰 빚을 진 셈이군...사람도 사람을 용서하지 못하는데... 물고기가 우리를 용서한 것이 아닌가...'용서만큼 완벽한 복수는 없다.' - 조쉬 빌링스";
    string MerFail = "처음봤을 때부터 뭔가 껄끄러웠어... 물고기를 마구 잡아먹은 우리를 도와줄거라 생각했다니... 너무 큰 기대를 했던걸까...우리는 단지 이 섬에서 벗어나 평상시처럼 살고 싶었던 것인데 말야..";

    string Hero0 = "나는 힘도 세고 정의로운 슈퍼맨같은 영웅이 되고 싶었어...내가 어렸을 적 물에 빠져 허우적될 때 누군가 구해줬는데 그게 슈퍼맨같았거든....그때 그 슈퍼맨이 다시 한번 나타나줄거라 나는 믿어";
    string Hero1 = "(평상 시 1%)	(하늘위에 뭔가 반짝거리는 컷)	 이봐들!! 저기 좀 봐봐! 하늘에 별똥별같은 것이 떨어졌나봐!!(선택지) 1. 별똥별에 소원을 빈다... // 2. 별똥별이 아니다";
    string Hero2 = "(평상 시 5%)	(하늘위에 뭔가 반짝거리는 컷 + (텍스트)또?!) 어? 얼마전에도 이랬던 적이 있었던 것 같은데..?처음 봤을 때 이후로 몇번 보였던 것 같기도..?!(선택지) 1. 기억나지 않는다 // 2. 뭔가 우리 주변을 날라다니는 것 같다";
    string Hero3 = "(평상 시 10%)	(히어로 등장 만화컷) 당신은...! 슈퍼맨!!! 우리를 구하러 와주었군요!!!(선택지) 1. 도움을 청한다 // 2. 도움을 청하지 않는다	";
    string HeroEnding = "(하늘위 히어로등에 업혀서 멀리 섬의 마을이 보이는 만화컷) 도와줘서 고마워요 슈퍼맨!!며칠동안 저희 섬 주변을 지켜보지 않았나요?슈퍼맨 : ..... 나는 오늘 처음 그 섬을 지나갔다네, 평소에 지나갈 때는 아무도 없었어야하는데 너희가있었기 때문에 들렸던 것이고??! 그럼 몇번씩이나 우리에게 보였던 그 물체는 뭐지?...		우리가 봤던 건 뭘까...슈퍼맨같은 다른 영웅일까? 그렇지만 영웅이었다면 왜 우리를 바라보기만 할 뿐 도와주지 않았을까?.....외계 생명체인 것인가? 세상에 불가능한 것은 없지...		'두 가지 가능성이 있다. 우주에 우리만 존재하거나 그렇지 않거나. 둘 다 끔찍한 일이다.' - 아서 C. 클라크";
    string HeroFail = "(배경은 달 , 히어로가 달에 두고 떠남) ...당신 사람을 구해야하는 영웅이면서 대체 왜...                    슈퍼맨 : 내가 너희를 구해야하는 게 왜 당연한거지?                    그거야..당신은 우리보다 강하고 능력이 있으니깐...그리고 여태까지 많은 사람들을 구해왔잖아요           슈퍼맨 : 그건 우리 마을에 사는 다른 영웅인가보지, 난 우리 마을에서 범죄를 너무 저질러서 추방당했다고그리고 그 누구도 남을 돕는 것이 당연한 사람은 없다, 이면에는 무언가 존재하지...        우리가 영웅이라 불렀던 자가 우리를 죽였다.....대체 인간은 이 자의 존재를 뭐라 생각했던 것일까?        이유없이 남을 돕는다는 사람들도 많다지? 하지만 그들의 이면은 어떨까? 정말로 아무 이유없이 남을 돕는 것일까..... 그들의 표면만 보고 믿어도 되는 것일까?		'의심하는 것이 유쾌한 일은 아니다, 하지만 확신하는 것은 어리석은 일이다.' - 볼테르";

    string Dream0 = "나는 평소에 꿈을 자주 꿔. 때로는 꿈인 것을 인지하는 자각몽을 꾸기도 해.    자각몽에서의 상황이 너무 행복할 때는 깨고싶지 않을 때도 있었지.";
    string Dream1 = "(팝업) 요즘 잘 때 꿈을 자주 꾼다...        (선택지) 1. 스트레스를 받아서 그렇다 // 2. 약을 만들어서 먹자.";
    string Dream2 = "(팝업) 오늘도 꿈을 꿨다... 꿈에서는 배가 난파되기 전이었고 나는 집이었다꿈이 현실이 되었고 현실이 꿈이었으면 좋겠다..(선택지) 1. 마음의 병아니야? 약을 먹자 // 2. 너무 힘들어서 그런 것이다";
    string Dream3 = "(방 침대에서 일어나 앉은 만화컷)??! 내가 왜 내 방에 누워있는 것이지? (선택지) 1. 꿈이다 현실로 돌아가자 // 2. 깨고 싶지 않다";
    string Dream3_1 = "1번 선택 후 50%성공		(팝업) ??! 꿈에서 깨질않아... 이곳이 현실같아!! 지금까지 겪었던 일은 꿈이었던 걸까...?";
    string Dream3_2 = "1번 선택 후 50%실패		(팝업)... 현실로 돌아왔다... 잠깐이었지만 너무 좋은 꿈이었어우리가 다시 집으로 돌아갈 수 있을까..?";
    string DreamFail = "(팝업) 당신은 당신의 꿈에 갇혔습니다.  꿈속에선 뭐든지 가능해. 현실로 돌아와 - (영화)인셉션 中";
    string DreamEnding = "내가 꾸었던 꿈은 너무 현실감이 있었어.. 마치 그것이 현실이고 지금이 꿈이라고 느낄만큼...    '수면은 피로한 마음의 최상의 약이다.' - 세르반테스";

    string Wing1 = "(확률 옷을 만들다 날개옷 만들었을 때)	(팝업) ...? 옷에 날개가 생겼어??!!(선택지) 1. 옷을 입고 탈출한다 // 2. 생존하는 데에 유용하겠다";
    string WingEnding = "(하늘에서 섬의 마을을 보는 만화컷)이 날개옷의 주인은 선녀일까..? 하늘이 우리를 지켜보다가 도운 것인가..?";

    string RainBow1 = "(낮에 비가 올 확률 평상시 1%)	(팝업)비가 내린다.... 비가 오니 오늘은 일을 못할 것 같군... 농사짓던 건 어딨지? (농사작물들 전부 사라짐)(선택지) 1. 물을 받아놓는다 // 2. 하던 일이나 하자(아예 일을 못하거나, 효율 1/2)";
    string RainBow1_1 = "오늘은 비가 와서 일을 못하겠군....";
    string RainBow2 = "(다음날 10% 확률)			(섬 반대편 저 멀리 무지개가 떠있는 만화컷)무지개가 떳다!! 한번 가볼까?(선택지) 1. 가본다(캐릭터 1개필요) // 2. 낭만에 젖어있을 시간 없어";
    string RainBow2_1 = "1번 선택 후			(하루를 보낼 때 팝업) 무지개에 가까이 가보니 만질 수가 있더군...다음에 무지개가 뜨면 다시 가봐야겠어";
    string RainBow3 = "(낮에 비가 올 확률 평상시 1%)	(팝업)비가 내린다. (선택지) 1. 물을 받아놓는다(캐릭터 1개필요) // 2. 하던 일이나 하자";
    string RainBow4 = "(다음날 10% 확률)			(섬 반대편 저 멀리 무지개가 떠있는 만화컷) 무지개가 또 떳다!!(선택지) 1. 무지개를 통해서 탈출을 시도하자 // 2. 무지개를 밟고 간다니 불가능해, 떨어지고 말거야.";
    string RainBowEnding = "(무지개 다리를 건너는 만화컷) 거봐! 건널 수 있다고 했잖아!!	우린 살았어 살았다고!무지개를 밟는 건 과학적으로 불가능하지.하지만 불가능하다고 포기했다면 탈출할 수 없었을 것이다.'이런 일은 도저히 불가능하다고 생각하고 시작하는 것은 그것을 제 스스로 불가능하게 만드는 것이다.' - 워너메이커";

    string Time1 = "(확률로 타임머신 생성)		(팝업) 내가 만들려던건 통신기인데 이건... 타임머신이잖아..?!(선택지) 1. 의도치 않은 기계야..위험해(선택하면 원래 단계의 통신장치로 변경) // 2. 가동시켜보자!";
    string Time2 = "2번 선택 후 50%성공		(팝업) 타임머신을 가동시키니 빛이 번쩍인다...";
    string Time2_1 =     "(방 침대에서 일어나 앉은 만화컷)...돌아왔나..? 날짜가... !!!난파되기 전으로 돌아왔어!!";
    string TimeEnding = "타임머신을 가동시킨 것은 무리한 도전이었다. 하지만 그 도전을 하지 않았다면 탈출하지 못했을 것이다.'당신의 운명이 결정되는 것은 결심하는 그 순간이다.' - 앤서니 라빈스";
    string TimeFail = "(팝업)타임머신을 가동시키니 빛이 번쩍인다...(백악기시대, 공룡이 지나다닌다) 저...저건...고....공..룡? 타임머신이 우리를 너무 과거로 데려온 것인가?탈출에 눈이 멀어서 무리한 선택을 하고 말았군...사용법도 모르는 장치를 가동시켜버리다니...";

    string Space1 = "(팝업) 마법사의 공간이동 마법을 사용하시겠습니까?(선택지)1. 사용한다 // 2. 사용하지 않는다.";
    string Space2 = "성공시 능력치/2 확률 	(팝업) 여긴 어디지?... 어? 다른 사람? 마을..? 공간이동이 성공했나봐!!! 지독한 무인도에서 벗어났다구!!";
    string SpaceEnding =  "우리가 일할 때 마법사가 마냥 놀고 먹는건 아니었군, 그도 열심히 노력하고 있었던거야우리는 일하고 있는 동안 혼자 놀고있다고 뒷담화를 한 것이 미안하고만...";
    string SpaceFail = "(전쟁터 만화컷) (탕... 탕탕...퍼퍼펑)...? 이곳은 어디지? 총 소리같은 게 들리는데??! 진짜 총이잖아!! 여긴 전쟁터야!! 무인도보다 더 위험한 곳이라고!!무인도보다 더 위험한 곳이 있다니...그리고 아직도 분쟁지역이 존재한다니...이시간에도 분쟁으로 인해 죄없는 아이들, 사람들이 죽어가고 있겠지...평화로운 세상을 만들 수는 없는 것일까?'세상에는 인간의 필요를 충족시킬 모든 것이 있지만, 그의 탐욕은 충족시킬 수 없다' - 마하트마 간디";

    string Ice1 = "(추움 맵 탐험시 1%확률)	(바다위에 거대한 빙판이 떠있는 만화컷) 이 섬에는 떠다니는 빙판이 굉장히 많은 것같아, 끌기만 할 수 있다면 배처럼 사용할 수 있을 것 같다.(선택지) 1. 빙판을 끌 수 있을까? // 2. 빙판을 어떻게 끌어!";
    string Ice1_1 = "1번 선택 후(빙판을 오브젝트에 포함) 	(팝업) 많은 물고기를 매달아 놓으면 가능 할 것 같다!";
    string Ice2 = "이정도 물고기 수라면 빙판을 끌 수 있을 것 같아!(선택지) 1. 빙판에 물고기를 매달아 탈출하자! // 2. 괜히 시도했다가 물에 빠져 죽을 것 같아!";
    string IceEnding = "(빙판 클릭 먹지않은 물고기 100마리 있을시)	(팝업) 이정도 물고기 수라면 빙판을 끌 수 있을 것 같아요즘엔 사람들때문에 빙산이 무너지고 빙판들도 녹고 있다는 데...아직 남아 있는 빙판덕분에 탈출할 수 있었어우리와 같은 사람들이나 동물들을 위해 에너지를 아껴써야겠어...'북극곰은 걷고싶다.'";

    string Leaf1 = "(정글 맵 탐험시 1%확률)	(팝업) 거대한 나뭇잎을 발견했다.. 엄청 거대해서 가져가려면 다른 것들은 못가져갈 것같다(선택지) 1. 가져간다. // 2. 가져가지 않는다.";
    string LeafEnding = "1번 선택 시 나뭇잎 획득  사용시 10%성공(바다에서 저 멀리 섬의 마을이 보이는 만화컷) 거대한 나뭇잎으로 무인도를 빠져나왔어!!그 곳은 가만히 있어도 땀이 날 정도로 덥고 습했다.다시는 그곳에 가고싶지도 가야할 상황이 와서는 안된다.";
    string LeafFail = "(물에 빠진 만화컷) 나뭇잎으로 바다를 건너는 것은 말도 안되는 생각이었어. 왜 이런 선택을 했을까?도전을 한다는 것은 좋지만 말도 안되는 일이었어..나뭇잎으로 바다를 건너다니!하지만...왠지 성공할 것 같은 느낌이었는데...";

    string Eagle1 = "(수렵 성공시 1퍼 확률 독수리 얻음)	(독수리 만화컷) 이 친구 말을 엄청 잘 듣잖아?(선택지)	1. 데려가서 훈련시킨다 // 2. 야생동물이라 위험하다 잡아먹는다";
    string Eagle2 = "1번 선택 후 독수리 획득	독수리 사용 시(선택지) 1. 독수리를 타고 다른 섬으로 가 탐험(얻는 양이 많음) // 2. 독수리를 타고 탈출 시도";
    string EagleEnding = "(하늘에서 저 멀리 섬의 마을이 보이는 만화컷) ...독수리를 만났던 날 독수리를 잡아 먹었다면 이렇게 탈출할 수 없었을거야...그 때의 선택으로 인해 탈출할 수 있었다.";
    string EagleFail = "(독수리가 사람들을 자기 둥지로 데려간 만화컷) 여긴...? 거대 독수리의 둥지잖아!!저기 좀 봐 다른 독수리들도 오고있어! 으아아악 야생동물을 길들인다는 것은 어렵다.그리고 하늘의 제왕을 길들이는 것이란 불가능에 가깝다.";

    
    
   public  bool WhaleTF, BottleTF, EngineTF, ShipTF, MerTF, HeroTF, DreamTF, WingTF, RainBowTF, TimeTF, SpaceTF, IceTF, LeafTF, EagleTF;

    int WhaleP, BottleP, EngineP, ShipP, MerP, HeroP, DreamP, WingP, RainBowP, TimeP, SpaceP, IceP, LeafP, EagleP;
    bool already;//하루에 어떠한 엔딩이 진행되었는지 확인 true면 더이상 다른 엔딩 이벤트 발생x
                 //하루에 끝날 때 false로 바꿔줘야함
    public int WhaleDay, BottleDay, EngineDay, ShipDay, MerDay, HeroDay, DreamDay, WingDay, RainBowDay, TimeDay, SpaceDay, IceDay, LeafDay, EagleDay;
    public bool fishing, adven, hunting;//하루가 종료될 때 false로 바꿔야함
    bool isPaused = false;

    //already, fishing, adven, hunting 은 playprefs 로 저장

    void Start()
    {
        Engine2_2 = Bottle2_2;
        Engine2_3 = Bottle2_3;
        Engine2_3_1 = Bottle2_3_1;
        Engine2_3_2 = Bottle2_3_2;

        

        //WhaleTF = BottleTF= EngineTF= ShipTF= MerTF= HeroTF= DreamTF= RainBowTF = IceTF= LeafTF= EagleTF = true; 
        //WhaleP = BottleP = EngineP = ShipP = MerP = HeroP = DreamP = WingP = RainBowP = TimeP = SpaceP = IceP = LeafP = EagleP = 0;
        //WhaleDay = BottleDay = EngineDay = ShipDay = MerDay = HeroDay = DreamDay = WingDay = RainBowDay = TimeDay = SpaceDay = IceDay = LeafDay = EagleDay = 0;
        //SpaceTF = WingTF = TimeTF=false; // 얘는 날개옷이 만들어졌을 때 true로 바꿔줌
        //이것들 모두 json에 저장해서 게임이 재시작될 때 로드해야함
        //fishing = adven = hunting = false;
        //already = false;
       // StartCoroutine(EndingClear());
        StartCoroutine(EndingLoad());
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            //for (int i = 0; i < mData.MaterialList.Length; i++)
            //    mData.MaterialList[i].Count++;
            StartCoroutine(EndingSave());
            isPaused = true;

        }

        else
        {
            if (isPaused)
            {
                StartCoroutine(EndingLoad());

            }
        }
    }

    void OnApplicationQuit()
    {

        Debug.Log("강제종료EndingData");
        StartCoroutine(EndingSave());
        //PlayerPrefs 는 각각의 행동중일 때 true, 행동중이지 않으면 false;
        PlayerPrefs.SetInt("fishing", (fishing ? 1 : 0));
        PlayerPrefs.SetInt("adven", (adven ? 1 : 0));
        PlayerPrefs.SetInt("hunting", (hunting ? 1 : 0));
        PlayerPrefs.SetInt("already", (already ? 1 : 0));

    }
    public void save()
    {
        //StartCoroutine(FoodSave());
    }

    //private string ToKor(Foodd f)
    //{

    //    JsonData ch1 = JsonMapper.ToJson(fd);

    //    string tmpstring = ch1.ToString();

    //    string[] tmpcomma = tmpstring.Split(',');

    //    string[] tmpcolon = tmpcomma[1].Split(':');

    //    string res = tmpcolon[0] + ":" + "'" + fd.Name + "'";

    //    string ress = tmpcomma[0] + "," + res + "," + tmpcomma[2];

    //    return ress;

    //}



    IEnumerator EndingSave()
    {
        List<All> AllList = new List<All>();
        List<TF> TFList = new List<TF>();
        List<P> PList = new List<P>();
        List<Day> DayList = new List<Day>();
        
        TF tf = new TF();
        P p = new P();
        Day day = new Day();
        All all;
        for (int i = 0; i < 14; i++)
        {


           
            switch (i)
            {
                case 0:
                    tf.WhaleTF = WhaleTF;
                    p.WhaleP = WhaleP;
                    day.WhaleDay = WhaleDay;
                    break;
                case 1:
                    tf.BottleTF = BottleTF;
                    p.BottleP = BottleP;
                    day.BottleDay = BottleDay;
                    break;
                case 2:
                    tf.EngineTF = EngineTF;
                    p.EngineP = EngineP;
                    day.EngineDay = EngineDay;
                    break;
                case 3:
                    tf.ShipTF = ShipTF;
                    p.ShipP = ShipP;
                    day.ShipDay = ShipDay;
                    break;
                case 4:
                    tf.MerTF = MerTF;
                    p.MerP = MerP;
                    day.MerDay = MerDay;
                    break;
                case 5:
                    tf.HeroTF = HeroTF;
                    p.HeroP = HeroP;
                    day.HeroDay = HeroDay;
                    break;
                case 6:
                    tf.DreamTF = DreamTF;
                    p.DreamP = DreamP;
                    day.DreamDay = DreamDay;
                    break;
                case 7:
                    tf.WingTF = WingTF;
                    p.WingP = WingP;
                    day.WingDay = WingDay;
                    break;
                case 8:
                    tf.RainBowTF = RainBowTF;
                    p.RainBowP = RainBowP;
                    day.RainBowDay = RainBowDay;
                    break;
                case 9:
                    tf.TimeTF = TimeTF;
                    p.TimeP = TimeP;
                    day.TimeDay = TimeDay;
                    break;
                case 10:
                    tf.SpaceTF = SpaceTF;
                    p.SpaceP = SpaceP;
                    day.SpaceDay = SpaceDay;
                    break;
                case 11:
                    tf.IceTF = IceTF;
                    p.IceP = IceP;
                    day.IceDay = IceDay;
                    break;
                case 12:
                    tf.LeafTF = LeafTF;
                    p.LeafP = LeafP;
                    day.LeafDay = LeafDay;
                    break;
                case 13:
                    tf.EagleTF = EagleTF;
                    p.EagleP = EagleP;
                    day.EagleDay = EagleDay;
                    break;
            }



            
        }
        all = new All(tf, p, day);

        AllList.Add(all);


        JsonData EndingJson = JsonMapper.ToJson(AllList);
        File.WriteAllText(Application.dataPath + "/Resources/EndingData.json", EndingJson.ToString());
        //File.WriteAllText(Application.persistentDataPath + "/FoodData.json", FoodJson.ToString());//안드로이드
        //컴퓨터


        yield return null;
    }

    IEnumerator EndingClear()
    {
        List<TF> TFList = new List<TF>();
        List<P> PList = new List<P>();
        List<Day> DayList = new List<Day>();
        List<All> AllList = new List<All>();
        TF tf = new TF();
        P p = new P();
        Day day = new Day();
        All all;
        for (int i = 0; i < 1; i++)
        {
            //recovery = InventoryManager.Instance.FData.FoodList[i].Recovery;
            //name = InventoryManager.Instance.FData.FoodList[i].Name;
            //WhaleTF, BottleTF, EngineTF, ShipTF, MerTF, HeroTF, DreamTF, 
            //WingTF, RainBowTF, TimeTF, SpaceTF, IceTF, LeafTF, EagleTF;
            //count = InventoryManager.Instance.FData.FoodList[i].Count;

            TFList.Add(tf);
            PList.Add(p);
            DayList.Add(day);

            all = new All(tf, p, day);

            AllList.Add(all);


        }


        JsonData EndingJson = JsonMapper.ToJson(AllList);
        File.WriteAllText(Application.dataPath + "/Resources/EndingData.json", EndingJson.ToString());
        //File.WriteAllText(Application.persistentDataPath + "/FoodData.json", FoodJson.ToString());//안드로이드
        //컴퓨터


        yield return null;
    }


    // Update is called once per frame

    IEnumerator EndingLoad()
    {

        if (PlayerPrefs.GetInt("fishing") == 1)
            fishing = true;
        else
            fishing = false;

        if (PlayerPrefs.GetInt("hunting") == 1)
            hunting = true;
        else
            hunting = false;

        if (PlayerPrefs.GetInt("adven") == 1)
            adven = true;
        else
            adven = false;

        if (PlayerPrefs.GetInt("already") == 1)
            already = true;
        else
            already = false;
        //string FoodString = File.ReadAllText(Application.persistentDataPath + "/FoodData.json");
        string EndingString = File.ReadAllText(Application.dataPath + "/Resources/EndingData.json");

        Debug.Log(EndingString); // 첫 줄 출력

        JsonData itemData = JsonMapper.ToObject(EndingString);
        //태그로 정렬 가능?

        ParsingEnding(itemData);

        yield return null;

    }

    private void ParsingEnding(JsonData Data)
    {

        for (int i = 0; i < 14; i++)
        {
            WhaleTF = bool.Parse(Data[0]["tf"][i].ToString());
            WhaleP = int.Parse(Data[0]["p"][i].ToString());
            WhaleDay = int.Parse(Data[0]["day"][i].ToString());


            switch (i)
            {
                case 0:
                    WhaleTF = bool.Parse(Data[0]["tf"][i].ToString());
                    WhaleP = int.Parse(Data[0]["p"][i].ToString());
                    WhaleDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 1:
                    BottleTF = bool.Parse(Data[0]["tf"][i].ToString());
                    BottleP = int.Parse(Data[0]["p"][i].ToString());
                    BottleDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 2:
                    EngineTF = bool.Parse(Data[0]["tf"][i].ToString());
                    EngineP = int.Parse(Data[0]["p"][i].ToString());
                    EngineDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 3:
                    ShipTF = bool.Parse(Data[0]["tf"][i].ToString());
                    ShipP = int.Parse(Data[0]["p"][i].ToString());
                    ShipDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 4:
                    MerTF = bool.Parse(Data[0]["tf"][i].ToString());
                    MerP = int.Parse(Data[0]["p"][i].ToString());
                    MerDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 5:
                    HeroTF = bool.Parse(Data[0]["tf"][i].ToString());
                    HeroP = int.Parse(Data[0]["p"][i].ToString());
                    HeroDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 6:
                    DreamTF = bool.Parse(Data[0]["tf"][i].ToString());
                    DreamP = int.Parse(Data[0]["p"][i].ToString());
                    DreamDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 7:
                    WingTF = bool.Parse(Data[0]["tf"][i].ToString());
                    WingP = int.Parse(Data[0]["p"][i].ToString());
                    WingDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 8:
                    RainBowTF = bool.Parse(Data[0]["tf"][i].ToString());
                    RainBowP = int.Parse(Data[0]["p"][i].ToString());
                    RainBowDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 9:
                    TimeTF = bool.Parse(Data[0]["tf"][i].ToString());
                    TimeP = int.Parse(Data[0]["p"][i].ToString());
                    TimeDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 10:
                    SpaceTF = bool.Parse(Data[0]["tf"][i].ToString());
                    SpaceP = int.Parse(Data[0]["p"][i].ToString());
                    SpaceDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 11:
                    IceTF = bool.Parse(Data[0]["tf"][i].ToString());
                    IceP = int.Parse(Data[0]["p"][i].ToString());
                    IceDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 12:
                    LeafTF = bool.Parse(Data[0]["tf"][i].ToString());
                    LeafP = int.Parse(Data[0]["p"][i].ToString());
                    LeafDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
                case 13:
                    EagleTF = bool.Parse(Data[0]["tf"][i].ToString());
                    EagleP = int.Parse(Data[0]["p"][i].ToString());
                    EagleDay = int.Parse(Data[0]["day"][i].ToString());
                    break;
            }




        }

    }

    public void TakeOnShip()
    {
        /*********************************************************************
         * 
         * int count = Random.Range(0, 100);
                    if(count <33)
                    {
                        if(BottleP==2)
                        // 섬 가까이 다가온 배가 일반 배인 만화컷 1~2초
                        // Bottle2_1 text 출력
                        // 엔딩씬으로 넘어감
                        // 엔딩 애니메이션 출력, BottleEnding text 출력
                        else if(EngineP ==3)
                        // 섬 가까이 다가온 배가 일반 배인 만화컷 1~2초
                        // Engine2_1 text 출력
                        // 엔딩씬으로 넘어감
                        // 엔딩 애니메이션 출력, EngineEnding text 출력
                    }
                    else if(32 < count && count <66)
                    {
                        // 섬 가까이 다가온 배가 해적선인 만화컷 1~2초
                        //Bottle2_2 text 출력
                        // 엔딩씬으로 넘어감
                        // 엔딩 실패 애니메이션 출력, PirateEnding text 출력
                    }
                    else
                    {
                        //섬 가까이 온 배가 부서져 떠밀려오고 옷, 상자 등이 떠밀려온 만화컷 1~2초
                        //Bottle2_3 text 출력
                        //선택지 출력
                    }

         *********************************************************************/
    }
    public void ClickGo()// 선택지 Yes 선택하는 Onclick 메소드
    {
        Debug.Log("클릭고");
        /*
         switch(textmeshpro.text =="")
         {
               case 물병 1번선택지 Yes 선택(물병을 가져간다) : 
               {
                    제작 창에 물병 추가
                    팝업 setactive(true) , Bottle1_1 text 출력
               }
               case (물병 2번 선택지,통신장치 선택지) Yes 선택(배를 탄다) : 
               {
                    TakeOnShip();
               }
               case 물병 3번 선택지 Yes 선택(떠내려온 식량을 챙긴다):
               {
                    //Bottle2_3_1 text 출력
                    //식량++, 재료++, 도구++;
                    //BottleTF = false;

                }
                case 인어 1번 선택지 Yes 선택 : 
                {
                    
                    MerDay = 현재날짜;
                    
                    
                }
                case 인어 2번 선택지 Yes 선택 : 
                {
                     MerDay = 현재날짜;
                    
                    

                }
                case 인어 최종 선택지 Yes 선택 :
                {
                //if(Random.Range(0,100)<a)
                    물고기다리를 밟고 탈출하는 만화컷
                    엔딩씬으로 넘어감
                        // 엔딩 애니메이션 출력, MerEnding text 출력
                }
                case 히어로 1번 선택지 Yes 선택 : 
                {
                    HeroDay = 현재날짜;

                }
                case 히어로 최종 선택지 Yes 선택 : 
                {
                    //if(Random.Range(0,100)<a)
                    하늘 위 히어로 등에 업혀서 멀리 섬의 마을이 보이는 만화컷
                    엔딩 씬 불러오기
                    엔딩 애니메이션, HeroEnding text 출력
                }
                case 꿈 최종 선택지 Yes 선택 : 
                {
                    //if(Random.Range(0,100)<a)
                    Dream3_1 text 출력
                    엔딩 씬 불러오기
                    엔딩 애니메이션, DreamEnding text 출력

                    else
                    {
                        Dream3_2 text 출력
                        //게임 이어서 진행
                    }
                }
                case 날개옷 1번 선택지 Yes 선택:
                {
                    엔딩 씬 불러오기
                    엔딩 애니메이션, WingEnding text 출력
                }
                case 무지개 1번 선택지 Yes(물을 받아놓는다) 선택 :
                {
                    Water++;
                    RainBow1_1 text 출력
                    하루 종료
                }
                case 무지개 2번 선택지 Yes(무지개를 보러간다) 선택 :
                {
                    맨 앞의 첫번째 캐릭터가 그날 일을 못한다.
                    하루를 끝낼 때 RainBow2_1 text 출력
                }
                case 무지개 최종 선택지 Yes 선택 :
                {
                    무지개 다리를 밟고 건너는 만화컷 
                    엔딩씬 불러오기
                    엔딩 애니메이션 , RainBowEnding text 출력
                }
                case 타임머신 사용 선택지 Yes 선택 : 
                {
                    if(Random.Range(0, 100)<50)
                    {
                        Time2 text 출력
                        타임머신에서 빛이 나오며 가동되는 만화컷 1~2초

                        방 침대에서 일어나 앉아있는 만화컷
                        Time2_1 text 출력
                        엔딩씬 불러오기
                        엔딩 애니메이션 , TimeEnding text 출력

                    }
                    else
                    {
                        Time2 text 출력
                        타임머신에서 빛이 나오며 가동되는 만화컷 1~2초

                        백악기시대, 공룡이 지나다니는 만화컷
                        엔딩씬 불러오기
                        엔딩 애니메이션, TimeFail text 출력

                    }
                }
                case 공간이동 사용 선택지 Yes 선택 :
                {
                    if(Random.Range(0,100)<마법사 공간이동 능력치 / 2)
                    {
                        마을 내부 만화컷
                        Space2 text 출력
                        엔딩씬 불러오기
                        엔딩 애니메이션 , SpaceEnding text 출력
                    }
                    else
                    {
                        전쟁터 내부 만화컷
                        엔딩씬 불러오기
                        엔딩 애니메이션, SpaceFail text 출력
                    }
                }
                case 빙판 1번 선택지 Yes 선택 : 
                {
                    제작 창에 빙판 추가
                    Ice1_1 text 출력
                    IceTF = true;
                }
                case 빙판 사용 선택지 Yes 선택 : 
                {
                    빙판위에 사람들이 타고 물고기가 끄는 만화컷
                    엔딩씬 불러오기
                    엔딩 애니메이션 , IceEnding text 출력
                }
                case 나뭇잎 1번 선택지 Yes 선택 : 
                {
                    제작 창에 나뭇잎 추가
                    LeafTF = false;
                }
                case 독수리 1번 선택지 Yes 선택 : 
                {
                    제작 창에 독수리 추가
                    EagleTF = false;
                }
                
                
         }
         */

    }

    public void ClickStop()// 선택지 No 선택하는 Onclick 메소드
    {
        Debug.Log("클릭스톱");
        /*
         switch(textmeshpro.text =="")
         {
               case 고래 No선택 : WhaleTF=false; 
               case 물병 No선택 : BottleTF=false; 
               case 물병 3번 선택지 No 선택(떠내려온 식량을 그냥 둔다) : 
               {
                    //Bottle2_3_2 text 출력
                    //양심인 업적 달성
                    //BottleTF = false;
                }
                case 인어 1번 선택지 No 선택 :
                {
                    MerTF=false;
                }
                case 인어 2번 선택지 No 선택 : 
                {
                    MerTF=false;
                }
                case 인어 최종 선택지 No:
                {
                    물고기다리가 무너지는 만화컷
                    
                    엔딩씬으로 넘어감
                        // 엔딩 애니메이션 출력, MerFail text 출력
                }
                case 히어로 최종 선택지 No:
                {
                    배경은 달, 히어로의 표정이 악마(웃고있음)  
                    엔딩씬으로 넘어감
                        // 엔딩 애니메이션 출력, HeroFail text 출력
                }

                case 꿈 1,2,3번 선택지 No 선택 : 
                {
                    DreamTF = false;
                }
                case 꿈 최종 선택지 No 선택 : 
                {
                    
                    엔딩 씬 불러오기
                    엔딩 애니메이션 ,DreamFail text 출력
                }
                case 날개옷 1번 선택지 No 선택 :
                {
                    //아무일도 없을지
                    //아니면 날개옷이 그냥 옷으로 변할지 정해야함
                }
                case 무지개 1번 선택지 No(하던일을 한다) 선택 :
                {
                    RainBow1_1 text 출력
                    하루 종료
                }
                case 무지개 2번 선택지 No 선택 :
                {
                    아무일도 없음
                    RainBowP = 4;
                }
                case 타임머신 사용 선택지 No 선택 :
                {
                    타임머신이 원래 단계의 통신장치로 변경
                }
                case 빙판 1번 선택지 No 선택 :
                {
                    아무일도 없음
                }
                case 빙판 사용 선택지 No 선택 : 
                {
                    제작창에서 빙판 삭제
                    IceTF = false;
                }
                case 나뭇잎 1번 선택지 No 선택 :
                {
                    LeafTF = false;
                    아무일도 x
                }
                case 독수리 1번 선택지 No 선택 : 
                {
                    EagleTF = false;
                    아무일도 x

                }


         }
         */

    }



    void WhaleEvent()//평상시 
    {
        if (WhaleTF == true)
        {
            switch (WhaleP)
            {

                case 0:
                    {
                        if (Random.Range(0, 100) == 0)
                        {
                            already = true;
                            
                            //WhaleDay = 현재날짜;

                            //섬이 흔들리는 만화컷 1~2초 대기 
                            //팝업창 setactive(true) -> Whale1 text, 선택지 출력

                            WhaleP = 1;
                            
                        }
                        break;
                    }

                case 1:
                    {
                        if (Random.Range(0, 100) < 3 /* && 현재날짜 > WhaleDay+20 */ )
                        {
                            already = true;

                            //WhaleDay = 현재날짜;

                            //섬이 흔들리는 만화컷 1~2초 대기
                            //팝업창 setactive(true) -> Whale2 text, 선택지 출력

                            WhaleP = 2;
                        }

                            break;
                    }

                case 2:
                    {
                        if (Random.Range(0, 100) < 5 /* && 현재날짜 > WhaleDay+10 */)
                        {
                            already = true;

                            //WhaleDay = 현재날짜;

                            //고래등 위에 섬이 있는 만화컷 1~2초 대기
                            //저 멀리 섬의 마을이 보이는 만화컷 1~2초 대기
                            //엔딩 씬으로 넘어감
                            //엔딩 애니메이션, WhaleEnding 출력

                            //게임 종료
                        }
                        break;

                    }

            }
            
        }
        else// WhaleTF == false
        {

        }

    }

   public void BottleEvent()//첫 이벤트는 탐험시, 나머지는 평상시
    {

        if (BottleTF == true)
        {

            switch (BottleP)
            {
                case 0: // 첫 이벤트는 그날 하루가 시작될 때 아무 이벤트도 진행되지 않았을 때만 실행 가능함 ∵already 때문
                    {
                        if (Random.Range(0, 100) == 0 && adven==true)
                        {
                            already = true;

                            Debug.Log("물병 획득");

                            //물병을 손에 들고 있는 만화컷 1~2초 대기 
                            //팝업창 setactive(true) -> Bottle1 text, 선택지 출력

                            BottleP = 1;
                            BottleTF = false; 
                            /**********************************************************************************/
                            // 물병을 주운 상황에서는 false 이고 물병을 사용했을 시 true로 바꿔준다.
                            // 물병 사용시 BottleEvent(); 호출 , 제작 창에서 물병 삭제
                            // 물병을 사용시에 BottleTF = true 와 BottleDay = 사용날짜;
                            /***********************************************************************************/

                        }
                        break;
                    }

                case 1:
                    {
                        if (Random.Range(0, 100) < 5 /* && 현재날짜 > BottleDay+20 */ )
                        {
                            already = true;

                            

                            //멀리 배가 다가오는 만화컷 1~2초 대기
                            //팝업창 setactive(true) -> Bottle2 text, 선택지 출력

                            BottleP = 2;
                        }

                        break;
                    }

                
            }
        }
    }

    void EngineEvent()//첫 이벤트는 평상시, 나머지는 사용시
    {
        if (EngineTF == true)
        {
            switch (EngineP)
            {

                case 0:
                    {
                        if (Random.Range(0, 100) <30)
                        {
                            already = true;

                            

                             
                            //팝업창 setactive(true) -> Engine0 text, 선택지 출력

                            EngineP = 1;
                            EngineTF = false;

                            /*********************************************************************************
                             * 통신장치 사용하는 메소드
                             * EngineTF = true;
                             * EngineDay = 사용날짜;
                             * 통신장치를 사용할 때 통신장치를 작동시키는 만화컷 1~2초
                             * 통신장치를 사용할 때 Engine1 text 출력
                             * EngineEvent();
                            ***********************************************************************************/
                        }
                        break;
                    }

                case 1:
                    {
                        int Percentage=0; // 가지고 있는 통신장치의 확률을 받아온다
                        if (Random.Range(0, 100) < Percentage)
                        {
                            already = true;



                            //통신장치를 사용중인 만화컷 1~2초 대기
                            //팝업창 setactive(true) -> Engine1_1 text, 선택지 출력

                            EngineP = 2;
                        }
                        else
                        {
                            already = true;
                            //통신장치가 망가지는 만화컷 1~2초
                            //Engine1_2 text 출력
                            EngineTF = false;
                        }

                        break;
                    }
                case 2:
                    {
                        if (Random.Range(0, 100) < 50 /*&& 현재날짜 > EngineDay+20 */ )
                        {
                            already = true;
                            EngineP = 3;
                            //멀리서 배가 다가오는 만화컷 1~2초
                            //Engine2 text 출력 , 선택지 출력

                        }
                        

                        break;
                    }

                

            }

        }
        else// EngineTF == false
        {

        }
    }

    void ShipEvent()//첫 이벤트는 평상시, 나머지는 사용시
    {
        if (ShipTF == true)
        {
            switch (ShipP)
            {

                case 0:
                    {
                        if (Random.Range(0, 100) < 30)
                        {
                            already = true;




                            //팝업창 setactive(true) -> Engine0 text, 선택지 출력

                            ShipP = 1;
                            ShipTF = false;
                           
                            /*********************************************************************************
                             * 배 사용하는 메소드
                             * ShipTF = true;
                             * 배가 바다에 떠있는 만화컷 1~2초
                             * 통신장치를 사용할 때 Ship1 text 출력
                             * ShipEvent();
                            ***********************************************************************************/
                        }
                        break;
                    }

                case 1:
                    {
                        int Percentage = 0; // 가지고 있는 배의 확률을 받아온다
                        if (Random.Range(0, 100) < Percentage)
                        {
                            already = true;



                            //저 멀리 섬이 보이는 만화컷 1~2초 대기
                            //팝업창 setactive(true) -> Ship1_1 text
                            //엔딩씬으로 넘어감
                            //엔딩 애니메이션 출력, ShipEnding text 출력

                            ShipP = 2;
                        }
                        else
                        {
                            already = true;
                            //배가 난파된 만화컷 1~2초
                            //Ship1_2 text 출력
                            //엔딩씬으로 넘어감
                            //엔딩 실패 애니메이션 출력, ShipFail text 출력
                            ShipTF = false;
                        }

                        break;
                    }
                



            }

        }
        else//ShipTF == false
        {

        }
    }

    public void MerEvent()//첫 이벤트는 평상시, 나머지는 낚시시 진행하게끔 만들어야함
    {
        if (MerTF == true)
        {
            switch (MerP)
            {

                case 0:
                    {
                        if (Random.Range(0, 100) < 30)
                        {
                            already = true;




                            // Mer0 text 출력

                            MerP = 1;
                            MerTF = false;

                            /*********************************************************************************
                             * 낚시를 하는 메소드에서
                             * fishing = true;
                             * MerEvent(); 호출
                             
                             
                            ***********************************************************************************/
                        }
                        break;
                    }
                case 1:
                    {
                        if (Random.Range(0, 100) < 5 && fishing == true)
                        {
                            already = true;
                            //MerDay = 현재날짜;
                            //저멀리 바다에서 사람이 수영하는 만화컷 1~2초
                            //Mer1 text, 선택지 출력
                            //MerP = 2;
                            
                        }

                        break;
                    }
                case 2:
                    {
                        if (Random.Range(0, 100) < 10 && fishing == true /*&& 현재날짜 >MerDay+30*/ )
                        {
                            already = true;
                            //MerDay = 현재날짜;
                            //저멀리 바다에서 사람이 수영하는 만화컷 1~2초
                            // Mer2 text , 선택지 출력
                            //MerP = 3;

                        }

                        break;
                    }
                case 3:
                    {
                        if (Random.Range(0, 100) < 20 /* && 현재날짜>MerDay+20*/)
                        {
                            already = true;

                            //해변가에서 인어맨 발견 만화컷
                            //Mer3 text 출력
                            //인어맨이 점점 멀어져가는 만화컷
                            //MerDay = 현재날짜;
                            //MerP = 4;
                        }

                        break;
                    }
                case 4:
                    {
                        if (true/*현재날짜 > MerDay+5*/)
                        {
                            already = true;
                            //해변가에서 인어맨 발견 만화컷
                            //Mer4 text 일부 출력
                            //물고기다리가 생긴 만화컷
                            //Mer4 text 나머지 출력
                            //선택지 출력
                        }
                            break;
                    }

                




            }

        }
        else//ShipTF == false
        {

        }
    }

    void HeroEvent()
    {
        if (HeroTF == true)
        {
            switch (HeroP)
            {

                case 0:
                    {
                        if (Random.Range(0, 100) < 30)
                        {
                            already = true;

                            
                            //Hero0 text 출력

                            HeroP = 1;

                        }
                        break;
                    }

                case 1:
                    {
                        if (Random.Range(0, 100) < 1 )
                        {
                            already = true;

                            //HeroDay = 현재날짜;

                            //하늘위에 뭔가 반짝거리는 만화컷 1~2초 대기
                            //팝업창 setactive(true) -> Hero1 text, 선택지 출력

                            HeroP = 2;
                        }

                        break;
                    }

                case 2:
                    {
                        if (Random.Range(0, 100) < 5 /* && 현재날짜 > HeroDay+30 */)
                        {
                            already = true;

                            //HeroDay = 현재날짜;
                            HeroP = 3;
                            //하늘위에 뭔가 반짝거리는 만화컷 1~2초 대기
                            //Hero2 text , 선택지 출력
                            
                        }
                        break;

                    }

                case 3:
                    {
                        if (Random.Range(0, 100) < 10 /*&&현재날짜>HeroDay=20*/)
                        {
                            already = true;
                            //히어로 등장 만화컷
                            //Hero3 text , 선택지 출력
                            //
                            

                        }
                        break;
                    }

            }

        }
        else// WhaleTF == false
        {

        }
    }

    void DreamEvent()
    {
        if (DreamTF == true)
        {
            switch (DreamP)
            {

                case 0:
                    {
                        if (Random.Range(0, 100) <30)
                        {
                            already = true;

                            //DreamDay = 현재날짜;

                            //팝업창 setactive(true) -> Dream0 text 출력

                            DreamP = 1;

                        }
                        break;
                    }

                case 1:
                    {
                        if (Random.Range(0, 100) < 1 /* && 현재날짜 > DreamDay+10 */ )
                        {
                            already = true;

                            //DreamDay = 현재날짜;

                            
                            //팝업창 setactive(true) -> Dream1 text, 선택지 출력

                            DreamP = 2;
                        }

                        break;
                    }

                case 2:
                    {
                        if (Random.Range(0, 100) < 3 /* && 현재날짜 > DreamDay+10 */)
                        {
                            already = true;

                            //DreamDay = 현재날짜;
                            //Dream2 text , 선택지 출력
                            DreamP = 3;
                            
                            

                      
                        }
                        break;

                    }
                case 3:
                    {
                        if (Random.Range(0, 100) < 5/* && 현재날짜 > DreamDay+20*/)
                        {
                            already = true;
                            DreamP = 4;
                            //방 침대에서 일어나 앉아 있는 만화컷
                            //Dream3 text, 선택지 출력
                        }

                        break;
                    }

            }

        }
        else// WhaleTF == false
        {

        }
    }

    void WingEvent()//날개옷을 사용할 때 호출
    {
        if (WingTF == true)
        {
           //Wing1 text , 선택지 출력
        }
    }

    void RainBowEvent() // 더운, 노말 맵에서만 호출
    {
        if (RainBowTF == true)
        {
            switch (RainBowP)
            {

                case 0:
                    {
                        if (Random.Range(0, 100) == 0)
                        {
                            already = true;

                            //RainBowDay = 현재날짜;

                            //하늘에 비가 오는 만화컷 1~2초 대기 
                            //팝업창 setactive(true) -> RainBow1 text, 선택지 출력

                            RainBowP = 1;

                        }
                        break;
                    }

                case 1:
                    {
                        if (Random.Range(0, 100) < 30 /* && 현재날짜 == RainBowDay+1 */ )
                        {
                            already = true;


                            //섬 반대편 저 멀리 무지개가 떠있는 만화컷 1~2초 대기
                            //팝업창 setactive(true) -> RainBow2 text, 선택지 출력

                            RainBowP = 2;
                        }

                        break;
                    }

                case 2:
                    {
                        if (Random.Range(0, 100) == 0 )
                        {
                            already = true;

                            //RainBowDay = 현재날짜;

                            //하늘에 비가 오는 만화컷 1~2초 대기 
                            //팝업창 setactive(true) -> RainBow3 text, 선택지 출력

                            RainBowP = 3;
                        }
                        break;

                    }
                case 3:
                    {
                        if (Random.Range(0, 100) < 30 /* && 현재날짜 == RainDay+1*/)
                        {
                            already = true;

                            // 섬 반대편 저 멀리 무지개가 떠있는 만화컷
                            // RainBow4 text, 선택지 출력
                            RainBowP = 4;
                        }
                        break;
                    }
                case 4:
                    {
                        if (Random.Range(0, 100) == 0)
                        {
                            already = true;

                            //RainBowDay = 현재날짜;

                            //하늘에 비가 오는 만화컷 1~2초 대기 
                            //팝업창 setactive(true) -> RainBow1 text, 선택지 출력

                            

                        }
                        break;
                    }

            }

        }
        else// WhaleTF == false
        {

        }
    }

    void TimeEvent() // 타임머신이 사용할 때 호출
    {
        if (TimeTF == true)
        {
            //Time1 text , 선택지 출력
        }
    }

    void SpaceEvent() // 마법사가 공간이동 사용할 떄 호출
    {
        if (SpaceTF == true)
        {
            switch (SpaceP)
            {
                case 0:
                    {
                        //Space1 text , 선택지 출력
                        

                        break;
                    }

            }
        }
    }

    void IceEvent() // 빙판 맵에서만 호출
    {
        if (IceTF == true)
        {
            switch (IceP)
            {
                case 0:
                    {
                        if (Random.Range(0, 100) == 0 && adven == true)
                        {
                            already = true;
                            //바다위에 거대한 빙판이 떠다니는 만화컷
                            //Ice1 text , 선택지 출력
                            IceTF = false;
                            IceP = 1;
                            /***********************************************
                             *  
                             * 
                             * **********************************************/
                        }

                        break;
                    }
                case 1:
                    {
                        //if(인벤토리에 요리되지 않은 물고기>99)
                        {
                            //Ice2 text , 선택지 출력 
                        }

                        break;
                    }
            }
        }
    }

    void LeafEvent() // 정글 맵에서만 호출
    {
        if (LeafTF == true)
        {
            switch (LeafP)
            {
                case 0:
                    {
                        if (Random.Range(0, 100) == 0 && adven == true)
                        {
                            already = true;
                            LeafP = 1;
                            //거대한 나뭇잎을 발견한 만화컷
                            //Leaf1 text , 선택지 출력
                            
                            //나뭇잎 제작창에서 사용시 , LeafTF = true , LeafEvent() 호출

                        }

                        break;
                    }
                case 1:
                    {
                        if (Random.Range(0, 100) < 10)
                        {
                            //저 멀리 마을이 보이는 만화컷
                            //엔딩 씬 불러오기
                            //엔딩 애니메이션, LeafEnding text 출력
                        }
                        else
                        {
                            //물에 빠진 만화컷
                            //엔딩 씬 불러오기
                            //엔딩 애니메이션, LeafFail text 출력
                        }
                        break;
                    }
            }
        }

    }

    public void EagleEvent()
    {
        if (EagleTF == true)
        {
            switch (EagleP)
            {
                case 0:
                    {
                        if (Random.Range(0, 100) == 0 && hunting == true)
                        {
                            already = true;
                            EagleP = 1;
                            EagleTF = false;
                            //거대한 독수리를 발견한 만화컷
                            //Eagle1 text , 선택지 출력

                            //독수리 제작창에서 탈출 사용시 , EagleTF = true , EagleEvent() 호출
                            //탐험시 독수리를 타고 다른섬으로 가서 파밍(재료, 도구, 음식 세가지 전부 파밍 가능)

                        }

                        break;
                    }
                case 1://독수리 사용시
                    {
                        if (Random.Range(0, 100) < 50)
                        {
                            //하늘에서 저 멀리 마을이 보이는 만화컷
                            //엔딩 씬 불러오기
                            //엔딩 애니메이션, EagleEnding text 출력
                        }
                        else
                        {
                            //독수리 둥지에 데려간 만화컷
                            //엔딩 씬 불러오기
                            //엔딩 애니메이션, EagleFail text 출력
                        }
                        break;
                    }
            }
        }
    }
}
