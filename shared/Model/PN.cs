namespace shared.Model;

public class PN : Ordination {
	public double antalEnheder { get; set; }
    public List<Dato> dates { get; set; } = new List<Dato>();

    public PN (DateTime startDen, DateTime slutDen, double antalEnheder, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen) {
		this.antalEnheder = antalEnheder;
	}

    public PN() : base(null!, new DateTime(), new DateTime()) {
    }

    /// <summary>
    /// Registrerer at der er givet en dosis på dagen givesDen
    /// Returnerer true hvis givesDen er inden for ordinationens gyldighedsperiode og datoen huskes
    /// Returner false ellers og datoen givesDen ignoreres
    /// </summary>
    public bool givDosis(Dato givesDen) {
        dates.Add(givesDen);
        return true;
    }

    public override double doegnDosis() {
        Dato firstOrdination;
        Dato lastOrdination;
        if (dates.Count > 0){
            firstOrdination = dates[0];
            lastOrdination = dates[0];
        }else {
            return -1;
        }

        
    	foreach(Dato date in dates){
            if (firstOrdination.dato > date.dato){
                firstOrdination = date;
            }
            if (lastOrdination.dato < date.dato){
                lastOrdination = date;
            }
        }
        double antalDage = (lastOrdination.dato-firstOrdination.dato).TotalDays;
        if (antalDage < 1){
            antalDage = 1;
        }
        
        return Math.Round((antalEnheder * dates.Count / (antalDage))) ; 
    }


    public override double samletDosis() {
        return dates.Count() * antalEnheder;
    }

    public int getAntalGangeGivet() {
        return dates.Count();
    }

	public override String getType() {
		return "PN";
	}
}
