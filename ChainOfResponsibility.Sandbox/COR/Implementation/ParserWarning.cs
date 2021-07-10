namespace ChainOfResponsibility.Sandbox.COR.Implementation
{
    public class ParserWarning
    {
        public bool IsCritical { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return !string.IsNullOrEmpty(FieldName)
                ? $"FieldName={FieldName}, FieldValue={FieldValue}, Message={Message}, IsCritical={IsCritical}"
                : $"Message={Message}, IsCritical={IsCritical}";
        }
    }
}
