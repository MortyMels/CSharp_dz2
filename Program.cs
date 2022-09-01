bool r = true;
while(r){
    Console.WriteLine("Введите несколько наборов из трех чисел в формате '0.0, 0.0, 0.0;'");

    string s = Console.ReadLine().Replace(" ", "");
    string[] sa = s.Split(';'); //разбили на точки
    double[,] cl = new double[2,3];
    object[] clc = {};
    bool fi = true;
    foreach (var san in sa)
    {
        string[] sani = san.Split(','); //x, y, z

        try{ //проверка на корректность ввода координат 
            if(sani.Length==3){
                bool f = true;

                int i = 0;
                
                foreach (var sanin in sani)
                {
                    try { //проверка на корректность ввода числа
                        double saninb = double.Parse(sanin);
                        cl[1,i++]=saninb;
                    } catch {
                        f=false;
                        Console.WriteLine($"Нераспознаный символ '{sanin}' координат: {String.Join(", ", sani)}");
                    }
                }
                if(!fi&f){
                    Console.WriteLine($"Расстояние между точками ({cl[0,0]},{cl[0,1]},{cl[0,2]}) и ({cl[1,0]},{cl[1,1]},{cl[1,2]}) = { Math.Sqrt(cl[0,0]*cl[1,0]+cl[0,1]*cl[1,1]+cl[0,2]*cl[1,2])}");
                }
                if(f){
                    fi=false;
                    cl[0,0]=cl[1,0];
                    cl[0,1]=cl[1,1];
                    cl[0,2]=cl[1,2];
                }
            }else{
                Console.WriteLine($"Неверное количество параметров в координатах: {san}");
            }
        } catch {
            Console.WriteLine($"Координаты введены некорректно: {san}");
        }
    }
    r=false;
}