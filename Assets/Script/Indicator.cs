
public class Indicator
{
    public string DateAndTime { get; set; }
    //Range 0 - 5000 ppm
    public float Eco2 { get; set; }
    //Range 10 - 30 C
    public float Temp { get; set; }

    //Range 0 - 3 mg/m^3
    /*Low TVOC concentration levels is considered to be less than 0.3 mg/m3. Acceptable levels of TVOC ranges from 0.3 to 0.5 mg/m3 of concentration. 
     * From 0.5 mg/m3 of TVOC concentration level onwards the concern is considered to be considerable or high.
     */
    public float Tvoc { get; set; }

    public string Stringfy (){
        return "Date & Time: " + DateAndTime + "\nEco2: " + Eco2 + " ppm\nTemp: " + Temp + " c\nTvoc: " + Tvoc + " mg/m^3";
    }


}
