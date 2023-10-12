using System;
using System.Reflection.PortableExecutable;
using NAudio.Vorbis;
using NAudio.Wave;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Podaj nazwę pliku OGG jako argument.");
            return;
        }
        string audioFile = args[0];
        if (CheckAudio(audioFile)==1)
        {
            PlayAudio(audioFile);
        }
    }
    static int CheckAudio(string audioFile)
    {
        if (!File.Exists(audioFile))
        {
            Console.WriteLine("Plik nie istnieje.");
            return 0;
        }
        if (!audioFile.Contains(".ogg"))
        {
            Console.WriteLine("Format pliku jest niewlasciwy.");
            return 0;
        }
        return 1;
    }
    static void PlayAudio(string audioFile)
    {   
        using (var audio = new VorbisWaveReader(audioFile))
        using (var outputDevice = new WaveOutEvent())
        {
            outputDevice.Init(audio);
            outputDevice.Play();

            Console.WriteLine($"Odtwarzanie pliku: {audioFile}");
            Console.WriteLine("Naciśnij Enter, aby zakończyć...");
            Console.ReadLine();
        }
    }
}