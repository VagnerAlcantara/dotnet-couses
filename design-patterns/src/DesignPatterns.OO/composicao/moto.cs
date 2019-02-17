class Moto
{
    private string Cor { get; set; }
    private Roda Roda1 { get; set; }
    private Roda Roda2 { get; set; }

    public Moto(string cor, Roda roda1, Roda roda2)
    {
        Cor = cor;
        Roda1 = roda1;
        Roda2 = roda2;
    }

}
