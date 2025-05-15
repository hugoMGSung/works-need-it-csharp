## 디자인 패턴

### 개요
- **디자인 패턴(Design Patterns)**은 자주 반복되는 소프트웨어 설계 문제를 해결하기 위한 코드 작성 방식

### 목적
- 코드 재사용성 증가
- 유지보수 용이
- 설계 구조 표준화
- 팀 간 협업 향상

### 디자인 패턴의 3가지 분류
1. 생성 패턴(Creational Patterns) : 객체를 생성하는 방식을 정의
    - `Singleton` - 오직 하나의 인스턴스만 존재하도록 보장
    - `Factory Method` - 객체 생성을 서브클래스에 위임
    - `Abstract Factory` - 관련 객체들을 일관성 있게 생성
    - `Builder` - 복잡한 객체를 단계별로 생성
    - `Prototype` - 객체를 복사하여 생성 (깊은 복사 등)

2. 구조 패턴(Structural Patterns) : 클래스나 객체를 조합해 더 큰 구조를 만들때 사용
    - `Adapter` - 서로 다른 인터페이스를 호환시키는 패턴
    - `Decorator` - 기능을 동적으로 추가하는 패턴
    - `Facade` - 복잡한 시스템을 단순한 인터페이스로 제공
    - `Composite` - 트리 구조로 표현(예: UI 요소)
    - `Bridge` - 구현과 추상화를 분리
    - `Proxy` - 객체에 대한 접근을 제어

3. 행위 패턴(Behavioral Patterns) : 객체 간의 통신, 책임 분산을 정의
    - `Observer` - 상태 변화에 따라 구독자에 알림
    - `Strategy` - 알고리즘을 캡슐화해 교체 가능하게
    - `Command` - 요청을 객체로 캡슐화
    - `State` - 객체의 상태에 따라 행동 변경
    - `Template Method` - 알고리즘 구조를 정의하고 일부 단계는 하위 클래스에서 구현
    - `Mediator` - 객체 간의 복잡한 통신을 중앙 집중식으로 관리