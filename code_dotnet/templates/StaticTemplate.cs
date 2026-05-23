public class StaticHelpers {
    public static String GetProviderTypeDescription(String providerType) {
        switch (providerType) {
            case "TypeA":
                return "Description for Type A";
            case "TypeB":
                return "Description for Type B";
            default:
                return "Unknown provider type";
        }
    }
}