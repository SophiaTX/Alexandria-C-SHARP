namespace Alexandria.net.Mapping
{
    public class CSharpToCPP
    {
        public const string Vote = "vote_for_witness";


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