namespace shared.Model;

public class PN : Ordination
{
    public double antalEnheder { get; set; }
    public List<Dato> dates { get; set; } = new List<Dato>();

    public DateTime startDato;
    public DateTime slutDato;

    public PN(DateTime startDen, DateTime slutDen, double antalEnheder, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen)
    {
        this.antalEnheder = antalEnheder;
        this.startDato = startDen.Date;
        this.slutDato = slutDen.Date;
    }

    public PN() : base(null!, new DateTime(), new DateTime())
    {
    }

    /// <summary>
    /// Registrerer at der er givet en dosis på dagen givesDen
    /// Returnerer true hvis givesDen er inden for ordinationens gyldighedsperiode og datoen huskes
    /// Returner false ellers og datoen givesDen ignoreres
    /// </summary>
    public bool givDosis(Dato givesDen)
    {
        if (givesDen.dato < startDato)
        {
            throw new InvalidDataException("Dato må ikke være før forløbets start dato");
        }else if (givesDen.dato > slutDato){
            throw new InvalidDataException("Dato må ikke være efter forløbets slut dato");
        }
        else {
            dates.Add(givesDen);
        }
        return true;
    }

    public override double doegnDosis()
    {
        Dato firstOrdination;
        Dato lastOrdination;
        if (dates.Count > 0)
        {
            firstOrdination = dates[0];
            lastOrdination = dates[0];
        }
        else
        {
            return 0;
        }
        foreach (Dato date in dates)
        {
            if (firstOrdination.dato > date.dato)
            {
                firstOrdination = date;
            }
            if (lastOrdination.dato < date.dato)
            {
                lastOrdination = date;
            }
        }
        double antalDage;
        if (lastOrdination.dato == firstOrdination.dato)
        {
            antalDage = 1;
        }
        else
        {
            antalDage = (lastOrdination.dato - firstOrdination.dato).TotalDays;
            antalDage++;
        }

        return Math.Round((antalEnheder * dates.Count / (antalDage)), 2);
    }


    public override double samletDosis()
    {
        return dates.Count() * antalEnheder;
    }

    public int getAntalGangeGivet()
    {
        return dates.Count();
    }

    public override String getType()
    {
        return "PN";
    }
}
