# Week3_Standard
 
Q1 분석 문제

1. 입문 주차와 비교해서 입력 받는 방식의 차이와 공통점을 비교해보세요.

입문 주차에서는 Send Massages를 이용하여 어떤 객체에 있는지 알아야 입력에 대한 기능을 제공했다면
현재는 Invoke Unity Events를 사용하여 버튼 클릭과 같이 해당 오브젝트에 어떤 기능을 하도록 할지 설정할 수 있다.
공통점은 둘 모두 On+InputAction의 Actions이름과 같이 함수명을 만들어야 하는 것이다.


2. CharacterManager와 Player의 역할에 대해 고민해보세요.

ChracterManager는 싱글톤 패턴으로 만들어서 필수 데이터들을 GetComponent 사용을 줄여 재사용성을 높인다.
Player는 캐릭터가 필요한 전반적인 데이터나 기능들을 가진다.


3. 핵심 로직을 분석해보세요 (Move, CameraLook, IsGrounded)

Move : 입력값의 x, y 축이 transform.position의 x, y랑 다르기 때문에 제대로 작동하도록 입력의 y축을 transform.position의 z축이 되도록 설정한다.
CameraLook : mouseDelta의 x축이 이동할 때 화면은 y축으로 회전해야 하고 y축으로 이동할 때는 x축으로 회전해야 하기 때문에 제대로 작동되도록 설정한다.
IsGrounded : Ray를 Player의 앞, 뒤, 오른쪽, 왼쪽에 하나씩 아래 방향을 향하도록 설정한 후 해당 지점에 Ground인지 아닌지 확인한다.


4. Move와 CameraLook 함수를 각각 FixedUpdate, LateUpdate에서 호출하는 이유에 대해 생각해보세요.

Move는 velocity를 변경함으로써 물리적인 업데이트가 필요하기 때문에 FixedUpdate를 사용하는 것이고
CamaraLook은 모든 업데이트가 끝난 후에 실행되도록 LateUpdate를 사용하는 것이다.


Q2 분석 문제

1. 별도의 UI 스크립트를 만드는 이유에 대해 객체지향적 관점에서 생각해보세요.

별도의 UI 스크립트를 작성하므로써 각 객체에 어떤 기능을 하는지 명확하게 알 수 있고 Inspector 창에 해당 스크립트를 add Component 할 수 있다.


2. 인터페이스의 특징에 대해 정리해보고 구현된 로직을 분석해보세요.

인터페이스는 클래스와 달리 선언만 하고 구현을 한다.
클래스는 인터페이스를 통해 다중 상속을 실현할 수 있으며 언터페이스에 있는 함수들을 모두 구현해야만 한다.

3. 핵심 로직을 분석해보세요. (UI 스크립트 구조, CampFire, DamageIndicator)

IDamageable 인터페이스를 상속받아 불에 닿았을 경우에 thing에 인터페이스를 추가하고 불에 닿고 나갔을 경우에는 인터페이스 리스트를 삭제시킨다.
인터페이스에 있는 TakePhysicalDamage 를 통해 PlayerCondition에 구현되어있는 TakePhysicalDamage 를 실행시켜 데미지를 입힌다.


