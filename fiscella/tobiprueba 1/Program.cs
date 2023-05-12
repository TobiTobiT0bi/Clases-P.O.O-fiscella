using System.Linq;
using System;

class Electrodomestico
{
    private float precio_base = 100;
    private string color = "blanco";
    private char consumo_energetico = 'F';
    private float peso = 5;

    public Electrodomestico() { }

    public Electrodomestico(float peso, float precio)
    {
        this.precio_base = precio;
        this.peso = peso;
    }
    public Electrodomestico(float precio, string color, float peso, char consumo_energetico)
    {
        this.precio_base = precio;
        this.peso = peso;
        comprobarConsumoEnergetico(consumo_energetico);
        comprobarColor(color);
    }
    public float Precio_base
    {
        get
        {
            return this.precio_base;
        }
    }
    public string Color
    {
        get
        {
            return this.color;
        }
    }
    public char Consumo_energetico
    {
        get
        {
            return this.consumo_energetico;
        }
    }
    public float Peso
    {
        get
        {
            return this.peso;
        }
    }
    private void comprobarConsumoEnergetico(char c)
    {
        const string letras_posbles = "ABCDEF";
        if (letras_posbles.Contains(c))
        {
            this.consumo_energetico = c;
        }
        else
        {
            this.consumo_energetico = 'F';
        }
    }
    private void comprobarColor(string s)
    {
        const string colores_posibles = "BLANCONEGROROJOAZULGRIS";
        if (colores_posibles.Contains(s.ToUpper()))
        {
            this.color = s.ToUpper();
        }
        else
        {
            this.color = "BLANCO";
        }
    }
    public float precioFinal()
    {
        float precio = precio_base;
        switch (this.consumo_energetico)
        {
            case 'A':
                precio_base += 100;
                break;
            case 'B':
                precio_base += 80;
                break;
            case 'C':
                precio_base += 60;
                break;
            case 'D':
                precio_base += 50;
                break;
            case 'E':
                precio_base += 30;
                break;
            case 'F':
                precio_base += 10;
                break;
        }
        if (this.peso > 0 && this.peso < 19)
        {
            this.peso += 10;
        }
        else if (this.peso > 20 && this.peso < 49)
        {
            this.peso += 50;
        }
        else if (this.peso > 50 && this.peso < 79)
        {
            this.peso += 80;
        }
        else if (this.peso > 80)
        {
            this.peso += 100;
        }

        return precio;
    }

}

class Lavadora : Electrodomestico
{
    private int carga = 5;
    public Lavadora() { }

    public Lavadora(float peso, float precio) : base(peso, precio) { }
    public Lavadora(float precio, string color, float peso, char consumo_energetico, int carga) : base(peso, color, peso, consumo_energetico)
    {
        this.carga = carga;
    }
    public int Carga
    {
        get
        {
            return this.carga;
        }
    }

    public float precioFinal()
    {
        float precio = base.precioFinal();
        if (this.carga > 30)
        {
            precio += 50;
        }
        return precio;
    }
}
class Television : Electrodomestico
{
    private float resolucion = 20;
    private bool sintonizador = false;

    public Television() : base() { }
    public Television(float peso, float precio) : base(peso, precio) { }

    public Television(float precio, string color, float peso, char consumo_energetico, float resolucion, bool sintonizador) : base(precio, color, peso, consumo_energetico)
    {
        this.sintonizador = sintonizador;
        this.resolucion = resolucion;
    }
    public float Resolucion
    {
        get
        {
            return this.resolucion;
        }
    }
    public bool Sintonizador
    {
        get
        {
            return this.sintonizador;
        }
    }

    public float precioFinal()
    {
        float precio = base.precioFinal();
        if (this.sintonizador)
        {
            precio += 50;
        }
        if (this.resolucion > 40)
        {
            precio *= 1.30F;
        }
        return precio;
    }
}
class Ejecutable
{
    static void Main(string[] args)
    {
        Electrodomestico[] electrodomesticos = new Electrodomestico[10];
        electrodomesticos[0] = new Television(10, 15);
        electrodomesticos[1] = new Lavadora(15, 58);
        electrodomesticos[2] = new Television(10, "blanco", 45, 'D', 20, true);
        electrodomesticos[3] = new Lavadora(85, "gris", 32, 'A', 29);
        electrodomesticos[4] = new Lavadora();
        electrodomesticos[5] = new Television();
        electrodomesticos[6] = new Television(15, 65);
        electrodomesticos[7] = new Lavadora(34, 77);
        electrodomesticos[8] = new Lavadora(23, 32);
        electrodomesticos[9] = new Television(98, "rojo", 65, 'B', 47, false);
        int televisores = 0, lavarropas = 0;
        foreach (Electrodomestico e in electrodomesticos)
        {
            //e.precioFinal();


            if (e is Television)
            {
                televisores++;
            }
            if (e is Lavadora)
            {
                lavarropas++;
            }
        }
        Console.WriteLine("Televisores: {0} \n Lavarropas: {1} \n Electrodomesticos: {2}", televisores, lavarropas, televisores + lavarropas);

    }
}
