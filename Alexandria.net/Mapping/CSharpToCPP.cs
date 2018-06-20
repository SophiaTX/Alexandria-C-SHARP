namespace Alexandria.net.Mapping
{
    public class CSharpToCPP
    {
        private const string Vote = "vote_for_witness";


        public string GetValue(string value)
        {
            switch (value)
            {
                case Vote:
                    return Vote;
            }

            return string.Empty;
        }
    }
}