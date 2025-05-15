namespace SingletonApp
{
    public sealed class Singleton
    {
        // 싱글톤의 생성자는 `new` 연산자를 사용한 직접적인 생성 호출을 방지하기 위해 항상 private
        private Singleton() { }

        // 싱글턴 인스턴스는 정적 필드에 저장됩니다.이 필드를 초기화하는 방법은 여러 가지가 있으며, 
        // 각 방법마다 장단점이 있습니다.이 예제에서는 가장 간단한 방법을 보여드리겠지만, 
        // 멀티스레드 프로그램에서는 제대로 작동하지 않습니다.
        private static Singleton _instance;

        // 이는 싱글톤 인스턴스에 대한 액세스를 제어하는 ​​정적 메서드입니다.
        // 첫 번째 실행에서는 싱글톤 객체를 생성하여 정적 필드에 배치합니다. 
        // 이후 실행에서는 정적 필드에 저장된 클라이언트의 기존 객체를 반환합니다.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        // 모든 싱글톤은 인스턴스에서 실행될 수 있는 비즈니스 로직을 정의해야 합니다
        public void someBusinessLogic()
        {
            // ...
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 클라이언트 코드
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("싱글톤은 작동합니다. 두 변수 모두 동일한 인스턴스를 포함합니다.");
            }
            else
            {
                Console.WriteLine("싱글톤이 실패했습니다. 변수에 다른 인스턴스가 포함되어 있습니다.");
            }
        }
    }
}
