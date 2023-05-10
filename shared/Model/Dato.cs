namespace shared.Model;

public class Dato {
    public int DatoId { get; set; }
    public DateTime dato { get; set; }

    public override String ToString()
    {
        return "Dato: " + dato.ToShortDateString() + " Kl: " + dato.ToLongTimeString();
    }
}