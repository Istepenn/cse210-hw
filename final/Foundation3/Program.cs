using System;

class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Address { get; set; }

    public virtual string GenerateMarketingMessage()
    {
        return $"Join us for {Title} on {Date}. {Description}. Address: {Address}";
    }
}

class LectureEvent : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public override string GenerateMarketingMessage()
    {
        return base.GenerateMarketingMessage() + $" Speaker: {Speaker}. Capacity: {Capacity}";
    }
}

class ReceptionEvent : Event
{
    public string RSVPInfo { get; set; }

    public override string GenerateMarketingMessage()
    {
        return base.GenerateMarketingMessage() + $" RSVP: {RSVPInfo}";
    }
}

class OutdoorEvent : Event
{
    public string WeatherForecast { get; set; }

    public override string GenerateMarketingMessage()
    {
        return base.GenerateMarketingMessage() + $" Weather Forecast: {WeatherForecast}";
    }
}

class Program3
{
    static void Main(string[] args)
    {
        Event lecture = new LectureEvent
        {
            Title = "Tech Talk",
            Description = "Discussing the latest tech trends",
            Date = DateTime.Now.AddDays(7),
            Address = "123 Main St",
            Speaker = "John Doe",
            Capacity = 100
        };

        Event reception = new ReceptionEvent
        {
            Title = "Networking Mixer",
            Description = "An evening of networking and socializing",
            Date = DateTime.Now.AddDays(14),
            Address = "456 Elm St",
            RSVPInfo = "RSVP to attend"
        };

        Event outdoor = new OutdoorEvent
        {
            Title = "Picnic in the Park",
            Description = "Enjoy a day outdoors with food and games",
            Date = DateTime.Now.AddDays(21),
            Address = "789 Oak St",
            WeatherForecast = "Sunny skies"
        };

        Console.WriteLine(lecture.GenerateMarketingMessage());
        Console.WriteLine(reception.GenerateMarketingMessage());
        Console.WriteLine(outdoor.GenerateMarketingMessage());
    }
}
