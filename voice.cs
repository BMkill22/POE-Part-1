using System.IO;
using System.Media;
using System;

namespace POE_Part_1
{
    public class voice
    {
        
        //constructor
        public voice()
        {
            //now get where the project is
            string project_location = AppDomain.CurrentDomain.BaseDirectory;

            //replaying the bin\deburg to get the audio
            string undated_path = project_location.Replace("bin\\Debug\\", "");

            //combine the wav name as Greeting.wav with update path
            string full_path = Path.Combine(project_location, "Greeting.wav");

            //now i am passing it to the method play_wav
            voice_play(full_path);


        }//end of constractor

        //This is the method to playing the voice
        private void voice_play(string full_path)
        {
            //this is try and catch
            try
            {

                //play the sound
                using (SoundPlayer player = new SoundPlayer(full_path))
                {
                    //this is to play sound till end
                    player.PlaySync();


                }//end of use

            }
            catch (Exception error)
            {

                //Showing the error message
                Console.WriteLine(error.Message);
            }
        }//end of constructor
    }//end of class
}//end of namespace