bool r = true; //Длинна вектора dz3
Console.Clear();
    
while(r){
    Console.WriteLine("Введите несколько наборов из трех чисел в формате '0.0, 0.0, 0.0;'");
    string s = Console.ReadLine().Replace(" ", "");
    string[] sa = s.Split(';'); //разбили на точки
    double[][] cl = new double[2][];
    bool fi = true;
    foreach (var san in sa)
    {
        bool f = true;
        cl[0]=StrToIntAr(san,true);

        if((cl[0].Length-1==3)){
            if (cl[0][0]==0){
                if(!fi){
                    Console.WriteLine($"Расстояние между точками ({cl[0][1]},{cl[0][2]},{cl[0][3]}) и ({cl[1][1]},{cl[1][2]},{cl[1][3]}) = { Math.Sqrt(Math.Pow(cl[0][1]-cl[1][1],2)+Math.Pow(cl[0][2]-cl[1][2],2)+Math.Pow(cl[0][3]-cl[1][3],2))}");
                }
                fi=false;
                cl[1]=cl[0];
            }
        }else{
            Console.WriteLine($"Неверное количество параметров в координатах: {san}");
        }
    }
    if (s=="end"){
        r=false;
    }
    
}

double[] StrToIntAr(string str, bool err) {
    string[] stra = str.Split(',');
    double[] numa = new double [stra.Length+1];
    int i = 0;
    foreach (string strai in stra){
        if(!double.TryParse(strai, out numa[++i])){
            if(err){
                Console.WriteLine($"Нераспознан {i} элемента набора '{strai}' в: {str}");
            }
            numa[0]++;
        }
    }
    return numa;
}