using System;

public class SpaceAge
{
    double _seconds;
    private const double EARTH_SECONDS = 31_557_600;
    private const double Mercury_PERIOD = 0.2408467;
    private const double Venus_PERIOD = 0.61519726;
    private const double Mars_PERIOD = 1.8808158;
    private const double Jupiter_PERIOD = 11.862615;
    private const double Saturn_PERIOD = 29.447498;
    private const double Uranus_PERIOD = 84.016846;
    private const double Neptune_PERIOD = 164.79132;
    public SpaceAge(int seconds)
    {
        _seconds = seconds;
    }

    
    public double OnEarth() => _seconds / EARTH_SECONDS;

    public double OnMercury() => Math.Round(_seconds / (EARTH_SECONDS * Mercury_PERIOD), 2);

    public double OnVenus() => Math.Round(_seconds / (EARTH_SECONDS * Venus_PERIOD), 2);

    public double OnMars() => Math.Round(_seconds / (EARTH_SECONDS * Mars_PERIOD), 2);

    public double OnJupiter() => Math.Round(_seconds / (EARTH_SECONDS * Jupiter_PERIOD), 2);

    public double OnSaturn() => Math.Round(_seconds / (EARTH_SECONDS * Saturn_PERIOD), 2);

    public double OnUranus() => Math.Round(_seconds / (EARTH_SECONDS * Uranus_PERIOD), 2);

    public double OnNeptune() => Math.Round(_seconds / (EARTH_SECONDS * Neptune_PERIOD), 2);
}