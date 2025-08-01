namespace C.ImGuiGLFW.Color;

/// <summary>
/// Provides a comprehensive collection of predefined UI colors as Vector4 values for user interface design.
/// All colors are defined with normalized RGBA values (0.0-1.0) and include a wide range of 
/// grays, earth tones, vibrant colors, and themed color palettes suitable for modern UI applications.
/// </summary>
public static class UIColor
{
    /// <summary>
    /// Gets a very dark gray color similar to a mine shaft (RGB: 46, 46, 46).
    /// </summary>
    public static readonly Vector4 MineShaft = new(0.18039216f, 0.18039216f, 0.18039216f, 1f);

    /// <summary>
    /// Gets a dark gray color suitable for dark themes (RGB: 50, 50, 50).
    /// </summary>
    public static readonly Vector4 DarkGray = new(0.19607843f, 0.19607843f, 0.19607843f, 1f);

    /// <summary>
    /// Gets a dark gray color slightly lighter than MineShaft (RGB: 51, 51, 51).
    /// </summary>
    public static readonly Vector4 MineShaft2 = new(0.2f, 0.2f, 0.2f, 1f);

    /// <summary>
    /// Gets a medium-dark granite gray color (RGB: 87, 87, 87).
    /// </summary>
    public static readonly Vector4 GraniteGray = new(0.34117648f, 0.34117648f, 0.34117648f, 1f);

    /// <summary>
    /// Gets a lighter granite gray color (RGB: 100, 100, 100).
    /// </summary>
    public static readonly Vector4 GraniteGray2 = new(0.39215687f, 0.39215687f, 0.39215687f, 1f);

    /// <summary>
    /// Gets a soft dove gray color (RGB: 110, 110, 110).
    /// </summary>
    public static readonly Vector4 DoveGray = new(0.43137255f, 0.43137255f, 0.43137255f, 1f);

    /// <summary>
    /// Gets a standard medium gray color (RGB: 128, 128, 128).
    /// </summary>
    public static readonly Vector4 Gray = new(0.5019608f, 0.5019608f, 0.5019608f, 1f);

    /// <summary>
    /// Gets a slightly lighter gray color (RGB: 135, 135, 135).
    /// </summary>
    public static readonly Vector4 Gray2 = new(0.5294118f, 0.5294118f, 0.5294118f, 1f);

    /// <summary>
    /// Gets a metallic silver-gray color (RGB: 160, 160, 160).
    /// </summary>
    public static readonly Vector4 QuickSilver = new(0.627451f, 0.627451f, 0.627451f, 1f);

    /// <summary>
    /// Gets a lighter metallic silver-gray color (RGB: 168, 168, 168).
    /// </summary>
    public static readonly Vector4 QuickSilver2 = new(0.65882355f, 0.65882355f, 0.65882355f, 1f);

    /// <summary>
    /// Gets a bright silver color (RGB: 204, 204, 204).
    /// </summary>
    public static readonly Vector4 Silver = new(0.8f, 0.8f, 0.8f, 1f);

    /// <summary>
    /// Gets a light gray color named after Alto (RGB: 209, 209, 209).
    /// </summary>
    public static readonly Vector4 Alto = new(0.81960785f, 0.81960785f, 0.81960785f, 1f);

    /// <summary>
    /// Gets a very light concrete gray color (RGB: 243, 243, 243).
    /// </summary>
    public static readonly Vector4 Concrete = new(0.9529412f, 0.9529412f, 0.9529412f, 1f);

    /// <summary>
    /// Gets a pure white color (RGB: 255, 255, 255).
    /// </summary>
    public static readonly Vector4 White = new(1f, 1f, 1f, 1f);

    /// <summary>
    /// Gets a very light pink color (RGB: 255, 232, 232).
    /// </summary>
    public static readonly Vector4 FairPink = new(1f, 0.9098039f, 0.9098039f, 1f);

    /// <summary>
    /// Gets a light pinkish cosmos color (RGB: 255, 208, 208).
    /// </summary>
    public static readonly Vector4 Cosmos = new(1f, 0.8156863f, 0.8156863f, 1f);

    /// <summary>
    /// Gets a soft pink color (RGB: 255, 200, 200).
    /// </summary>
    public static readonly Vector4 YourPink = new(1f, 0.78431374f, 0.78431374f, 1f);

    /// <summary>
    /// Gets a medium pink color like the Mona Lisa's complexion (RGB: 255, 153, 153).
    /// </summary>
    public static readonly Vector4 MonaLisa = new(1f, 0.6f, 0.6f, 1f);

    /// <summary>
    /// Gets a vibrant tulip pink color (RGB: 255, 128, 128).
    /// </summary>
    public static readonly Vector4 Tulip = new(1f, 0.5019608f, 0.5019608f, 1f);

    /// <summary>
    /// Gets a dark reddish-brown sanguine color (RGB: 145, 58, 58).
    /// </summary>
    public static readonly Vector4 SanguineBrown = new(0.5686275f, 0.22745098f, 0.22745098f, 1f);

    /// <summary>
    /// Gets a reddish apple blossom color (RGB: 168, 61, 61).
    /// </summary>
    public static readonly Vector4 AppleBlossom = new(0.65882355f, 0.23921569f, 0.23921569f, 1f);

    /// <summary>
    /// Gets a shimmering bittersweet color (RGB: 195, 70, 70).
    /// </summary>
    public static readonly Vector4 BittersweetShimmer = new(0.7647059f, 0.27450982f, 0.27450982f, 1f);

    /// <summary>
    /// Gets a dark red color named after El Salvador (RGB: 134, 48, 48).
    /// </summary>
    public static readonly Vector4 ElSalva = new(0.5254902f, 0.1882353f, 0.1882353f, 1f);

    /// <summary>
    /// Gets a bright rose color (RGB: 255, 81, 81).
    /// </summary>
    public static readonly Vector4 Rose = new(1f, 0.31764707f, 0.31764707f, 1f);

    /// <summary>
    /// Gets a flushed mahogany color (RGB: 204, 55, 55).
    /// </summary>
    public static readonly Vector4 FlushMahogany = new(0.8f, 0.21568628f, 0.21568628f, 1f);

    /// <summary>
    /// Gets a well-read burgundy color (RGB: 178, 46, 46).
    /// </summary>
    public static readonly Vector4 WellRead = new(0.69803923f, 0.18039216f, 0.18039216f, 1f);

    /// <summary>
    /// Gets a deep red totem pole color (RGB: 143, 7, 7).
    /// </summary>
    public static readonly Vector4 TotemPole = new(0.56078434f, 0.02745098f, 0.02745098f, 1f);

    /// <summary>
    /// Gets a dark maroon color (RGB: 128, 0, 0).
    /// </summary>
    public static readonly Vector4 Maroon = new(0.5019608f, 0f, 0f, 1f);

    /// <summary>
    /// Gets a red berry color (RGB: 148, 0, 0).
    /// </summary>
    public static readonly Vector4 RedBerry = new(0.5803922f, 0f, 0f, 1f);

    /// <summary>
    /// Gets a bright red color (RGB: 174, 0, 0).
    /// </summary>
    public static readonly Vector4 BrightRed = new(0.68235296f, 0f, 0f, 1f);

    /// <summary>
    /// Gets a bright red color (RGB: 174, 0, 0).
    /// </summary>
    public static readonly Vector4 BrightRed2 = new(0.7058824f, 0f, 0f, 1f);

    /// <summary>
    /// Gets a vibrant Monza red color (RGB: 220, 0, 0).
    /// </summary>
    public static readonly Vector4 Monza2 = new(0.8627451f, 0f, 0f, 1f);

    /// <summary>
    /// Gets a Roman red color with slight pink tint (RGB: 220, 103, 100).
    /// </summary>
    public static readonly Vector4 Roman = new(0.8627451f, 0.40392157f, 0.39215687f, 1f);

    /// <summary>
    /// Gets a very light fair pink color (RGB: 255, 235, 234).
    /// </summary>
    public static readonly Vector4 FairPink2 = new(1f, 0.92156863f, 0.91764706f, 1f);

    /// <summary>
    /// Gets a dark burgundy color (RGB: 120, 20, 5).
    /// </summary>
    public static readonly Vector4 DarkBurgundy = new(0.47058824f, 0.078431375f, 0.019607844f, 1f);

    /// <summary>
    /// Gets a burnt sienna orange-red color (RGB: 233, 98, 76).
    /// </summary>
    public static readonly Vector4 BurntSienna = new(0.9137255f, 0.38431373f, 0.29803923f, 1f);

    /// <summary>
    /// Gets a bright scarlet red color (RGB: 255, 40, 4).
    /// </summary>
    public static readonly Vector4 Scarlet = new(1f, 0.15686275f, 0.015686275f, 1f);

    /// <summary>
    /// Gets a very dark brown pod color (RGB: 68, 11, 0).
    /// </summary>
    public static readonly Vector4 BrownPod = new(0.26666668f, 0.043137256f, 0f, 1f);

    /// <summary>
    /// Gets a light brownish zinnwaldite color (RGB: 235, 180, 169).
    /// </summary>
    public static readonly Vector4 Zinnwaldite = new(0.92156863f, 0.7058824f, 0.6627451f, 1f);

    /// <summary>
    /// Gets a dark rock-like brown color (RGB: 76, 52, 47).
    /// </summary>
    public static readonly Vector4 Rock = new(0.29803923f, 0.20392157f, 0.18431373f, 1f);

    /// <summary>
    /// Gets a salmon orange-pink color (RGB: 255, 130, 97).
    /// </summary>
    public static readonly Vector4 Salmon = new(1f, 0.50980395f, 0.38039216f, 1f);

    /// <summary>
    /// Gets a spicy brown mix color (RGB: 145, 85, 69).
    /// </summary>
    public static readonly Vector4 SpicyMix2 = new(0.5686275f, 0.33333334f, 0.27058825f, 1f);

    /// <summary>
    /// Gets an ironstone brown color (RGB: 128, 74, 59).
    /// </summary>
    public static readonly Vector4 Ironstone = new(0.5019608f, 0.2901961f, 0.23137255f, 1f);

    /// <summary>
    /// Gets an orange roughy color (RGB: 219, 71, 25).
    /// </summary>
    public static readonly Vector4 OrangeRoughy = new(0.85882354f, 0.2784314f, 0.09803922f, 1f);

    /// <summary>
    /// Gets a grenadier red-orange color (RGB: 192, 48, 0).
    /// </summary>
    public static readonly Vector4 Grenadier = new(0.7529412f, 0.1882353f, 0f, 1f);

    /// <summary>
    /// Gets a chestnut rose color (RGB: 202, 117, 87).
    /// </summary>
    public static readonly Vector4 ChestnutRose = new(0.7921569f, 0.45882353f, 0.34117648f, 1f);

    /// <summary>
    /// Gets a nutmeg brown color (RGB: 121, 65, 45).
    /// </summary>
    public static readonly Vector4 Nutmeg = new(0.4745098f, 0.25490198f, 0.1764706f, 1f);

    /// <summary>
    /// Gets a light brownish eunry color (RGB: 207, 170, 155).
    /// </summary>
    public static readonly Vector4 Eunry = new(0.8117647f, 0.6666667f, 0.60784316f, 1f);

    /// <summary>
    /// Gets a Kabul brown color (RGB: 103, 79, 69).
    /// </summary>
    public static readonly Vector4 Kabul = new(0.40392157f, 0.30980393f, 0.27058825f, 1f);

    /// <summary>
    /// Gets a Paarl brown color (RGB: 153, 77, 44).
    /// </summary>
    public static readonly Vector4 Paarl = new(0.6f, 0.3019608f, 0.17254902f, 1f);

    /// <summary>
    /// Gets a Millbrook brown color (RGB: 97, 65, 51).
    /// </summary>
    public static readonly Vector4 Millbrook = new(0.38039216f, 0.25490198f, 0.2f, 1f);

    /// <summary>
    /// Gets a mule fawn brown color (RGB: 135, 78, 50).
    /// </summary>
    public static readonly Vector4 MuleFawn = new(0.5294118f, 0.30588236f, 0.19607843f, 1f);

    /// <summary>
    /// Gets a brown rust color (RGB: 169, 96, 60).
    /// </summary>
    public static readonly Vector4 BrownRust = new(0.6627451f, 0.3764706f, 0.23529412f, 1f);

    /// <summary>
    /// Gets a spicy brown mix color (RGB: 125, 82, 59).
    /// </summary>
    public static readonly Vector4 SpicyMix = new(0.49019608f, 0.32156864f, 0.23137255f, 1f);

    /// <summary>
    /// Gets a smokey topaz brown color (RGB: 115, 46, 9).
    /// </summary>
    public static readonly Vector4 SmokeyTopaz = new(0.4509804f, 0.18039216f, 0.03529412f, 1f);

    /// <summary>
    /// Gets a beaver brown color (RGB: 150, 116, 94).
    /// </summary>
    public static readonly Vector4 Beaver = new(0.5882353f, 0.45490196f, 0.36862746f, 1f);

    /// <summary>
    /// Gets a cement gray-brown color (RGB: 134, 111, 96).
    /// </summary>
    public static readonly Vector4 Cement = new(0.5254902f, 0.43529412f, 0.3764706f, 1f);

    /// <summary>
    /// Gets a hit pink color (RGB: 255, 177, 125).
    /// </summary>
    public static readonly Vector4 HitPink = new(1f, 0.69411767f, 0.49019608f, 1f);

    /// <summary>
    /// Gets a toast brown color (RGB: 153, 119, 96).
    /// </summary>
    public static readonly Vector4 Toast = new(0.6f, 0.46666667f, 0.3764706f, 1f);

    /// <summary>
    /// Gets a Christine orange color (RGB: 232, 104, 12).
    /// </summary>
    public static readonly Vector4 Christine = new(0.9098039f, 0.40784314f, 0.047058824f, 1f);

    /// <summary>
    /// Gets an atomic tangerine color (RGB: 255, 166, 102).
    /// </summary>
    public static readonly Vector4 AtomicTangerine = new(1f, 0.6509804f, 0.4f, 1f);

    /// <summary>
    /// Gets a burnt orange color (RGB: 204, 86, 0).
    /// </summary>
    public static readonly Vector4 BurntOrange = new(0.8f, 0.3372549f, 0f, 1f);

    /// <summary>
    /// Gets a Cape Palliser brown color (RGB: 156, 107, 71).
    /// </summary>
    public static readonly Vector4 CapePalliser = new(0.6117647f, 0.41960785f, 0.2784314f, 1f);

    /// <summary>
    /// Gets a pumpkin orange color (RGB: 255, 123, 26).
    /// </summary>
    public static readonly Vector4 Pumpkin = new(1f, 0.48235294f, 0.101960786f, 1f);

    /// <summary>
    /// Gets a Santa Fe brown color (RGB: 171, 120, 82).
    /// </summary>
    public static readonly Vector4 SantaFe = new(0.67058825f, 0.47058824f, 0.32156864f, 1f);

    /// <summary>
    /// Gets a shadow brown color (RGB: 135, 101, 74).
    /// </summary>
    public static readonly Vector4 Shadow = new(0.5294118f, 0.39607844f, 0.2901961f, 1f);

    /// <summary>
    /// Gets a donkey brown color (RGB: 160, 138, 119).
    /// </summary>
    public static readonly Vector4 DonkeyBrown = new(0.627451f, 0.5411765f, 0.46666667f, 1f);

    /// <summary>
    /// Gets a Chelsea Gem orange color variant (RGB: 163, 76, 0).
    /// </summary>
    public static readonly Vector4 ChelseaGem3 = new(0.6392157f, 0.29803923f, 0f, 1f);

    /// <summary>
    /// Gets a Chelsea Gem orange color variant (RGB: 163, 76, 0).
    /// </summary>
    public static readonly Vector4 CarnabyTan = new(0.3529412f, 0.16470589f, 0f, 1f);

    /// <summary>
    /// Gets a Jaffa orange color (RGB: 240, 142, 55).
    /// </summary>
    public static readonly Vector4 Jaffa = new(0.9411765f, 0.5568628f, 0.21568628f, 1f);

    /// <summary>
    /// Gets a brandy punch color (RGB: 202, 122, 47).
    /// </summary>
    public static readonly Vector4 BrandyPunch = new(0.7921569f, 0.47843137f, 0.18431373f, 1f);

    /// <summary>
    /// Gets a gold color (RGB: 233, 194, 156).
    /// </summary>
    public static readonly Vector4 Gold = new(0.9137255f, 0.7607843f, 0.6117647f, 1f);

    /// <summary>
    /// Gets a serenade cream color (RGB: 255, 243, 231).
    /// </summary>
    public static readonly Vector4 Serenade = new(1f, 0.9529412f, 0.90588236f, 1f);

    /// <summary>
    /// Gets a mongoose brown color (RGB: 182, 161, 138).
    /// </summary>
    public static readonly Vector4 Mongoose = new(0.7137255f, 0.6313726f, 0.5411765f, 1f);

    /// <summary>
    /// Gets a sandal brown color (RGB: 163, 135, 103).
    /// </summary>
    public static readonly Vector4 Sandal = new(0.6392157f, 0.5294118f, 0.40392157f, 1f);

    /// <summary>
    /// Gets an Indochine orange color variant (RGB: 211, 114, 0).
    /// </summary>
    public static readonly Vector4 Indochine2 = new(0.827451f, 0.44705883f, 0f, 1f);

    /// <summary>
    /// Gets an Indochine orange color (RGB: 190, 103, 0).
    /// </summary>
    public static readonly Vector4 Indochine = new(0.74509805f, 0.40392157f, 0f, 1f);

    /// <summary>
    /// Gets a Chelsea Gem orange color variant (RGB: 160, 88, 0).
    /// </summary>
    public static readonly Vector4 ChelseaGem2 = new(0.627451f, 0.34509805f, 0f, 1f);

    /// <summary>
    /// Gets a Hawaiian tan color (RGB: 156, 97, 22).
    /// </summary>
    public static readonly Vector4 HawaiianTan = new(0.6117647f, 0.38039216f, 0.08627451f, 1f);

    /// <summary>
    /// Gets a peach yellow color (RGB: 250, 217, 174).
    /// </summary>
    public static readonly Vector4 PeachYellow = new(0.98039216f, 0.8509804f, 0.68235296f, 1f);

    /// <summary>
    /// Gets a barley corn color (RGB: 157, 131, 91).
    /// </summary>
    public static readonly Vector4 BarleyCorn = new(0.6156863f, 0.5137255f, 0.35686275f, 1f);

    /// <summary>
    /// Gets a cream can color (RGB: 241, 183, 91).
    /// </summary>
    public static readonly Vector4 CreamCan = new(0.94509804f, 0.7176471f, 0.35686275f, 1f);

    /// <summary>
    /// Gets a Chelsea Gem orange color variant (RGB: 168, 104, 0).
    /// </summary>
    public static readonly Vector4 ChelseaGem4 = new(0.65882355f, 0.40784314f, 0f, 1f);

    /// <summary>
    /// Gets a tulip tree color (RGB: 230, 167, 58).
    /// </summary>
    public static readonly Vector4 TulipTree = new(0.9019608f, 0.654902f, 0.22745098f, 1f);

    /// <summary>
    /// Gets a Chelsea Gem orange color (RGB: 153, 97, 0).
    /// </summary>
    public static readonly Vector4 ChelseaGem = new(0.6f, 0.38039216f, 0f, 1f);

    /// <summary>
    /// Gets a grandis yellow color (RGB: 255, 213, 140).
    /// </summary>
    public static readonly Vector4 Grandis = new(1f, 0.8352941f, 0.54901963f, 1f);

    /// <summary>
    /// Gets a yellow-orange color (RGB: 255, 192, 80).
    /// </summary>
    public static readonly Vector4 YellowOrange = new(1f, 0.7529412f, 0.3137255f, 1f);

    /// <summary>
    /// Gets a pirate gold color (RGB: 176, 116, 0).
    /// </summary>
    public static readonly Vector4 PirateGold = new(0.6901961f, 0.45490196f, 0f, 1f);

    /// <summary>
    /// Gets a saddle brown color (RGB: 90, 60, 0).
    /// </summary>
    public static readonly Vector4 SaddleBrown = new(0.3529412f, 0.23529412f, 0f, 1f);

    /// <summary>
    /// Gets a tussock yellow-brown color (RGB: 198, 154, 65).
    /// </summary>
    public static readonly Vector4 Tussock = new(0.7764706f, 0.6039216f, 0.25490198f, 1f);

    /// <summary>
    /// Gets a rusty nail color (RGB: 133, 94, 13).
    /// </summary>
    public static readonly Vector4 RustyNail = new(0.52156866f, 0.36862746f, 0.050980393f, 1f);

    /// <summary>
    /// Gets a sunglow yellow color variant (RGB: 255, 194, 64).
    /// </summary>
    public static readonly Vector4 Sunglow2 = new(1f, 0.7607843f, 0.2509804f, 1f);

    /// <summary>
    /// Gets a tumbleweed color (RGB: 216, 187, 125).
    /// </summary>
    public static readonly Vector4 Tumbleweed = new(0.84705883f, 0.73333335f, 0.49019608f, 1f);

    /// <summary>
    /// Gets a yellow sea color (RGB: 255, 174, 0).
    /// </summary>
    public static readonly Vector4 YellowSea = new(1f, 0.68235296f, 0f, 1f);

    /// <summary>
    /// Gets a My Sin yellow color (RGB: 255, 182, 25).
    /// </summary>
    public static readonly Vector4 MySin = new(1f, 0.7137255f, 0.09803922f, 1f);

    /// <summary>
    /// Gets an almond cream color (RGB: 238, 225, 197).
    /// </summary>
    public static readonly Vector4 Almond = new(0.93333334f, 0.88235295f, 0.77254903f, 1f);

    /// <summary>
    /// Gets a Cherokee yellow color (RGB: 252, 220, 151).
    /// </summary>
    public static readonly Vector4 Cherokee = new(0.9882353f, 0.8627451f, 0.5921569f, 1f);

    /// <summary>
    /// Gets a brown color (RGB: 139, 95, 0).
    /// </summary>
    public static readonly Vector4 Brown = new(0.54509807f, 0.37254903f, 0f, 1f);

    /// <summary>
    /// Gets a gimblet brown color (RGB: 189, 165, 111).
    /// </summary>
    public static readonly Vector4 Gimblet = new(0.7411765f, 0.64705884f, 0.43529412f, 1f);

    /// <summary>
    /// Gets a buttered rum color (RGB: 152, 109, 10).
    /// </summary>
    public static readonly Vector4 ButteredRum = new(0.59607846f, 0.42745098f, 0.039215688f, 1f);

    /// <summary>
    /// Gets a spicy mustard color (RGB: 115, 85, 15).
    /// </summary>
    public static readonly Vector4 SpicyMustard = new(0.4509804f, 0.33333334f, 0.05882353f, 1f);

    /// <summary>
    /// Gets a tallow color (RGB: 162, 154, 135).
    /// </summary>
    public static readonly Vector4 Tallow = new(0.63529414f, 0.6039216f, 0.5294118f, 1f);

    /// <summary>
    /// Gets a cola brown color (RGB: 70, 50, 0).
    /// </summary>
    public static readonly Vector4 Cola = new(0.27450982f, 0.19607843f, 0f, 1f);

    /// <summary>
    /// Gets a corn harvest color variant (RGB: 142, 106, 12).
    /// </summary>
    public static readonly Vector4 CornHarvest2 = new(0.5568628f, 0.41568628f, 0.047058824f, 1f);

    /// <summary>
    /// Gets a cream can color variant (RGB: 243, 204, 100).
    /// </summary>
    public static readonly Vector4 CreamCan2 = new(0.9529412f, 0.8f, 0.39215687f, 1f);

    /// <summary>
    /// Gets a Mandalay color (RGB: 166, 127, 22).
    /// </summary>
    public static readonly Vector4 Mandalay = new(0.6509804f, 0.49803922f, 0.08627451f, 1f);

    /// <summary>
    /// Gets a Buddha gold color (RGB: 207, 151, 0).
    /// </summary>
    public static readonly Vector4 BuddhaGold = new(0.8117647f, 0.5921569f, 0f, 1f);

    /// <summary>
    /// Gets a sunglow yellow color (RGB: 252, 201, 52).
    /// </summary>
    public static readonly Vector4 Sunglow = new(0.9882353f, 0.7882353f, 0.20392157f, 1f);

    /// <summary>
    /// Gets a bison hide color (RGB: 195, 188, 165).
    /// </summary>
    public static readonly Vector4 BisonHide = new(0.7647059f, 0.7372549f, 0.64705884f, 1f);

    /// <summary>
    /// Gets an olive color variant (RGB: 143, 117, 0).
    /// </summary>
    public static readonly Vector4 Olive2 = new(0.56078434f, 0.45882353f, 0f, 1f);

    /// <summary>
    /// Gets a supernova yellow color (RGB: 241, 198, 0).
    /// </summary>
    public static readonly Vector4 Supernova = new(0.94509804f, 0.7764706f, 0f, 1f);

    /// <summary>
    /// Gets a candlelight yellow color (RGB: 255, 225, 25).
    /// </summary>
    public static readonly Vector4 Candlelight = new(1f, 0.88235295f, 0.09803922f, 1f);

    /// <summary>
    /// Gets a corn yellow color with transparency (RGB: 225, 197, 0, Alpha: 238).
    /// </summary>
    public static readonly Vector4 Corn = new(0.88235295f, 0.77254903f, 0f, 0.93333334f);

    /// <summary>
    /// Gets a golden fizz color (RGB: 249, 232, 70).
    /// </summary>
    public static readonly Vector4 GoldenFizz = new(0.9764706f, 0.9098039f, 0.27450982f, 1f);

    /// <summary>
    /// Gets a Portafino cream color (RGB: 255, 248, 176).
    /// </summary>
    public static readonly Vector4 Portafino = new(1f, 0.972549f, 0.6901961f, 1f);

    /// <summary>
    /// Gets a Costa del Sol olive color (RGB: 97, 92, 40).
    /// </summary>
    public static readonly Vector4 CostaDelSol = new(0.38039216f, 0.36078432f, 0.15686275f, 1f);

    /// <summary>
    /// Gets a peridot green-yellow color (RGB: 175, 165, 59).
    /// </summary>
    public static readonly Vector4 Peridot = new(0.6862745f, 0.64705884f, 0.23137255f, 1f);

    /// <summary>
    /// Gets a wattle yellow color (RGB: 215, 203, 70).
    /// </summary>
    public static readonly Vector4 Wattle = new(0.84313726f, 0.79607844f, 0.27450982f, 1f);

    /// <summary>
    /// Gets a lemon yellow color (RGB: 255, 239, 56).
    /// </summary>
    public static readonly Vector4 Lemon = new(1f, 0.9372549f, 0.21960784f, 1f);

    /// <summary>
    /// Gets a Portica yellow color (RGB: 245, 235, 103).
    /// </summary>
    public static readonly Vector4 Portica = new(0.9607843f, 0.92156863f, 0.40392157f, 1f);

    /// <summary>
    /// Gets a corn harvest color (RGB: 138, 129, 6).
    /// </summary>
    public static readonly Vector4 CornHarvest = new(0.5411765f, 0.5058824f, 0.023529412f, 1f);

    /// <summary>
    /// Gets an olive color (RGB: 141, 136, 0).
    /// </summary>
    public static readonly Vector4 Olive = new(0.5529412f, 0.53333336f, 0f, 1f);

    /// <summary>
    /// Gets a peridot color variant (RGB: 187, 183, 72).
    /// </summary>
    public static readonly Vector4 Peridot2 = new(0.73333335f, 0.7176471f, 0.28235295f, 1f);

    /// <summary>
    /// Gets a Shalimar cream color (RGB: 255, 255, 192).
    /// </summary>
    public static readonly Vector4 Shalimar = new(1f, 1f, 0.7529412f, 1f);

    /// <summary>
    /// Gets a laser lemon color (RGB: 255, 255, 102).
    /// </summary>
    public static readonly Vector4 LaserLemon = new(1f, 1f, 0.4f, 1f);

    /// <summary>
    /// Gets a Hacienda olive color (RGB: 145, 145, 17).
    /// </summary>
    public static readonly Vector4 Hacienda = new(0.5686275f, 0.5686275f, 0.06666667f, 1f);

    /// <summary>
    /// Gets a pear green color (RGB: 193, 229, 46).
    /// </summary>
    public static readonly Vector4 Pear = new(0.75686276f, 0.8980392f, 0.18039216f, 1f);

    /// <summary>
    /// Gets a limeade color variant (RGB: 120, 150, 0).
    /// </summary>
    public static readonly Vector4 Limeade4 = new(0.47058824f, 0.5882353f, 0f, 1f);

    /// <summary>
    /// Gets a Vida Loca green color (RGB: 112, 161, 27).
    /// </summary>
    public static readonly Vector4 VidaLoca = new(0.4392157f, 0.6313726f, 0.105882354f, 1f);

    /// <summary>
    /// Gets a fern frond green color (RGB: 86, 117, 33).
    /// </summary>
    public static readonly Vector4 FernFrond = new(0.3372549f, 0.45882353f, 0.12941177f, 1f);

    /// <summary>
    /// Gets a limeade color variant (RGB: 117, 187, 0).
    /// </summary>
    public static readonly Vector4 Limeade3 = new(0.45882353f, 0.73333335f, 0f, 1f);

    /// <summary>
    /// Gets an alien armpit green color (RGB: 129, 202, 8).
    /// </summary>
    public static readonly Vector4 AlienArmpit = new(0.5058824f, 0.7921569f, 0.03137255f, 1f);

    /// <summary>
    /// Gets a limeade color variant (RGB: 93, 158, 0).
    /// </summary>
    public static readonly Vector4 Limeade2 = new(0.3647059f, 0.61960787f, 0f, 1f);

    /// <summary>
    /// Gets a La Palma green color (RGB: 71, 133, 21).
    /// </summary>
    public static readonly Vector4 LaPalma = new(0.2784314f, 0.52156866f, 0.08235294f, 1f);

    /// <summary>
    /// Gets a conifer green color (RGB: 151, 220, 96).
    /// </summary>
    public static readonly Vector4 Conifer = new(0.5921569f, 0.8627451f, 0.3764706f, 1f);

    /// <summary>
    /// Gets a Sulu green color (RGB: 160, 248, 116).
    /// </summary>
    public static readonly Vector4 Sulu = new(0.627451f, 0.972549f, 0.45490196f, 1f);

    /// <summary>
    /// Gets a screamin' green color (RGB: 140, 255, 90).
    /// </summary>
    public static readonly Vector4 ScreaminGreen = new(0.54901963f, 1f, 0.3529412f, 1f);

    /// <summary>
    /// Gets a limeade color (RGB: 47, 156, 0).
    /// </summary>
    public static readonly Vector4 Limeade = new(0.18431373f, 0.6117647f, 0f, 1f);

    /// <summary>
    /// Gets a Sulu color variant (RGB: 168, 247, 134).
    /// </summary>
    public static readonly Vector4 Sulu2 = new(0.65882355f, 0.96862745f, 0.5254902f, 1f);

    /// <summary>
    /// Gets a Lima green color (RGB: 88, 214, 34).
    /// </summary>
    public static readonly Vector4 Lima = new(0.34509805f, 0.8392157f, 0.13333334f, 1f);

    /// <summary>
    /// Gets a Japanese laurel color variant (RGB: 25, 148, 0).
    /// </summary>
    public static readonly Vector4 JapaneseLaurel2 = new(0.09803922f, 0.5803922f, 0f, 1f);

    /// <summary>
    /// Gets a snowy mint color (RGB: 192, 255, 192).
    /// </summary>
    public static readonly Vector4 SnowyMint = new(0.7529412f, 1f, 0.7529412f, 1f);

    /// <summary>
    /// Gets an apple green color (RGB: 71, 173, 71).
    /// </summary>
    public static readonly Vector4 Apple = new(0.2784314f, 0.6784314f, 0.2784314f, 1f);

    /// <summary>
    /// Gets a deep fir green color (RGB: 0, 64, 0).
    /// </summary>
    public static readonly Vector4 DeepFir = new(0f, 0.2509804f, 0f, 1f);

    /// <summary>
    /// Gets a pure green color (RGB: 0, 255, 0).
    /// </summary>
    public static readonly Vector4 Green = new(0f, 1f, 0f, 1f);

    /// <summary>
    /// Gets a fruit salad green color (RGB: 82, 160, 95).
    /// </summary>
    public static readonly Vector4 FruitSalad = new(0.32156864f, 0.627451f, 0.37254903f, 1f);

    /// <summary>
    /// Gets a malachite green color (RGB: 0, 204, 34).
    /// </summary>
    public static readonly Vector4 Malachite = new(0f, 0.8f, 0.13333334f, 1f);

    /// <summary>
    /// Gets a Japanese laurel color (RGB: 2, 117, 24).
    /// </summary>
    public static readonly Vector4 JapaneseLaurel = new(0.007843138f, 0.45882353f, 0.09411765f, 1f);

    /// <summary>
    /// Gets a bottle green color (RGB: 10, 57, 24).
    /// </summary>
    public static readonly Vector4 BottleGreen = new(0.039215688f, 0.22352941f, 0.09411765f, 1f);

    /// <summary>
    /// Gets a fun green color (RGB: 1, 114, 35).
    /// </summary>
    public static readonly Vector4 FunGreen = new(0.003921569f, 0.44705883f, 0.13725491f, 1f);

    /// <summary>
    /// Gets a sea green color (RGB: 40, 130, 70).
    /// </summary>
    public static readonly Vector4 SeaGreen = new(0.15686275f, 0.50980395f, 0.27450982f, 1f);

    /// <summary>
    /// Gets a sea green color variant (RGB: 45, 133, 84).
    /// </summary>
    public static readonly Vector4 SeaGreen2 = new(0.1764706f, 0.52156866f, 0.32941177f, 1f);

    /// <summary>
    /// Gets an algae green color (RGB: 136, 220, 174).
    /// </summary>
    public static readonly Vector4 AlgaeGreen = new(0.53333336f, 0.8627451f, 0.68235296f, 1f);

    /// <summary>
    /// Gets a shamrock green color (RGB: 46, 209, 133).
    /// </summary>
    public static readonly Vector4 Shamrock = new(0.18039216f, 0.81960785f, 0.52156866f, 1f);

    /// <summary>
    /// Gets an eucalyptus green color (RGB: 55, 222, 153).
    /// </summary>
    public static readonly Vector4 Eucalyptus = new(0.21568628f, 0.87058824f, 0.6f, 1f);

    /// <summary>
    /// Gets a green haze color (RGB: 1, 154, 91).
    /// </summary>
    public static readonly Vector4 GreenHaze = new(0.003921569f, 0.6039216f, 0.35686275f, 1f);

    /// <summary>
    /// Gets an aqua deep color (RGB: 0, 80, 62).
    /// </summary>
    public static readonly Vector4 AquaDeep = new(0f, 0.3137255f, 0.24313726f, 1f);

    /// <summary>
    /// Gets a Caribbean green color (RGB: 19, 204, 163).
    /// </summary>
    public static readonly Vector4 CaribbeanGreen = new(0.07450981f, 0.8f, 0.6392157f, 1f);

    /// <summary>
    /// Gets a Persian green color (RGB: 0, 167, 131).
    /// </summary>
    public static readonly Vector4 PersianGreen = new(0f, 0.654902f, 0.5137255f, 1f);

    /// <summary>
    /// Gets a swans down color (RGB: 211, 238, 233).
    /// </summary>
    public static readonly Vector4 SwansDown = new(0.827451f, 0.93333334f, 0.9137255f, 1f);

    /// <summary>
    /// Gets a faded jade color (RGB: 70, 115, 107).
    /// </summary>
    public static readonly Vector4 FadedJade = new(0.27450982f, 0.4509804f, 0.41960785f, 1f);

    /// <summary>
    /// Gets a Sinbad teal color (RGB: 148, 206, 199).
    /// </summary>
    public static readonly Vector4 Sinbad = new(0.5803922f, 0.80784315f, 0.78039217f, 1f);

    /// <summary>
    /// Gets a jade color (RGB: 64, 145, 136).
    /// </summary>
    public static readonly Vector4 Jade = new(0.2509804f, 0.5686275f, 0.53333336f, 1f);

    /// <summary>
    /// Gets a water leaf color (RGB: 165, 231, 224).
    /// </summary>
    public static readonly Vector4 WaterLeaf = new(0.64705884f, 0.90588236f, 0.8784314f, 1f);

    /// <summary>
    /// Gets a Niagara teal color (RGB: 10, 173, 160).
    /// </summary>
    public static readonly Vector4 Niagara = new(0.039215688f, 0.6784314f, 0.627451f, 1f);

    /// <summary>
    /// Gets a Keppel teal color (RGB: 69, 178, 174).
    /// </summary>
    public static readonly Vector4 Keppel = new(0.27058825f, 0.69803923f, 0.68235296f, 1f);

    /// <summary>
    /// Gets a Lochinvar teal color (RGB: 41, 125, 122).
    /// </summary>
    public static readonly Vector4 Lochinvar = new(0.16078432f, 0.49019608f, 0.47843137f, 1f);

    /// <summary>
    /// Gets a spray cyan color (RGB: 128, 240, 240).
    /// </summary>
    public static readonly Vector4 Spray = new(0.5019608f, 0.9411765f, 0.9411765f, 1f);

    /// <summary>
    /// Gets a robin's egg blue color (RGB: 26, 214, 214).
    /// </summary>
    public static readonly Vector4 RobinsEggBlue = new(0.101960786f, 0.8392157f, 0.8392157f, 1f);

    /// <summary>
    /// Gets a swamp color (RGB: 0, 32, 32).
    /// </summary>
    public static readonly Vector4 Swamp = new(0f, 0.1254902f, 0.1254902f, 1f);

    /// <summary>
    /// Gets a pure cyan color (RGB: 0, 255, 255).
    /// </summary>
    public static readonly Vector4 Cyan = new(0f, 1f, 1f, 1f);

    /// <summary>
    /// Gets an ice cold color (RGB: 159, 238, 241).
    /// </summary>
    public static readonly Vector4 IceCold = new(0.62352943f, 0.93333334f, 0.94509804f, 1f);

    /// <summary>
    /// Gets a Casal blue-gray color (RGB: 42, 107, 110).
    /// </summary>
    public static readonly Vector4 Casal = new(0.16470589f, 0.41960785f, 0.43137255f, 1f);

    /// <summary>
    /// Gets a Ziggurat blue-gray color (RGB: 177, 216, 224).
    /// </summary>
    public static readonly Vector4 Ziggurat = new(0.69411767f, 0.84705883f, 0.8784314f, 1f);

    /// <summary>
    /// Gets a cerulean blue color (RGB: 5, 164, 198).
    /// </summary>
    public static readonly Vector4 Cerulean = new(0.019607844f, 0.6431373f, 0.7764706f, 1f);

    /// <summary>
    /// Gets a Malibu blue color (RGB: 91, 226, 255).
    /// </summary>
    public static readonly Vector4 Malibu = new(0.35686275f, 0.8862745f, 1f, 1f);

    /// <summary>
    /// Gets a cyan color variant (RGB: 48, 214, 255).
    /// </summary>
    public static readonly Vector4 Cyan2 = new(0.1882353f, 0.8392157f, 1f, 1f);

    /// <summary>
    /// Gets a Malibu color variant (RGB: 102, 210, 255).
    /// </summary>
    public static readonly Vector4 Malibu3 = new(0.4f, 0.8235294f, 1f, 1f);

    /// <summary>
    /// Gets a metallic seaweed color (RGB: 10, 105, 146).
    /// </summary>
    public static readonly Vector4 MetallicSeaweed = new(0.039215688f, 0.4117647f, 0.57254905f, 1f);

    /// <summary>
    /// Gets a Calypso blue color (RGB: 40, 102, 130).
    /// </summary>
    public static readonly Vector4 Calypso = new(0.15686275f, 0.4f, 0.50980395f, 1f);

    /// <summary>
    /// Gets a seagull blue color (RGB: 121, 199, 236).
    /// </summary>
    public static readonly Vector4 Seagull = new(0.4745098f, 0.78039217f, 0.9254902f, 1f);

    /// <summary>
    /// Gets a dodger blue color (RGB: 64, 191, 255).
    /// </summary>
    public static readonly Vector4 DodgerBlue = new(0.2509804f, 0.7490196f, 1f, 1f);

    /// <summary>
    /// Gets a curious blue color variant (RGB: 42, 148, 202).
    /// </summary>
    public static readonly Vector4 CuriousBlue2 = new(0.16470589f, 0.5803922f, 0.7921569f, 1f);

    /// <summary>
    /// Gets a blueberry color variant (RGB: 76, 190, 255).
    /// </summary>
    public static readonly Vector4 Blueberry2 = new(0.29803923f, 0.74509805f, 1f, 1f);

    /// <summary>
    /// Gets a Calypso color variant (RGB: 59, 118, 152).
    /// </summary>
    public static readonly Vector4 Calypso3 = new(0.23137255f, 0.4627451f, 0.59607846f, 1f);

    /// <summary>
    /// Gets a curious blue color (RGB: 41, 138, 194).
    /// </summary>
    public static readonly Vector4 CuriousBlue = new(0.16078432f, 0.5411765f, 0.7607843f, 1f);

    /// <summary>
    /// Gets an oracle blue color (RGB: 61, 101, 125).
    /// </summary>
    public static readonly Vector4 Oracle = new(0.23921569f, 0.39607844f, 0.49019608f, 1f);

    /// <summary>
    /// Gets a blueberry color (RGB: 71, 186, 255).
    /// </summary>
    public static readonly Vector4 Blueberry = new(0.2784314f, 0.7294118f, 1f, 1f);

    /// <summary>
    /// Gets a Bahama blue color (RGB: 0, 87, 145).
    /// </summary>
    public static readonly Vector4 BahamaBlue = new(0f, 0.34117648f, 0.5686275f, 1f);

    /// <summary>
    /// Gets an azure radiance color variant (RGB: 0, 153, 255).
    /// </summary>
    public static readonly Vector4 AzureRadiance2 = new(0f, 0.6f, 1f, 1f);

    /// <summary>
    /// Gets an azure radiance color (RGB: 0, 150, 255).
    /// </summary>
    public static readonly Vector4 AzureRadiance = new(0f, 0.5882353f, 1f, 1f);

    /// <summary>
    /// Gets a Prussian blue color variant (RGB: 0, 46, 80).
    /// </summary>
    public static readonly Vector4 PrussianBlue2 = new(0f, 0.18039216f, 0.3137255f, 1f);

    /// <summary>
    /// Gets a Malibu color variant (RGB: 96, 184, 250).
    /// </summary>
    public static readonly Vector4 Malibu2 = new(0.3764706f, 0.72156864f, 0.98039216f, 1f);

    /// <summary>
    /// Gets a moonstone blue color (RGB: 55, 140, 205).
    /// </summary>
    public static readonly Vector4 Moonstone = new(0.21568628f, 0.54901963f, 0.8039216f, 1f);

    /// <summary>
    /// Gets a Calypso color variant (RGB: 49, 97, 134).
    /// </summary>
    public static readonly Vector4 Calypso2 = new(0.19215687f, 0.38039216f, 0.5254902f, 1f);

    /// <summary>
    /// Gets a Bermuda gray color (RGB: 106, 141, 168).
    /// </summary>
    public static readonly Vector4 BermudaGray = new(0.41568628f, 0.5529412f, 0.65882355f, 1f);

    /// <summary>
    /// Gets a Wedgewood blue color (RGB: 72, 116, 151).
    /// </summary>
    public static readonly Vector4 Wedgewood = new(0.28235295f, 0.45490196f, 0.5921569f, 1f);

    /// <summary>
    /// Gets a Prussian blue color (RGB: 0, 40, 80).
    /// </summary>
    public static readonly Vector4 PrussianBlue = new(0f, 0.15686275f, 0.3137255f, 1f);

    /// <summary>
    /// Gets a fun blue color (RGB: 32, 103, 184).
    /// </summary>
    public static readonly Vector4 FunBlue = new(0.1254902f, 0.40392157f, 0.72156864f, 1f);

    /// <summary>
    /// Gets a black coral pearl color (RGB: 90, 106, 125).
    /// </summary>
    public static readonly Vector4 BlackCoralPearl = new(0.3529412f, 0.41568628f, 0.49019608f, 1f);

    /// <summary>
    /// Gets a cobalt blue color (RGB: 0, 80, 178).
    /// </summary>
    public static readonly Vector4 Cobalt = new(0f, 0.3137255f, 0.69803923f, 1f);

    /// <summary>
    /// Gets a blue color variant (RGB: 19, 125, 255).
    /// </summary>
    public static readonly Vector4 Blue2 = new(0.07450981f, 0.49019608f, 1f, 1f);

    /// <summary>
    /// Gets a Malibu color variant (RGB: 108, 174, 255).
    /// </summary>
    public static readonly Vector4 Malibu4 = new(0.42352942f, 0.68235296f, 1f, 1f);

    /// <summary>
    /// Gets a solitude blue color (RGB: 225, 237, 255).
    /// </summary>
    public static readonly Vector4 Solitude = new(0.88235295f, 0.92941177f, 1f, 1f);

    /// <summary>
    /// Gets a cornflower blue color (RGB: 82, 132, 231).
    /// </summary>
    public static readonly Vector4 CornflowerBlue = new(0.32156864f, 0.5176471f, 0.90588236f, 1f);

    /// <summary>
    /// Gets a blueberry color variant (RGB: 89, 144, 255).
    /// </summary>
    public static readonly Vector4 Blueberry3 = new(0.34901962f, 0.5647059f, 1f, 1f);

    /// <summary>
    /// Gets a periwinkle color (RGB: 190, 205, 255).
    /// </summary>
    public static readonly Vector4 Periwinkle = new(0.74509805f, 0.8039216f, 1f, 1f);

    /// <summary>
    /// Gets a Jackson's purple color (RGB: 27, 43, 158).
    /// </summary>
    public static readonly Vector4 JacksonsPurple = new(0.105882354f, 0.16862746f, 0.61960787f, 1f);

    /// <summary>
    /// Gets a Melrose purple color (RGB: 158, 168, 255).
    /// </summary>
    public static readonly Vector4 Melrose = new(0.61960787f, 0.65882355f, 1f, 1f);

    /// <summary>
    /// Gets an indigo color (RGB: 107, 117, 209).
    /// </summary>
    public static readonly Vector4 Indigo = new(0.41960785f, 0.45882353f, 0.81960785f, 1f);

    /// <summary>
    /// Gets a canary blue color (RGB: 0, 24, 255).
    /// </summary>
    public static readonly Vector4 Canary = new(0f, 0.09411765f, 1f, 1f);

    /// <summary>
    /// Gets a pure blue color (RGB: 0, 0, 255).
    /// </summary>
    public static readonly Vector4 Blue = new(0f, 0f, 1f, 1f);

    /// <summary>
    /// Gets a Stratos dark blue color (RGB: 12, 0, 56).
    /// </summary>
    public static readonly Vector4 Stratos = new(0.047058824f, 0f, 0.21960784f, 1f);

    /// <summary>
    /// Gets a purple heart color (RGB: 85, 52, 194).
    /// </summary>
    public static readonly Vector4 PurpleHeart = new(0.33333334f, 0.20392157f, 0.7607843f, 1f);

    /// <summary>
    /// Gets a Kimberly purple color (RGB: 125, 115, 158).
    /// </summary>
    public static readonly Vector4 Kimberly = new(0.49019608f, 0.4509804f, 0.61960787f, 1f);

    /// <summary>
    /// Gets a blueberry color variant (RGB: 133, 85, 255).
    /// </summary>
    public static readonly Vector4 Blueberry4 = new(0.52156866f, 0.33333334f, 1f, 1f);

    /// <summary>
    /// Gets a heliotrope color (RGB: 170, 129, 255).
    /// </summary>
    public static readonly Vector4 Heliotrope = new(0.6666667f, 0.5058824f, 1f, 1f);

    /// <summary>
    /// Gets a fuchsia blue color (RGB: 130, 95, 201).
    /// </summary>
    public static readonly Vector4 FuchsiaBlue = new(0.50980395f, 0.37254903f, 0.7882353f, 1f);

    /// <summary>
    /// Gets a Victoria purple color (RGB: 96, 71, 145).
    /// </summary>
    public static readonly Vector4 Victoria = new(0.3764706f, 0.2784314f, 0.5686275f, 1f);

    /// <summary>
    /// Gets a heliotrope color variant (RGB: 179, 140, 255).
    /// </summary>
    public static readonly Vector4 Heliotrope2 = new(0.7019608f, 0.54901963f, 1f, 1f);

    /// <summary>
    /// Gets an electric violet color (RGB: 137, 73, 255).
    /// </summary>
    public static readonly Vector4 ElectricViolet = new(0.5372549f, 0.28627452f, 1f, 1f);

    /// <summary>
    /// Gets a pigment indigo color (RGB: 64, 0, 160).
    /// </summary>
    public static readonly Vector4 PigmentIndigo = new(0.2509804f, 0f, 0.627451f, 1f);

    /// <summary>
    /// Gets a cherry pie color (RGB: 40, 0, 90).
    /// </summary>
    public static readonly Vector4 CherryPie = new(0.15686275f, 0f, 0.3529412f, 1f);

    /// <summary>
    /// Gets a heliotrope color variant (RGB: 192, 91, 254).
    /// </summary>
    public static readonly Vector4 Heliotrope3 = new(0.7529412f, 0.35686275f, 0.99607843f, 1f);

    /// <summary>
    /// Gets a heliotrope color variant (RGB: 200, 90, 255).
    /// </summary>
    public static readonly Vector4 Heliotrope4 = new(0.78431374f, 0.3529412f, 1f, 1f);

    /// <summary>
    /// Gets a lilac color (RGB: 196, 119, 234).
    /// </summary>
    public static readonly Vector4 Lilac = new(0.76862746f, 0.46666667f, 0.91764706f, 1f);

    /// <summary>
    /// Gets a bubble gum color (RGB: 255, 192, 255).
    /// </summary>
    public static readonly Vector4 BubbleGum = new(1f, 0.7529412f, 1f, 1f);

    /// <summary>
    /// Gets a pearly purple color (RGB: 193, 123, 183).
    /// </summary>
    public static readonly Vector4 PearlyPurple = new(0.75686276f, 0.48235294f, 0.7176471f, 1f);

    /// <summary>
    /// Gets a twilight lavender color (RGB: 125, 69, 117).
    /// </summary>
    public static readonly Vector4 TwilightLavender = new(0.49019608f, 0.27058825f, 0.45882353f, 1f);

    /// <summary>
    /// Gets a Pompadour purple color (RGB: 90, 0, 70).
    /// </summary>
    public static readonly Vector4 Pompadour = new(0.3529412f, 0f, 0.27450982f, 1f);

    /// <summary>
    /// Gets a purple pizzazz color (RGB: 255, 90, 208).
    /// </summary>
    public static readonly Vector4 PurplePizzazz = new(1f, 0.3529412f, 0.8156863f, 1f);

    /// <summary>
    /// Gets a frostbite pink color (RGB: 232, 67, 185).
    /// </summary>
    public static readonly Vector4 Frostbite = new(0.9098039f, 0.2627451f, 0.7254902f, 1f);

    /// <summary>
    /// Gets a blush color (RGB: 222, 95, 146).
    /// </summary>
    public static readonly Vector4 Blush = new(0.87058824f, 0.37254903f, 0.57254905f, 1f);

    /// <summary>
    /// Gets a tickle me pink color (RGB: 250, 137, 182).
    /// </summary>
    public static readonly Vector4 TickleMePink = new(0.98039216f, 0.5372549f, 0.7137255f, 1f);

    /// <summary>
    /// Gets a Monza red color (RGB: 204, 0, 71).
    /// </summary>
    public static readonly Vector4 Monza = new(0.8f, 0f, 0.2784314f, 1f);

    /// <summary>
    /// Gets a razzmatazz color (RGB: 229, 0, 79).
    /// </summary>
    public static readonly Vector4 Razzmatazz = new(0.8980392f, 0f, 0.30980393f, 1f);

    /// <summary>
    /// Gets a maroon color variant (RGB: 196, 57, 99).
    /// </summary>
    public static readonly Vector4 Maroon2 = new(0.76862746f, 0.22352941f, 0.3882353f, 1f);

    /// <summary>
    /// Gets a wild watermelon color (RGB: 255, 112, 146).
    /// </summary>
    public static readonly Vector4 WildWatermelon = new(1f, 0.4392157f, 0.57254905f, 1f);

    /// <summary>
    /// Gets a fiery rose color (RGB: 255, 86, 110).
    /// </summary>
    public static readonly Vector4 FieryRose = new(1f, 0.3372549f, 0.43137255f, 1f);

    /// <summary>
    /// Gets a Merlot color (RGB: 145, 25, 37).
    /// </summary>
    public static readonly Vector4 Merlot = new(0.5686275f, 0.09803922f, 0.14509805f, 1f);

    /// <summary>
    /// Gets a cosmos color variant (RGB: 255, 212, 216).
    /// </summary>
    public static readonly Vector4 Cosmos2 = new(1f, 0.83137256f, 0.84705883f, 1f);
}
