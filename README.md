# Yacht_Dice_C#모작
## 프로젝트 설명
요트다이스/야추다이스
(나무위키)  https://namu.wiki/w/%EC%9A%94%ED%8A%B8(%EC%A3%BC%EC%82%AC%EC%9C%84)
![image](https://github.com/user-attachments/assets/1dc780e7-544b-4773-aa05-03122fc81675)

간단하게 설명하자면, 주사위를 사용해 포커처럼 '족보'를 만드는 게임이다. 
주사위를 최대 세 번까지 던져서 맞는 족보를 만든 후 점수를 얻어내는 게 목표다.
애초에 기록 가능한 점수를 보여주기 때문에 뭐가 몇 점이고 하는 걸 일일이 외울 필요 없이 그냥 점수판에 맞춰 넣으면 된다.



![image](https://github.com/user-attachments/assets/c18a7de5-a99b-4ad8-9429-fd2961c5c7ec)

https://www.youtube.com/watch?v=HidpDk1ML5E&list=PLrTC7IMrpfqIqjyPh7YA_iYu5e98y_ufr

발표 PPT

https://www.canva.com/design/DAGap8Bb7Xs/sTcTI1FiTkjlYGP3I5DsxA/view?utm_content=DAGap8Bb7Xs&utm_campaign=designshare&utm_medium=link2&utm_source=uniquelinks&utlId=h4a34629ed3

## 기능 목록
1. 게임 시작/종료(12라운드)
2. 주사위 세팅 (배열로 설정)
3. 주사위 굴리는 효과(최대 3번)
4. 주사위 멈추기
5. 주사위 선택한거 빼고 다시 굴리기(선택이 된 주사위 false 나머지 true로 다시 굴리기)
6. 점수판 족보만들기
7. 점수판 주사위값 들고와서 멈출때마다 미리 화면에 표시
8. 점수판 입력받은 값은 고정시키기 (주사위 선택과 마찬가지)


## 게임 흐름 
1. 게임 시작, 게임 설명, 종료 중 선택
2. 주사위 굴리기 버튼과 주사위 세팅
3. ChooseDice로 멈춘 주사위 중 고정할거 세팅 후 다시 굴리기
4. 주사위 멈출때마다 점수판에 미리 입력숫자 알려주기
5. 점수판에다 점수 넣기
6. 점수판 다 채우면 게임종료, 종료시 점수판 합 출력

## 클래스 설계
1. Dice : 배열로 설정 랜덤출력, 주사위값 반환
2. Player : Dice값을 받고 들고있기.  첫 주사위 다시 굴릴수 있게 바꿔주기
3. ScoreBoard : 보드 출력, 보드에 점수 적는것,현재 dice를 대입해서 족보 연산, 대입한 족보는 그 값을 반환후 멈춰놓기, 게임끝날시 모든값의 합 출력
4. GameManager : 게임시작, 게임종료. 주사위 3번 굴리면 점수판 이동후 적으면 라운드++ ,주사위 굴리는 효과,주사위 고정, 스코어 선택창,값 비교
5. IntroScreen : 게임 시작 화면 1,2,3 선택

## 단계별 해야할 구성요소
1. Dice를 만들때 필요한 1차원 배열 6개
2. 주사위를 굴리지 못할때 필요한 bool값 1차원 배열 6개
3. 반복문을 사용하여 주사위 3번을 굴리는데 if로 선택한 주사위들 안굴리기
4. 컴퓨터 주사위를 굴리고 6개중에 가장 높고 겹치는 숫자가 많으면 그숫자 false로 만드는 ai
6. 컴퓨터 주사위를 굴렸는데 1,2,3,4 등등 순서대로 뜰시 small, large straight 점수판에 남아있는지 확인후 안겹칠시 돌리지말고 점수판 입력
7. 점수판에 점수를 쓰면 그곳은 false로 남아있는 점수만 계속 출력
8. 점수판 족보 계산하는 알고리즘 , 족보 계산하고 점수 입력할때 또 다른 알고리즘
9. 12턴이 끝난후 합계한 점수 합산 
10. 나머지 코드들 작성 후 추가된거 입력하겠습니다 

