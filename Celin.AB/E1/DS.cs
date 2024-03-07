namespace Celin.F9210
{
    public record Row(
        string F9210_DTAI,
        string F9210_OWTP,
        int F9210_DTAS,
        string F9210_CDEC);
    public record Response : AIS.FormResponse
    {
        public AIS.Form<AIS.FormData<Row>>? fs_DATABROWSE_F9210 { get; init; }
        public AIS.Form<AIS.FormData<Row>> Form
            => fs_DATABROWSE_F9210 ?? throw new ArgumentNullException(nameof(Response));
    }
    public class Request : AIS.DatabrowserRequest
    {
        public Request(AIS.Query q)
        {
            outputType = GRID_DATA;
            dataServiceType = BROWSE;
            targetName = nameof(F9210);
            targetType = table;
            returnControlIDs = "DTAI|OWTP|DTAS|CDEC";
            query = q;
        }
    }
}
namespace Celin.W01012B
{
    public static class Actions
    {
        public const string Select = "14";
        public const string Find = "15";
    }
    public record Row(
        int z_AN8_19,
        string z_ALPH_20,
        string z_ADD1_40,
        string z_CTY1_44,
        string z_AR1_81,
        string z_PH3_46,
        string z_PHTP_47,
        string z_ALKY_48,
        string z_SIC_49,
        string z_AT1_50,
        string z_TAX_51,
        int z_SYNCS_91,
        string z_DL01_93,
        int z_CAAD_92,
        string z_DL01_94);
    public record Data : AIS.FormData<Row>
    {
        public required AIS.FormField<string> z_AT1_54 { get; init; }
        public required AIS.FormField<string> z_ALPH_58 { get; init; }
        public required AIS.FormField<string>? z_EV01_62 { get; init; }
        public required AIS.FormField<string>? z_EV01_63 {  get; init; }
    }
    public class Request : AIS.FormRequest
    {
        public Request(AIS.Query q) : this()
        {
            query = q;
        }
        public Request()
        {
            formName = Helpers.FormName(nameof(W01012B));
        }
    }
}
namespace Celin.W01012A
{
    public record Data : AIS.FormData<object>
    {
        public required AIS.FormField<int> z_AN8_21 { get; init;}
        public required AIS.FormField<string> z_ALPH_28 { get; init;}
        public required AIS.FormField<string> z_ALKY_32 { get; init;}
        public required AIS.FormField<string> z_TAX_34 { get; init;}
        public required AIS.FormField<string> z_AT1_36 { get; init;}
        public required AIS.FormField<string> z_MCU_62 { get; init;}
        public required AIS.FormField<string> z_MLNM_38 { get; init;}
        public required AIS.FormField<string> z_ADD1_40 { get; init;}
        public required AIS.FormField<string> z_ADD2_42 { get; init;}
        public required AIS.FormField<string> z_ADD3_44 { get; init;}
        public required AIS.FormField<string> z_ADD4_46 { get; init;}
        public required AIS.FormField<string> z_CTY1_52 { get; init;}
        public required AIS.FormField<string> z_ADDS_54 { get; init;}
        public required AIS.FormField<string> z_ADDZ_50 { get; init;}
        public required AIS.FormField<string> z_CTR_56 { get; init;}
    }
}
namespace Celin
{
    public record Form : AIS.FormResponse
    {
        public AIS.Form<W01012B.Data>? fs_P01012_W01012B { get; init; }
        public AIS.Form<W01012B.Data> W01012B
            => fs_P01012_W01012B ?? throw new ArgumentNullException(nameof(W01012B));
        public AIS.Form<W01012A.Data>? fs_P01012_W01012A { get; init; }
        public AIS.Form<W01012A.Data> W01012A
            => fs_P01012_W01012A ?? throw new ArgumentNullException(nameof(W01012A));
    }
}
