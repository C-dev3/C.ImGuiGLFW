using System;

namespace C.ImGuiGLFW.Text.FontAwesome;

/// <summary>
/// Font Awesome unicode characters for use with the FontAwesomeFreeSolid font.
/// </summary>
public enum FontAwesomeIcon
{
    /// <summary>
    /// No icon.
    /// </summary>
    None = 0,

    /// <summary>
    /// The Font Awesome "rectangle-ad" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rectangle ad", "advertisement", "media", "newspaper", "promotion", "publicity"])]
    [FontAwesomeCategories(["Marketing"])]
    Ad = 0xF641,

    /// <summary>
    /// The Font Awesome "address-book" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["address book", "contact", "directory", "employee", "index", "little black book", "portfolio", "rolodex", "uer", "username"])]
    [FontAwesomeCategories(["Business", "Communication", "Users + People"])]
    AddressBook = 0xF2B9,

    /// <summary>
    /// The Font Awesome "address-card" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["address card", "about", "contact", "employee", "id", "identification", "portfolio", "postcard", "profile", "registration", "uer", "username"])]
    [FontAwesomeCategories(["Accessibility", "Alphabet", "Business", "Communication", "Users + People"])]
    AddressCard = 0xF2BB,

    /// <summary>
    /// The Font Awesome "circle-half-stroke" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle half stroke", "circle with left half black", "adjust", "chart", "contrast", "dark", "fill", "light", "pie", "progress", "saturation"])]
    [FontAwesomeCategories(["Charts + Diagrams", "Design", "Editing", "Photos + Images", "Shapes"])]
    Adjust = 0xF042,

    /// <summary>
    /// The Font Awesome "spray-can-sparkles" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["spray can sparkles", "car", "clean", "deodorize", "fresh", "pine", "scent"])]
    [FontAwesomeCategories(["Automotive"])]
    AirFreshener = 0xF5D0,

    /// <summary>
    /// The Font Awesome "alarm-clock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["alarm clock", "alarm", "alarm clock", "clock", "date", "late", "pending", "reminder", "sleep", "snooze", "timer", "timestamp", "watch"])]
    [FontAwesomeCategories(["Alert", "Time", "Travel + Hotel"])]
    AlarmClock = 0xF34E,

    /// <summary>
    /// The Font Awesome "align-center" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["align center", "format", "middle", "paragraph", "text"])]
    [FontAwesomeCategories(["Text Formatting"])]
    AlignCenter = 0xF037,

    /// <summary>
    /// The Font Awesome "align-justify" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["align justify", "format", "paragraph", "text"])]
    [FontAwesomeCategories(["Text Formatting"])]
    AlignJustify = 0xF039,

    /// <summary>
    /// The Font Awesome "align-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["align left", "format", "paragraph", "text"])]
    [FontAwesomeCategories(["Text Formatting"])]
    AlignLeft = 0xF036,

    /// <summary>
    /// The Font Awesome "align-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["align right", "format", "paragraph", "text"])]
    [FontAwesomeCategories(["Text Formatting"])]
    AlignRight = 0xF038,

    /// <summary>
    /// The Font Awesome "hand-dots" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand dots", "allergy", "freckles", "hand", "hives", "palm", "pox", "skin", "spots"])]
    [FontAwesomeCategories(["Hands", "Medical + Health"])]
    Allergies = 0xF461,

    /// <summary>
    /// The Font Awesome "truck-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck medical", "ambulance", "clinic", "covid-19", "emergency", "emt", "er", "help", "hospital", "mobile", "support", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Maps", "Medical + Health", "Transportation"])]
    Ambulance = 0xF0F9,

    /// <summary>
    /// The Font Awesome "hands-asl-interpreting" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hands asl interpreting", "asl", "deaf", "finger", "hand", "interpret", "speak"])]
    [FontAwesomeCategories(["Accessibility", "Communication"])]
    AmericanSignLanguageInterpreting = 0xF2A3,

    /// <summary>
    /// The Font Awesome "anchor" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["anchor", "berth", "boat", "dock", "embed", "link", "maritime", "moor", "port", "secure", "ship", "tool"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maps", "Maritime"])]
    Anchor = 0xF13D,

    /// <summary>
    /// The Font Awesome "anchor-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["anchor circle check", "enable", "marina", "not affected", "ok", "okay", "port", "validate", "working"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maritime"])]
    AnchorCircleCheck = 0xE4AA,

    /// <summary>
    /// The Font Awesome "anchor-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["anchor circle exclamation", "affected", "failed", "marina", "port"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maritime"])]
    AnchorCircleExclamation = 0xE4AB,

    /// <summary>
    /// The Font Awesome "anchor-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["anchor circle xmark", "destroy", "marina", "port", "uncheck"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maritime"])]
    AnchorCircleXmark = 0xE4AC,

    /// <summary>
    /// The Font Awesome "anchor-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["anchor lock", "closed", "lockdown", "marina", "padlock", "port", "privacy", "quarantine"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maritime"])]
    AnchorLock = 0xE4AD,

    /// <summary>
    /// The Font Awesome "angles-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["angles down", "arrows", "caret", "download", "expand"])]
    [FontAwesomeCategories(["Arrows"])]
    AngleDoubleDown = 0xF103,

    /// <summary>
    /// The Font Awesome "angles-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["angles left", "left-pointing double angle quotation mark", "arrows", "back", "caret", "laquo", "previous", "quote"])]
    [FontAwesomeCategories(["Arrows"])]
    AngleDoubleLeft = 0xF100,

    /// <summary>
    /// The Font Awesome "angles-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["angles right", "right-pointing double angle quotation mark", "arrows", "caret", "forward", "more", "next", "quote", "raquo"])]
    [FontAwesomeCategories(["Arrows"])]
    AngleDoubleRight = 0xF101,

    /// <summary>
    /// The Font Awesome "angles-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["angles up", "arrows", "caret", "collapse", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    AngleDoubleUp = 0xF102,

    /// <summary>
    /// The Font Awesome "angle-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["angle down", "down arrowhead", "arrow", "caret", "download", "expand", "insert"])]
    [FontAwesomeCategories(["Arrows"])]
    AngleDown = 0xF107,

    /// <summary>
    /// The Font Awesome "angle-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["angle left", "single left-pointing angle quotation mark", "arrow", "back", "caret", "less", "previous"])]
    [FontAwesomeCategories(["Arrows"])]
    AngleLeft = 0xF104,

    /// <summary>
    /// The Font Awesome "angle-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["angle right", "single right-pointing angle quotation mark", "arrow", "care", "forward", "more", "next"])]
    [FontAwesomeCategories(["Arrows"])]
    AngleRight = 0xF105,

    /// <summary>
    /// The Font Awesome "angle-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["angle up", "up arrowhead", "arrow", "caret", "collapse", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    AngleUp = 0xF106,

    /// <summary>
    /// The Font Awesome "face-angry" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face angry", "angry", "angry face", "disapprove", "emoticon", "face", "mad", "upset"])]
    [FontAwesomeCategories(["Emoji"])]
    Angry = 0xF556,

    /// <summary>
    /// The Font Awesome "ankh" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ankh", "ankh", "amulet", "copper", "coptic christianity", "copts", "crux ansata", "egypt", "venus"])]
    [FontAwesomeCategories(["Religion"])]
    Ankh = 0xF644,

    /// <summary>
    /// The Font Awesome "apple-whole" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["apple whole", "apple", "fall", "fruit", "fuji", "green", "green apple", "macintosh", "orchard", "red", "red apple", "seasonal", "vegan"])]
    [FontAwesomeCategories(["Childhood", "Education", "Food + Beverage", "Fruits + Vegetables"])]
    AppleAlt = 0xF5D1,

    /// <summary>
    /// The Font Awesome "box-archive" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["box archive", "box", "package", "save", "storage"])]
    [FontAwesomeCategories(["Business", "Coding", "Files", "Moving", "Writing"])]
    Archive = 0xF187,

    /// <summary>
    /// The Font Awesome "archway" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["archway", "arc", "monument", "road", "street", "tunnel"])]
    [FontAwesomeCategories(["Buildings", "Travel + Hotel"])]
    Archway = 0xF557,

    /// <summary>
    /// The Font Awesome "circle-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle down", "arrow-circle-o-down", "download"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowAltCircleDown = 0xF358,

    /// <summary>
    /// The Font Awesome "circle-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle left", "arrow-circle-o-left", "back", "previous"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowAltCircleLeft = 0xF359,

    /// <summary>
    /// The Font Awesome "circle-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle right", "arrow-circle-o-right", "forward", "next"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowAltCircleRight = 0xF35A,

    /// <summary>
    /// The Font Awesome "circle-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle up", "arrow-circle-o-up", "upgrade"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowAltCircleUp = 0xF35B,

    /// <summary>
    /// The Font Awesome "circle-arrow-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle arrow down", "download"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowCircleDown = 0xF0AB,

    /// <summary>
    /// The Font Awesome "circle-arrow-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle arrow left", "back", "previous"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowCircleLeft = 0xF0A8,

    /// <summary>
    /// The Font Awesome "circle-arrow-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle arrow right", "forward", "next"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowCircleRight = 0xF0A9,

    /// <summary>
    /// The Font Awesome "circle-arrow-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle arrow up", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowCircleUp = 0xF0AA,

    /// <summary>
    /// The Font Awesome "arrow-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down", "downwards arrow", "download"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowDown = 0xF063,

    /// <summary>
    /// The Font Awesome "arrow-down-long" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down long", "download", "long-arrow-down"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowDownLong = 0xF175,

    /// <summary>
    /// The Font Awesome "arrow-down-up-across-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down up across line", "border", "crossing", "transfer"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowDownUpAcrossLine = 0xE4AF,

    /// <summary>
    /// The Font Awesome "arrow-down-up-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down up lock", "border", "closed", "crossing", "lockdown", "padlock", "privacy", "quarantine", "transfer"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowDownUpLock = 0xE4B0,

    /// <summary>
    /// The Font Awesome "arrow-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow left", "leftwards arrow", "back", "previous"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowLeft = 0xF060,

    /// <summary>
    /// The Font Awesome "arrow-left-long" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow left long", "back", "long-arrow-left", "previous"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowLeftLong = 0xF177,

    /// <summary>
    /// The Font Awesome "arrow-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow right", "rightwards arrow", "forward", "next"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowRight = 0xF061,

    /// <summary>
    /// The Font Awesome "arrow-right-arrow-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow right arrow left", "arrow", "arrows", "reciprocate", "return", "swap", "transfer"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowRightArrowLeft = 0xF0EC,

    /// <summary>
    /// The Font Awesome "arrow-right-from-bracket" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow right from bracket", "arrow", "exit", "leave", "log out", "logout"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowRightFromBracket = 0xF08B,

    /// <summary>
    /// The Font Awesome "arrow-right-long" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow right long", "forward", "long-arrow-right", "next"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowRightLong = 0xF178,

    /// <summary>
    /// The Font Awesome "arrow-right-to-bracket" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow right to bracket", "arrow", "enter", "insert", "join", "log in", "login", "sign in", "sign up", "sign-in", "signin", "signup"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowRightToBracket = 0xF090,

    /// <summary>
    /// The Font Awesome "arrow-right-to-city" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow right to city", "building", "city", "exodus", "insert", "rural", "urban"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    ArrowRightToCity = 0xE4B3,

    /// <summary>
    /// The Font Awesome "up-down-left-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["up down left right", "arrow", "arrows", "bigger", "enlarge", "expand", "fullscreen", "move", "position", "reorder", "resize"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowsAlt = 0xF0B2,

    /// <summary>
    /// The Font Awesome "left-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["left right", "arrow", "arrows-h", "expand", "horizontal", "landscape", "left-right arrow", "resize", "wide"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowsAltH = 0xF337,

    /// <summary>
    /// The Font Awesome "up-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["up down", "up down black arrow", "arrow", "arrows-v", "expand", "portrait", "resize", "tall", "up-down arrow", "vertical"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowsAltV = 0xF338,

    /// <summary>
    /// The Font Awesome "arrows-down-to-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows down to line", "insert", "scale down", "sink"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowsDownToLine = 0xE4B8,

    /// <summary>
    /// The Font Awesome "arrows-down-to-people" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows down to people", "affected", "focus", "insert", "targeted", "together", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    ArrowsDownToPeople = 0xE4B9,

    /// <summary>
    /// The Font Awesome "arrows-left-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows left right", "expand", "horizontal", "landscape", "resize", "wide"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowsLeftRight = 0xF07E,

    /// <summary>
    /// The Font Awesome "arrows-left-right-to-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows left right to line", "analysis", "expand", "gap"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowsLeftRightToLine = 0xE4BA,

    /// <summary>
    /// The Font Awesome "arrows-spin" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows spin", "cycle", "rotate", "spin", "whirl"])]
    [FontAwesomeCategories(["Arrows", "Business", "Humanitarian", "Marketing", "Spinners"])]
    ArrowsSpin = 0xE4BB,

    /// <summary>
    /// The Font Awesome "arrows-split-up-and-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows split up and left", "agile", "split"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowsSplitUpAndLeft = 0xE4BC,

    /// <summary>
    /// The Font Awesome "arrows-to-circle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows to circle", "center", "concentrate", "coordinate", "coordination", "focal point", "focus", "insert"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowsToCircle = 0xE4BD,

    /// <summary>
    /// The Font Awesome "arrows-to-dot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows to dot", "assembly point", "center", "condense", "focus", "insert", "minimize"])]
    [FontAwesomeCategories(["Arrows", "Business", "Humanitarian", "Marketing"])]
    ArrowsToDot = 0xE4BE,

    /// <summary>
    /// The Font Awesome "arrows-to-eye" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows to eye", "center", "coordinated assessment", "focus"])]
    [FontAwesomeCategories(["Arrows", "Business", "Humanitarian", "Marketing"])]
    ArrowsToEye = 0xE4BF,

    /// <summary>
    /// The Font Awesome "arrows-turn-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows turn right", "arrows"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowsTurnRight = 0xE4C0,

    /// <summary>
    /// The Font Awesome "arrows-turn-to-dots" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows turn to dots", "destination", "insert", "nexus"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowsTurnToDots = 0xE4C1,

    /// <summary>
    /// The Font Awesome "arrows-up-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows up down", "expand", "portrait", "resize", "tall", "vertical"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowsUpDown = 0xF07D,

    /// <summary>
    /// The Font Awesome "arrows-up-down-left-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows up down left right", "arrow", "arrows", "bigger", "enlarge", "expand", "fullscreen", "move", "position", "reorder", "resize"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowsUpDownLeftRight = 0xF047,

    /// <summary>
    /// The Font Awesome "arrows-up-to-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows up to line", "rise", "scale up", "upgrade"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowsUpToLine = 0xE4C2,

    /// <summary>
    /// The Font Awesome "arrow-trend-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow trend down", "line", "stocks", "trend"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowTrendDown = 0xE097,

    /// <summary>
    /// The Font Awesome "arrow-trend-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow trend up", "line", "stocks", "trend"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowTrendUp = 0xE098,

    /// <summary>
    /// The Font Awesome "arrow-turn-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow turn down", "arrow"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowTurnDown = 0xF149,

    /// <summary>
    /// The Font Awesome "arrow-turn-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow turn up", "arrow"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowTurnUp = 0xF148,

    /// <summary>
    /// The Font Awesome "arrow-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up", "upwards arrow", "forward", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowUp = 0xF062,

    /// <summary>
    /// The Font Awesome "arrow-up-from-bracket" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up from bracket", "share", "transfer", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowUpFromBracket = 0xE09A,

    /// <summary>
    /// The Font Awesome "arrow-up-from-ground-water" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up from ground water", "groundwater", "spring", "upgrade", "water supply", "water table"])]
    [FontAwesomeCategories(["Construction", "Energy", "Humanitarian"])]
    ArrowUpFromGroundWater = 0xE4B5,

    /// <summary>
    /// The Font Awesome "arrow-up-from-water-pump" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up from water pump", "flood", "groundwater", "pump", "submersible", "sump pump", "upgrade"])]
    [FontAwesomeCategories(["Household", "Humanitarian"])]
    ArrowUpFromWaterPump = 0xE4B6,

    /// <summary>
    /// The Font Awesome "arrow-up-long" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up long", "long-arrow-up", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    ArrowUpLong = 0xF176,

    /// <summary>
    /// The Font Awesome "arrow-up-right-dots" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up right dots", "growth", "increase", "population", "upgrade"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowUpRightDots = 0xE4B7,

    /// <summary>
    /// The Font Awesome "arrow-up-right-from-square" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up right from square", "new", "open", "send", "share", "upgrade"])]
    [FontAwesomeCategories(["Arrows", "Humanitarian"])]
    ArrowUpRightFromSquare = 0xF08E,

    /// <summary>
    /// The Font Awesome "ear-listen" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ear listen", "amplify", "audio", "deaf", "ear", "headset", "hearing", "sound"])]
    [FontAwesomeCategories(["Accessibility", "Communication"])]
    AssistiveListeningSystems = 0xF2A2,

    /// <summary>
    /// The Font Awesome "asterisk" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x2A.
    /// </summary>
    [FontAwesomeSearchTerms(["asterisk", "asterisk", "heavy asterisk", "annotation", "details", "reference", "required", "star"])]
    [FontAwesomeCategories(["Punctuation + Symbols", "Spinners"])]
    Asterisk = 0xF069,

    /// <summary>
    /// The Font Awesome "at" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x40.
    /// </summary>
    [FontAwesomeSearchTerms(["at", "commercial at", "address", "author", "e-mail", "email", "fluctuate", "handle"])]
    [FontAwesomeCategories(["Communication", "Punctuation + Symbols"])]
    At = 0xF1FA,

    /// <summary>
    /// The Font Awesome "book-atlas" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book atlas", "book", "directions", "geography", "globe", "knowledge", "library", "map", "research", "travel", "wayfinding"])]
    [FontAwesomeCategories(["Maps", "Travel + Hotel"])]
    Atlas = 0xF558,

    /// <summary>
    /// The Font Awesome "atom" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["atheism", "atheist", "atom", "atom symbol", "chemistry", "electron", "ion", "isotope", "knowledge", "neutron", "nuclear", "proton", "science"])]
    [FontAwesomeCategories(["Education", "Energy", "Religion", "Science", "Science Fiction", "Spinners"])]
    Atom = 0xF5D2,

    /// <summary>
    /// The Font Awesome "audio-description" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["audio description", "blind", "narration", "video", "visual"])]
    [FontAwesomeCategories(["Accessibility", "Film + Video"])]
    AudioDescription = 0xF29E,

    /// <summary>
    /// The Font Awesome "austral-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["austral sign", "austral sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    AustralSign = 0xE0A9,

    /// <summary>
    /// The Font Awesome "award" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["award", "guarantee", "honor", "praise", "prize", "recognition", "ribbon", "trophy", "warranty"])]
    [FontAwesomeCategories(["Education", "Political"])]
    Award = 0xF559,

    /// <summary>
    /// The Font Awesome "baby" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["baby", "uer", "users-people"])]
    [FontAwesomeCategories(["Childhood", "Humanitarian", "Users + People"])]
    Baby = 0xF77C,

    /// <summary>
    /// The Font Awesome "baby-carriage" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["baby carriage", "buggy", "carrier", "infant", "push", "stroller", "transportation", "walk", "wheels"])]
    [FontAwesomeCategories(["Childhood", "Transportation", "Travel + Hotel"])]
    BabyCarriage = 0xF77D,

    /// <summary>
    /// The Font Awesome "delete-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["delete left", "erase to the left", "command", "delete", "erase", "keyboard", "undo"])]
    [FontAwesomeCategories(["Editing"])]
    Backspace = 0xF55A,

    /// <summary>
    /// The Font Awesome "backward" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["backward", "arrow", "double", "fast reverse button", "previous", "rewind"])]
    [FontAwesomeCategories(["Media Playback"])]
    Backward = 0xF04A,

    /// <summary>
    /// The Font Awesome "bacon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bacon", "blt", "breakfast", "food", "ham", "lard", "meat", "pancetta", "pork", "rasher"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    Bacon = 0xF7E5,

    /// <summary>
    /// The Font Awesome "bacteria" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bacteria", "antibiotic", "antibody", "covid-19", "health", "organism", "sick"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Bacteria = 0xE059,

    /// <summary>
    /// The Font Awesome "bacterium" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bacterium", "antibiotic", "antibody", "covid-19", "germ", "health", "organism", "sick"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    Bacterium = 0xE05A,

    /// <summary>
    /// The Font Awesome "bahai" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bahai", "bahá'í", "star"])]
    [FontAwesomeCategories(["Religion", "Spinners"])]
    Bahai = 0xF666,

    /// <summary>
    /// The Font Awesome "baht-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["baht sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    BahtSign = 0xE0AC,

    /// <summary>
    /// The Font Awesome "scale-balanced" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["scale balanced", "libra", "balance", "balance scale", "balanced", "justice", "law", "legal", "measure", "rule", "scale", "weight", "zodiac"])]
    [FontAwesomeCategories(["Business", "Humanitarian", "Maps", "Money", "Political"])]
    BalanceScale = 0xF24E,

    /// <summary>
    /// The Font Awesome "scale-unbalanced" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["scale unbalanced", "justice", "legal", "measure", "unbalanced", "weight"])]
    [FontAwesomeCategories(["Business", "Maps", "Money", "Political"])]
    BalanceScaleLeft = 0xF515,

    /// <summary>
    /// The Font Awesome "scale-unbalanced-flip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["scale unbalanced flip", "justice", "legal", "measure", "unbalanced", "weight"])]
    [FontAwesomeCategories(["Business", "Maps", "Money", "Political"])]
    BalanceScaleRight = 0xF516,

    /// <summary>
    /// The Font Awesome "ban" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["404", "abort", "ban", "block", "cancel", "circle", "delete", "deny", "disabled", "entry", "failed", "forbidden", "hide", "no", "not", "not found", "prohibit", "prohibited", "remove", "slash", "stop", "trash"])]
    [FontAwesomeCategories(["Humanitarian", "Security"])]
    Ban = 0xF05E,

    /// <summary>
    /// The Font Awesome "bandage" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["adhesive bandage", "bandage", "boo boo", "first aid", "modify", "ouch"])]
    [FontAwesomeCategories(["Editing", "Medical + Health"])]
    BandAid = 0xF462,

    /// <summary>
    /// The Font Awesome "bangladeshi-taka-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bangladeshi taka sign", "bdt", "currency", "tk"])]
    [FontAwesomeCategories(["Money"])]
    BangladeshiTakaSign = 0xE2E6,

    /// <summary>
    /// The Font Awesome "barcode" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["barcode", "info", "laser", "price", "scan", "upc"])]
    [FontAwesomeCategories(["Coding", "Shopping"])]
    Barcode = 0xF02A,

    /// <summary>
    /// The Font Awesome "bars" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bars", "checklist", "drag", "hamburger", "list", "menu", "nav", "navigation", "ol", "reorder", "settings", "todo", "ul"])]
    [FontAwesomeCategories(["Coding", "Editing"])]
    Bars = 0xF0C9,

    /// <summary>
    /// The Font Awesome "bars-progress" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bars progress", "checklist", "downloading", "downloads", "loading", "poll", "progress", "project management", "settings", "to do"])]
    [FontAwesomeCategories(["Business", "Charts + Diagrams"])]
    BarsProgress = 0xF828,

    /// <summary>
    /// The Font Awesome "baseball" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ball", "baseball", "foul", "glove", "hardball", "league", "leather", "mlb", "softball", "sport", "underarm"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    BaseballBall = 0xF433,

    /// <summary>
    /// The Font Awesome "baseball-bat-ball" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["baseball bat ball", "bat", "league", "mlb", "slugger", "softball", "sport"])]
    [FontAwesomeCategories(["Childhood", "Sports + Fitness"])]
    BaseballBatBall = 0xF432,

    /// <summary>
    /// The Font Awesome "basketball" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ball", "basketball", "dribble", "dunk", "hoop", "nba"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    BasketballBall = 0xF434,

    /// <summary>
    /// The Font Awesome "bath" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bath", "bathtub", "clean", "shower", "tub", "wash"])]
    [FontAwesomeCategories(["Childhood", "Coding", "Household", "Maps", "Travel + Hotel"])]
    Bath = 0xF2CD,

    /// <summary>
    /// The Font Awesome "battery-empty" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["battery empty", "charge", "dead", "power", "status"])]
    [FontAwesomeCategories(["Energy"])]
    BatteryEmpty = 0xF244,

    /// <summary>
    /// The Font Awesome "battery-full" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["battery full", "batter", "battery", "charge", "power", "status"])]
    [FontAwesomeCategories(["Energy"])]
    BatteryFull = 0xF240,

    /// <summary>
    /// The Font Awesome "battery-half" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["battery half", "charge", "power", "status"])]
    [FontAwesomeCategories(["Energy"])]
    BatteryHalf = 0xF242,

    /// <summary>
    /// The Font Awesome "battery-quarter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["battery quarter", "charge", "low", "power", "status"])]
    [FontAwesomeCategories(["Energy"])]
    BatteryQuarter = 0xF243,

    /// <summary>
    /// The Font Awesome "battery-three-quarters" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["battery three quarters", "charge", "power", "status"])]
    [FontAwesomeCategories(["Energy"])]
    BatteryThreeQuarters = 0xF241,

    /// <summary>
    /// The Font Awesome "bed" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bed", "hospital", "hotel", "lodging", "mattress", "patient", "person in bed", "rest", "sleep", "travel", "uer"])]
    [FontAwesomeCategories(["Household", "Humanitarian", "Maps", "Travel + Hotel", "Users + People"])]
    Bed = 0xF236,

    /// <summary>
    /// The Font Awesome "beer-mug-empty" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["beer mug empty", "alcohol", "ale", "bar", "beverage", "brew", "brewery", "drink", "foam", "lager", "liquor", "mug", "stein"])]
    [FontAwesomeCategories(["Food + Beverage", "Maps"])]
    Beer = 0xF0FC,

    /// <summary>
    /// The Font Awesome "bell" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["alarm", "alert", "bel", "bell", "chime", "notification", "reminder", "request"])]
    [FontAwesomeCategories(["Alert", "Education", "Household", "Maps", "Shopping", "Social", "Time"])]
    Bell = 0xF0F3,

    /// <summary>
    /// The Font Awesome "bell-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bell slash", "alert", "bell", "bell with slash", "cancel", "disabled", "forbidden", "mute", "notification", "off", "quiet", "reminder", "silent"])]
    [FontAwesomeCategories(["Alert", "Education", "Maps", "Time"])]
    BellSlash = 0xF1F6,

    /// <summary>
    /// The Font Awesome "bezier-curve" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bezier curve", "curves", "illustrator", "lines", "path", "vector"])]
    [FontAwesomeCategories(["Design"])]
    BezierCurve = 0xF55B,

    /// <summary>
    /// The Font Awesome "book-bible" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book bible", "book", "catholicism", "christianity", "god", "holy"])]
    [FontAwesomeCategories(["Religion"])]
    Bible = 0xF647,

    /// <summary>
    /// The Font Awesome "bicycle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bicycle", "bike", "gears", "pedal", "transportation", "vehicle"])]
    [FontAwesomeCategories(["Maps", "Sports + Fitness", "Transportation"])]
    Bicycle = 0xF206,

    /// <summary>
    /// The Font Awesome "person-biking" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person biking", "bicycle", "bike", "biking", "cyclist", "pedal", "person biking", "summer", "uer", "wheel"])]
    [FontAwesomeCategories(["Childhood", "Sports + Fitness", "Users + People"])]
    Biking = 0xF84A,

    /// <summary>
    /// The Font Awesome "binoculars" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["binoculars", "glasses", "inspection", "magnifier", "magnify", "scenic", "spyglass", "view"])]
    [FontAwesomeCategories(["Astronomy", "Camping", "Maps", "Nature"])]
    Binoculars = 0xF1E5,

    /// <summary>
    /// The Font Awesome "biohazard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["biohazard", "covid-19", "danger", "dangerous", "epidemic", "hazmat", "medical", "pandemic", "radioactive", "sign", "toxic", "waste", "zombie"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Medical + Health", "Science"])]
    Biohazard = 0xF780,

    /// <summary>
    /// The Font Awesome "cake-candles" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cake candles", "anniversary", "bakery", "birthday", "birthday cake", "cake", "candles", "celebration", "dessert", "frosting", "holiday", "party", "pastry", "sweet"])]
    [FontAwesomeCategories(["Business", "Childhood", "Food + Beverage", "Maps", "Social"])]
    BirthdayCake = 0xF1FD,

    /// <summary>
    /// The Font Awesome "bitcoin-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bitcoin sign", "bitcoin sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    BitcoinSign = 0xE0B4,

    /// <summary>
    /// The Font Awesome "blender" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["blender", "cocktail", "milkshake", "mixer", "puree", "smoothie"])]
    [FontAwesomeCategories(["Food + Beverage", "Household"])]
    Blender = 0xF517,

    /// <summary>
    /// The Font Awesome "blender-phone" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["blender phone", "appliance", "cocktail", "fantasy", "milkshake", "mixer", "puree", "silly", "smoothie"])]
    [FontAwesomeCategories(["Communication", "Devices + Hardware"])]
    BlenderPhone = 0xF6B6,

    /// <summary>
    /// The Font Awesome "person-walking-with-cane" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person walking with cane", "blind", "cane", "follow", "uer"])]
    [FontAwesomeCategories(["Accessibility", "Maps", "Users + People"])]
    Blind = 0xF29D,

    /// <summary>
    /// The Font Awesome "blog" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["blog", "journal", "log", "online", "personal", "post", "web 2.0", "wordpress", "writing"])]
    [FontAwesomeCategories(["Writing"])]
    Blog = 0xF781,

    /// <summary>
    /// The Font Awesome "bold" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bold", "emphasis", "format", "text"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Bold = 0xF032,

    /// <summary>
    /// The Font Awesome "bolt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bolt", "charge", "danger", "electric", "electricity", "flash", "high voltage", "lightning", "voltage", "weather", "zap"])]
    [FontAwesomeCategories(["Energy", "Photos + Images", "Weather"])]
    Bolt = 0xF0E7,

    /// <summary>
    /// The Font Awesome "bolt-lightning" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bolt lightning", "electricity", "flash", "lightning", "weather", "zap"])]
    [FontAwesomeCategories(["Photos + Images", "Weather"])]
    BoltLightning = 0xE0B7,

    /// <summary>
    /// The Font Awesome "bomb" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bomb", "comic", "error", "explode", "fuse", "grenade", "warning"])]
    [FontAwesomeCategories(["Maps"])]
    Bomb = 0xF1E2,

    /// <summary>
    /// The Font Awesome "bone" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bone", "calcium", "dog", "skeletal", "skeleton", "tibia"])]
    [FontAwesomeCategories(["Food + Beverage", "Medical + Health"])]
    Bone = 0xF5D7,

    /// <summary>
    /// The Font Awesome "bong" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bong", "aparatus", "cannabis", "marijuana", "pipe", "smoke", "smoking"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Bong = 0xF55C,

    /// <summary>
    /// The Font Awesome "book" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book", "cover", "decorated", "diary", "documentation", "journal", "knowledge", "library", "notebook", "notebook with decorative cover", "read", "research", "scholar"])]
    [FontAwesomeCategories(["Business", "Maps", "Writing"])]
    Book = 0xF02D,

    /// <summary>
    /// The Font Awesome "book-bookmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book bookmark", "knowledge", "library", "research"])]
    [FontAwesomeCategories(["Humanitarian", "Writing"])]
    BookBookmark = 0xE0BB,

    /// <summary>
    /// The Font Awesome "book-skull" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book skull", "dungeons & dragons", "crossbones", "d&d", "dark arts", "death", "dnd", "documentation", "evil", "fantasy", "halloween", "holiday", "library", "necronomicon", "read", "research", "skull", "spell"])]
    [FontAwesomeCategories(["Gaming", "Halloween"])]
    BookDead = 0xF6B7,

    /// <summary>
    /// The Font Awesome "bookmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bookmark", "favorite", "library", "mark", "marker", "read", "remember", "research", "save"])]
    [FontAwesomeCategories(["Maps", "Shapes", "Shopping", "Writing"])]
    Bookmark = 0xF02E,

    /// <summary>
    /// The Font Awesome "book-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book medical", "diary", "documentation", "health", "history", "journal", "library", "read", "record", "research"])]
    [FontAwesomeCategories(["Medical + Health"])]
    BookMedical = 0xF7E6,

    /// <summary>
    /// The Font Awesome "book-open" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book open", "book", "book", "flyer", "knowledge", "library", "notebook", "open", "open book", "pamphlet", "reading", "research"])]
    [FontAwesomeCategories(["Education"])]
    BookOpen = 0xF518,

    /// <summary>
    /// The Font Awesome "book-open-reader" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book open reader", "flyer", "library", "notebook", "open book", "pamphlet", "reading", "research"])]
    [FontAwesomeCategories(["Education"])]
    BookReader = 0xF5DA,

    /// <summary>
    /// The Font Awesome "book-tanakh" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book tanakh", "book", "jewish", "judaism", "religion"])]
    [FontAwesomeCategories(["Religion"])]
    BookTanakh = 0xF827,

    /// <summary>
    /// The Font Awesome "border-all" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["border all", "cell", "grid", "outline", "stroke", "table"])]
    [FontAwesomeCategories(["Text Formatting"])]
    BorderAll = 0xF84C,

    /// <summary>
    /// The Font Awesome "border-none" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["border none", "cell", "grid", "outline", "stroke", "table"])]
    [FontAwesomeCategories(["Text Formatting"])]
    BorderNone = 0xF850,

    /// <summary>
    /// The Font Awesome "border-top-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["border top left", "cell", "outline", "stroke", "table"])]
    [FontAwesomeCategories(["Text Formatting"])]
    BorderStyle = 0xF853,

    /// <summary>
    /// The Font Awesome "bore-hole" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bore hole", "bore", "bury", "drill", "hole"])]
    [FontAwesomeCategories(["Construction", "Humanitarian"])]
    BoreHole = 0xE4C3,

    /// <summary>
    /// The Font Awesome "bottle-droplet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bottle droplet", "alcohol", "drink", "oil", "olive oil", "wine"])]
    [FontAwesomeCategories(["Food + Beverage", "Humanitarian"])]
    BottleDroplet = 0xE4C4,

    /// <summary>
    /// The Font Awesome "bottle-water" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bottle water", "h2o", "plastic", "water"])]
    [FontAwesomeCategories(["Camping", "Food + Beverage", "Humanitarian"])]
    BottleWater = 0xE4C5,

    /// <summary>
    /// The Font Awesome "bowl-food" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bowl food", "catfood", "dogfood", "food", "rice"])]
    [FontAwesomeCategories(["Food + Beverage", "Humanitarian"])]
    BowlFood = 0xE4C6,

    /// <summary>
    /// The Font Awesome "bowling-ball" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bowling ball", "alley", "candlepin", "gutter", "lane", "strike", "tenpin"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    BowlingBall = 0xF436,

    /// <summary>
    /// The Font Awesome "bowl-rice" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bowl rice", "boiled", "cooked", "cooked rice", "rice", "steamed"])]
    [FontAwesomeCategories(["Food + Beverage", "Humanitarian"])]
    BowlRice = 0xE2EB,

    /// <summary>
    /// The Font Awesome "box" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["archive", "box", "container", "package", "parcel", "storage"])]
    [FontAwesomeCategories(["Logistics"])]
    Box = 0xF466,

    /// <summary>
    /// The Font Awesome "boxes-stacked" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["boxes stacked", "archives", "inventory", "storage", "warehouse"])]
    [FontAwesomeCategories(["Logistics"])]
    Boxes = 0xF468,

    /// <summary>
    /// The Font Awesome "boxes-packing" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["boxes packing", "archive", "box", "package", "storage", "supplies"])]
    [FontAwesomeCategories(["Business", "Humanitarian", "Logistics", "Moving"])]
    BoxesPacking = 0xE4C7,

    /// <summary>
    /// The Font Awesome "box-open" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["box open", "archive", "container", "package", "storage", "unpack"])]
    [FontAwesomeCategories(["Moving"])]
    BoxOpen = 0xF49E,

    /// <summary>
    /// The Font Awesome "box-tissue" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["box tissue", "cough", "covid-19", "kleenex", "mucus", "nose", "sneeze", "snot"])]
    [FontAwesomeCategories(["Household"])]
    BoxTissue = 0xE05B,

    /// <summary>
    /// The Font Awesome "braille" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["braille", "alphabet", "blind", "dots", "raised", "vision"])]
    [FontAwesomeCategories(["Accessibility"])]
    Braille = 0xF2A1,

    /// <summary>
    /// The Font Awesome "brain" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["brain", "cerebellum", "gray matter", "intellect", "intelligent", "knowledge", "medulla oblongata", "mind", "noodle", "scholar", "wit"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    Brain = 0xF5DC,

    /// <summary>
    /// The Font Awesome "brazilian-real-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["brazilian real sign", "brazilian real sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    BrazilianRealSign = 0xE46C,

    /// <summary>
    /// The Font Awesome "bread-slice" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bread slice", "bake", "bakery", "baking", "dough", "flour", "gluten", "grain", "sandwich", "sourdough", "toast", "wheat", "yeast"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    BreadSlice = 0xF7EC,

    /// <summary>
    /// The Font Awesome "bridge" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bridge", "road"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maps"])]
    Bridge = 0xE4C8,

    /// <summary>
    /// The Font Awesome "bridge-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bridge circle check", "bridge", "enable", "not affected", "ok", "okay", "road", "validate", "working"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    BridgeCircleCheck = 0xE4C9,

    /// <summary>
    /// The Font Awesome "bridge-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bridge circle exclamation", "affected", "bridge", "failed", "road"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    BridgeCircleExclamation = 0xE4CA,

    /// <summary>
    /// The Font Awesome "bridge-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bridge circle xmark", "bridge", "destroy", "road", "uncheck"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    BridgeCircleXmark = 0xE4CB,

    /// <summary>
    /// The Font Awesome "bridge-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bridge lock", "bridge", "closed", "lockdown", "padlock", "privacy", "quarantine", "road"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    BridgeLock = 0xE4CC,

    /// <summary>
    /// The Font Awesome "bridge-water" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bridge water", "bridge", "road"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maps"])]
    BridgeWater = 0xE4CE,

    /// <summary>
    /// The Font Awesome "briefcase" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bag", "briefcas", "briefcase", "business", "luggage", "offer", "office", "portfolio", "work"])]
    [FontAwesomeCategories(["Business", "Maps", "Travel + Hotel"])]
    Briefcase = 0xF0B1,

    /// <summary>
    /// The Font Awesome "briefcase-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["briefcase medical", "doctor", "emt", "first aid", "health"])]
    [FontAwesomeCategories(["Medical + Health"])]
    BriefcaseMedical = 0xF469,

    /// <summary>
    /// The Font Awesome "tower-broadcast" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tower broadcast", "airwaves", "antenna", "communication", "emergency", "radio", "reception", "signal", "waves"])]
    [FontAwesomeCategories(["Connectivity", "Energy", "Film + Video", "Humanitarian"])]
    BroadcastTower = 0xF519,

    /// <summary>
    /// The Font Awesome "broom" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["broom", "clean", "cleaning", "firebolt", "fly", "halloween", "nimbus 2000", "quidditch", "sweep", "sweeping", "witch"])]
    [FontAwesomeCategories(["Halloween"])]
    Broom = 0xF51A,

    /// <summary>
    /// The Font Awesome "brush" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["brush", "art", "bristles", "color", "handle", "maintenance", "modify", "paint"])]
    [FontAwesomeCategories(["Construction", "Design", "Editing"])]
    Brush = 0xF55D,

    /// <summary>
    /// The Font Awesome "bucket" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bucket", "pail", "sandcastle"])]
    [FontAwesomeCategories(["Camping", "Childhood", "Construction", "Humanitarian"])]
    Bucket = 0xE4CF,

    /// <summary>
    /// The Font Awesome "bug" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bug", "beetle", "error", "glitch", "insect", "repair", "report"])]
    [FontAwesomeCategories(["Coding", "Nature", "Security"])]
    Bug = 0xF188,

    /// <summary>
    /// The Font Awesome "bugs" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bugs", "bedbug", "infestation", "lice", "plague", "ticks"])]
    [FontAwesomeCategories(["Animals", "Disaster + Crisis", "Humanitarian", "Nature"])]
    Bugs = 0xE4D0,

    /// <summary>
    /// The Font Awesome "bug-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bug slash", "beetle", "disabled", "fix", "glitch", "insect", "optimize", "repair", "report", "warning"])]
    [FontAwesomeCategories(["Coding", "Security"])]
    BugSlash = 0xE490,

    /// <summary>
    /// The Font Awesome "building" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["apartment", "building", "business", "city", "company", "office", "office building", "urban", "work"])]
    [FontAwesomeCategories(["Buildings", "Business", "Humanitarian", "Maps"])]
    Building = 0xF1AD,

    /// <summary>
    /// The Font Awesome "building-circle-arrow-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building circle arrow right", "building", "city", "distribution center", "office"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    BuildingCircleArrowRight = 0xE4D1,

    /// <summary>
    /// The Font Awesome "building-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building circle check", "building", "city", "enable", "not affected", "office", "ok", "okay", "validate", "working"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    BuildingCircleCheck = 0xE4D2,

    /// <summary>
    /// The Font Awesome "building-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building circle exclamation", "affected", "building", "city", "failed", "office"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    BuildingCircleExclamation = 0xE4D3,

    /// <summary>
    /// The Font Awesome "building-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building circle xmark", "building", "city", "destroy", "office", "uncheck"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    BuildingCircleXmark = 0xE4D4,

    /// <summary>
    /// The Font Awesome "building-flag" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building flag", "building", "city", "diplomat", "embassy", "flag", "headquarters", "united nations"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Political"])]
    BuildingFlag = 0xE4D5,

    /// <summary>
    /// The Font Awesome "building-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building lock", "building", "city", "closed", "lock", "lockdown", "padlock", "privacy", "quarantine", "secure"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Security"])]
    BuildingLock = 0xE4D6,

    /// <summary>
    /// The Font Awesome "building-ngo" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building ngo", "building", "city", "non governmental organization", "office"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    BuildingNgo = 0xE4D7,

    /// <summary>
    /// The Font Awesome "building-shield" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building shield", "building", "city", "police", "protect", "safety"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Security"])]
    BuildingShield = 0xE4D8,

    /// <summary>
    /// The Font Awesome "building-un" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building un", "building", "city", "office", "united nations"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    BuildingUn = 0xE4D9,

    /// <summary>
    /// The Font Awesome "building-user" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building user", "apartment", "building", "city", "employee", "uer"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    BuildingUser = 0xE4DA,

    /// <summary>
    /// The Font Awesome "building-wheat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building wheat", "agriculture", "building", "city", "usda"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    BuildingWheat = 0xE4DB,

    /// <summary>
    /// The Font Awesome "bullhorn" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bullhorn", "bullhorn", "announcement", "broadcast", "loud", "louder", "loudspeaker", "megaphone", "public address", "request", "share"])]
    [FontAwesomeCategories(["Business", "Communication", "Marketing", "Political", "Shopping"])]
    Bullhorn = 0xF0A1,

    /// <summary>
    /// The Font Awesome "bullseye" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bullseye", "archery", "goal", "objective", "strategy", "target"])]
    [FontAwesomeCategories(["Business", "Marketing", "Toggle"])]
    Bullseye = 0xF140,

    /// <summary>
    /// The Font Awesome "fire-flame-simple" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fire flame simple", "caliente", "energy", "fire", "flame", "gas", "heat", "hot"])]
    [FontAwesomeCategories(["Energy", "Humanitarian", "Medical + Health", "Science", "Sports + Fitness"])]
    Burn = 0xF46A,

    /// <summary>
    /// The Font Awesome "burst" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["burst", "boom", "crash", "explosion"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Security", "Shapes"])]
    Burst = 0xE4DC,

    /// <summary>
    /// The Font Awesome "bus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bus", "oncoming", "oncoming bus", "public transportation", "transportation", "travel", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Logistics", "Transportation", "Travel + Hotel"])]
    Bus = 0xF207,

    /// <summary>
    /// The Font Awesome "bus-simple" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bus simple", "mta", "public transportation", "transportation", "travel", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Logistics", "Transportation", "Travel + Hotel"])]
    BusAlt = 0xF55E,

    /// <summary>
    /// The Font Awesome "business-time" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["business time", "alarm", "briefcase", "business socks", "clock", "flight of the conchords", "portfolio", "reminder", "wednesday"])]
    [FontAwesomeCategories(["Business"])]
    BusinessTime = 0xF64A,

    /// <summary>
    /// The Font Awesome "bus-side" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bus side", "bus", "public transportation", "transportation", "travel", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Logistics", "Transportation", "Travel + Hotel"])]
    BusSide = 0xE81D,

    /// <summary>
    /// The Font Awesome "calculator" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calculator", "pocket calculator", "abacus", "addition", "arithmetic", "counting", "math", "multiplication", "subtraction"])]
    [FontAwesomeCategories(["Business", "Mathematics"])]
    Calculator = 0xF1EC,

    /// <summary>
    /// The Font Awesome "calendar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calendar", "calendar-o", "date", "day", "event", "month", "schedule", "tear-off calendar", "time", "when", "year"])]
    [FontAwesomeCategories(["Business", "Shapes", "Time"])]
    Calendar = 0xF133,

    /// <summary>
    /// The Font Awesome "calendar-days" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calendar days", "calendar", "date", "day", "event", "month", "schedule", "time", "when", "year"])]
    [FontAwesomeCategories(["Business", "Time"])]
    CalendarAlt = 0xF073,

    /// <summary>
    /// The Font Awesome "calendar-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calendar check", "accept", "agree", "appointment", "confirm", "correct", "date", "day", "done", "enable", "event", "month", "ok", "schedule", "select", "success", "tick", "time", "todo", "validate", "warranty", "when", "working", "year"])]
    [FontAwesomeCategories(["Time"])]
    CalendarCheck = 0xF274,

    /// <summary>
    /// The Font Awesome "calendar-day" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calendar day", "date", "day", "detail", "event", "focus", "month", "schedule", "single day", "time", "today", "when", "year"])]
    [FontAwesomeCategories(["Time"])]
    CalendarDay = 0xF783,

    /// <summary>
    /// The Font Awesome "calendar-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calendar minus", "calendar", "date", "day", "delete", "event", "month", "negative", "remove", "schedule", "time", "when", "year"])]
    [FontAwesomeCategories(["Time"])]
    CalendarMinus = 0xF272,

    /// <summary>
    /// The Font Awesome "calendar-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calendar plus", "add", "calendar", "create", "date", "day", "event", "month", "new", "positive", "schedule", "time", "when", "year"])]
    [FontAwesomeCategories(["Time"])]
    CalendarPlus = 0xF271,

    /// <summary>
    /// The Font Awesome "calendar-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calendar xmark", "archive", "calendar", "date", "day", "delete", "event", "month", "remove", "schedule", "time", "uncheck", "when", "x", "year"])]
    [FontAwesomeCategories(["Time"])]
    CalendarTimes = 0xF273,

    /// <summary>
    /// The Font Awesome "calendar-week" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["calendar week", "date", "day", "detail", "event", "focus", "month", "schedule", "single week", "time", "today", "when", "year"])]
    [FontAwesomeCategories(["Time"])]
    CalendarWeek = 0xF784,

    /// <summary>
    /// The Font Awesome "camera" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["camera", "image", "img", "lens", "photo", "picture", "record", "shutter", "video"])]
    [FontAwesomeCategories(["Devices + Hardware", "Photos + Images", "Shopping", "Social"])]
    Camera = 0xF030,

    /// <summary>
    /// The Font Awesome "camera-retro" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["camera retro", "camera", "image", "img", "lens", "photo", "picture", "record", "shutter", "video"])]
    [FontAwesomeCategories(["Devices + Hardware", "Photos + Images", "Shopping"])]
    CameraRetro = 0xF083,

    /// <summary>
    /// The Font Awesome "camera-rotate" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["camera rotate", "flip", "front-facing", "img", "photo", "selfie"])]
    [FontAwesomeCategories(["Photos + Images"])]
    CameraRotate = 0xE0D8,

    /// <summary>
    /// The Font Awesome "campground" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["campground", "camping", "fall", "outdoors", "teepee", "tent", "tipi"])]
    [FontAwesomeCategories(["Buildings", "Camping"])]
    Campground = 0xF6BB,

    /// <summary>
    /// The Font Awesome "candy-cane" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["candy cane", "candy", "christmas", "holiday", "mint", "peppermint", "striped", "xmas"])]
    [FontAwesomeCategories(["Food + Beverage", "Holidays"])]
    CandyCane = 0xF786,

    /// <summary>
    /// The Font Awesome "cannabis" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cannabis", "bud", "chronic", "drugs", "endica", "endo", "ganja", "marijuana", "mary jane", "pot", "reefer", "sativa", "spliff", "weed", "whacky-tabacky"])]
    [FontAwesomeCategories(["Medical + Health", "Nature"])]
    Cannabis = 0xF55F,

    /// <summary>
    /// The Font Awesome "capsules" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["capsules", "drugs", "medicine", "pills", "prescription"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    Capsules = 0xF46B,

    /// <summary>
    /// The Font Awesome "car" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["auto", "automobile", "car", "oncoming", "oncoming automobile", "sedan", "transportation", "travel", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Logistics", "Maps", "Transportation", "Travel + Hotel"])]
    Car = 0xF1B9,

    /// <summary>
    /// The Font Awesome "car-rear" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["car rear", "auto", "automobile", "sedan", "transportation", "travel", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Transportation"])]
    CarAlt = 0xF5DE,

    /// <summary>
    /// The Font Awesome "caravan" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["caravan", "camper", "motor home", "rv", "trailer", "travel"])]
    [FontAwesomeCategories(["Automotive", "Camping", "Moving", "Travel + Hotel"])]
    Caravan = 0xF8FF,

    /// <summary>
    /// The Font Awesome "car-battery" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["car battery", "auto", "electric", "mechanic", "power"])]
    [FontAwesomeCategories(["Automotive", "Devices + Hardware", "Energy"])]
    CarBattery = 0xF5DF,

    /// <summary>
    /// The Font Awesome "car-burst" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["car burst", "accident", "auto", "automobile", "insurance", "sedan", "transportation", "vehicle", "wreck"])]
    [FontAwesomeCategories(["Automotive", "Transportation"])]
    CarCrash = 0xF5E1,

    /// <summary>
    /// The Font Awesome "caret-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["caret down", "arrow", "dropdown", "expand", "menu", "more", "triangle"])]
    [FontAwesomeCategories(["Arrows"])]
    CaretDown = 0xF0D7,

    /// <summary>
    /// The Font Awesome "caret-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["caret left", "arrow", "back", "previous", "triangle"])]
    [FontAwesomeCategories(["Arrows"])]
    CaretLeft = 0xF0D9,

    /// <summary>
    /// The Font Awesome "caret-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["caret right", "arrow", "forward", "next", "triangle"])]
    [FontAwesomeCategories(["Arrows"])]
    CaretRight = 0xF0DA,

    /// <summary>
    /// The Font Awesome "square-caret-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square caret down", "arrow", "caret-square-o-down", "dropdown", "expand", "insert", "menu", "more", "triangle"])]
    [FontAwesomeCategories(["Arrows"])]
    CaretSquareDown = 0xF150,

    /// <summary>
    /// The Font Awesome "square-caret-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square caret left", "arrow", "back", "caret-square-o-left", "previous", "triangle"])]
    [FontAwesomeCategories(["Arrows"])]
    CaretSquareLeft = 0xF191,

    /// <summary>
    /// The Font Awesome "square-caret-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square caret right", "arrow", "caret-square-o-right", "forward", "next", "triangle"])]
    [FontAwesomeCategories(["Arrows"])]
    CaretSquareRight = 0xF152,

    /// <summary>
    /// The Font Awesome "square-caret-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square caret up", "arrow", "caret-square-o-up", "collapse", "triangle", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    CaretSquareUp = 0xF151,

    /// <summary>
    /// The Font Awesome "caret-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["caret up", "arrow", "collapse", "triangle", "upgrade"])]
    [FontAwesomeCategories(["Arrows"])]
    CaretUp = 0xF0D8,

    /// <summary>
    /// The Font Awesome "car-on" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["car on", "alarm", "car", "carjack", "warning"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Security"])]
    CarOn = 0xE4DD,

    /// <summary>
    /// The Font Awesome "carrot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bugs bunny", "carrot", "food", "orange", "vegan", "vegetable"])]
    [FontAwesomeCategories(["Food + Beverage", "Fruits + Vegetables", "Holidays"])]
    Carrot = 0xF787,

    /// <summary>
    /// The Font Awesome "car-side" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["car side", "auto", "automobile", "car", "sedan", "transportation", "travel", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Transportation"])]
    CarSide = 0xF5E4,

    /// <summary>
    /// The Font Awesome "cart-arrow-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cart arrow down", "download", "insert", "save", "shopping"])]
    [FontAwesomeCategories(["Shopping"])]
    CartArrowDown = 0xF218,

    /// <summary>
    /// The Font Awesome "cart-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cart plus", "add", "create", "new", "positive", "shopping"])]
    [FontAwesomeCategories(["Shopping"])]
    CartPlus = 0xF217,

    /// <summary>
    /// The Font Awesome "car-tunnel" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["car tunnel", "road", "tunnel"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Logistics", "Transportation"])]
    CarTunnel = 0xE4DE,

    /// <summary>
    /// The Font Awesome "cash-register" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cash register", "buy", "cha-ching", "change", "checkout", "commerce", "leaerboard", "machine", "pay", "payment", "purchase", "store"])]
    [FontAwesomeCategories(["Money", "Shopping"])]
    CashRegister = 0xF788,

    /// <summary>
    /// The Font Awesome "cat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cat", "feline", "halloween", "holiday", "kitten", "kitty", "meow", "pet"])]
    [FontAwesomeCategories(["Animals", "Halloween"])]
    Cat = 0xF6BE,

    /// <summary>
    /// The Font Awesome "cedi-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cedi sign", "cedi sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    CediSign = 0xE0DF,

    /// <summary>
    /// The Font Awesome "cent-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cent sign", "cent sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    CentSign = 0xE3F5,

    /// <summary>
    /// The Font Awesome "certificate" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["certificate", "badge", "guarantee", "star", "verified"])]
    [FontAwesomeCategories(["Business", "Shapes", "Shopping", "Spinners"])]
    Certificate = 0xF0A3,

    /// <summary>
    /// The Font Awesome "chair" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chair", "furniture", "seat", "sit"])]
    [FontAwesomeCategories(["Household"])]
    Chair = 0xF6C0,

    /// <summary>
    /// The Font Awesome "chalkboard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chalkboard", "blackboard", "learning", "school", "teaching", "whiteboard", "writing"])]
    [FontAwesomeCategories(["Education", "Photos + Images"])]
    Chalkboard = 0xF51B,

    /// <summary>
    /// The Font Awesome "chalkboard-user" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chalkboard user", "blackboard", "instructor", "learning", "professor", "school", "uer", "whiteboard", "writing"])]
    [FontAwesomeCategories(["Education", "Users + People"])]
    ChalkboardTeacher = 0xF51C,

    /// <summary>
    /// The Font Awesome "charging-station" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["charging station", "car charger", "charge", "charging", "electric", "ev", "tesla", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Energy"])]
    ChargingStation = 0xF5E7,

    /// <summary>
    /// The Font Awesome "chart-area" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chart area", "analytics", "area", "chart", "graph", "performance", "revenue", "statistics"])]
    [FontAwesomeCategories(["Charts + Diagrams"])]
    ChartArea = 0xF1FE,

    /// <summary>
    /// The Font Awesome "chart-bar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chart bar", "analytics", "bar", "chart", "graph", "performance", "statistics"])]
    [FontAwesomeCategories(["Charts + Diagrams"])]
    ChartBar = 0xF080,

    /// <summary>
    /// The Font Awesome "chart-column" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chart column", "bar", "bar chart", "chart", "graph", "performance", "revenue", "statistics", "track", "trend"])]
    [FontAwesomeCategories(["Charts + Diagrams"])]
    ChartColumn = 0xE0E3,

    /// <summary>
    /// The Font Awesome "chart-diagram" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chart diagram", "algorithm", "analytics", "flow", "graph"])]
    [FontAwesomeCategories(["Charts + Diagrams", "Coding"])]
    ChartDiagram = 0xE695,

    /// <summary>
    /// The Font Awesome "chart-gantt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chart gantt", "chart", "graph", "performance", "statistics", "track", "trend"])]
    [FontAwesomeCategories(["Charts + Diagrams"])]
    ChartGantt = 0xE0E4,

    /// <summary>
    /// The Font Awesome "chart-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chart line", "activity", "analytics", "chart", "dashboard", "gain", "graph", "increase", "line", "performance", "revenue", "statistics"])]
    [FontAwesomeCategories(["Business", "Charts + Diagrams", "Money"])]
    ChartLine = 0xF201,

    /// <summary>
    /// The Font Awesome "chart-pie" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chart pie", "analytics", "chart", "diagram", "graph", "performance", "pie", "revenue", "statistics"])]
    [FontAwesomeCategories(["Business", "Charts + Diagrams", "Money"])]
    ChartPie = 0xF200,

    /// <summary>
    /// The Font Awesome "chart-simple" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chart simple", "analytics", "bar", "chart", "column", "graph", "performance", "revenue", "row", "statistics", "trend"])]
    [FontAwesomeCategories(["Business", "Charts + Diagrams", "Editing", "Logistics", "Marketing"])]
    ChartSimple = 0xE473,

    /// <summary>
    /// The Font Awesome "check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["check mark", "accept", "agree", "check", "check mark", "checkmark", "confirm", "correct", "coupon", "done", "enable", "mark", "notice", "notification", "notify", "ok", "select", "success", "tick", "todo", "true", "validate", "working", "yes", "✓"])]
    [FontAwesomeCategories(["Editing", "Punctuation + Symbols", "Text Formatting"])]
    Check = 0xF00C,

    /// <summary>
    /// The Font Awesome "circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle check", "accept", "affected", "agree", "clear", "confirm", "correct", "coupon", "done", "enable", "ok", "select", "success", "tick", "todo", "validate", "working", "yes"])]
    [FontAwesomeCategories(["Editing", "Text Formatting", "Toggle"])]
    CheckCircle = 0xF058,

    /// <summary>
    /// The Font Awesome "check-double" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["check double", "accept", "agree", "checkmark", "confirm", "correct", "coupon", "done", "enable", "notice", "notification", "notify", "ok", "select", "select all", "success", "tick", "todo", "validate", "working"])]
    [FontAwesomeCategories(["Editing", "Political", "Punctuation + Symbols", "Text Formatting"])]
    CheckDouble = 0xF560,

    /// <summary>
    /// The Font Awesome "square-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square check", "accept", "agree", "box", "button", "check", "check box with check", "check mark button", "checkmark", "confirm", "correct", "coupon", "done", "enable", "mark", "ok", "select", "success", "tick", "todo", "validate", "working", "yes", "✓"])]
    [FontAwesomeCategories(["Editing", "Text Formatting"])]
    CheckSquare = 0xF14A,

    /// <summary>
    /// The Font Awesome "cheese" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cheese", "cheddar", "curd", "gouda", "melt", "parmesan", "sandwich", "swiss", "wedge"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    Cheese = 0xF7EF,

    /// <summary>
    /// The Font Awesome "chess" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chess", "board", "castle", "checkmate", "game", "king", "rook", "strategy", "tournament"])]
    [FontAwesomeCategories(["Gaming"])]
    Chess = 0xF439,

    /// <summary>
    /// The Font Awesome "chess-bishop" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chess bishop", "black chess bishop", "board", "checkmate", "game", "strategy"])]
    [FontAwesomeCategories(["Gaming"])]
    ChessBishop = 0xF43A,

    /// <summary>
    /// The Font Awesome "chess-board" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chess board", "board", "checkmate", "game", "strategy"])]
    [FontAwesomeCategories(["Gaming"])]
    ChessBoard = 0xF43C,

    /// <summary>
    /// The Font Awesome "chess-king" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chess king", "black chess king", "board", "checkmate", "game", "strategy"])]
    [FontAwesomeCategories(["Gaming"])]
    ChessKing = 0xF43F,

    /// <summary>
    /// The Font Awesome "chess-knight" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chess knight", "black chess knight", "board", "checkmate", "game", "horse", "strategy"])]
    [FontAwesomeCategories(["Gaming"])]
    ChessKnight = 0xF441,

    /// <summary>
    /// The Font Awesome "chess-pawn" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chess pawn", "board", "checkmate", "chess", "chess pawn", "dupe", "expendable", "game", "strategy"])]
    [FontAwesomeCategories(["Gaming"])]
    ChessPawn = 0xF443,

    /// <summary>
    /// The Font Awesome "chess-queen" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chess queen", "black chess queen", "board", "checkmate", "game", "strategy"])]
    [FontAwesomeCategories(["Gaming"])]
    ChessQueen = 0xF445,

    /// <summary>
    /// The Font Awesome "chess-rook" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chess rook", "black chess rook", "board", "castle", "checkmate", "game", "strategy"])]
    [FontAwesomeCategories(["Gaming"])]
    ChessRook = 0xF447,

    /// <summary>
    /// The Font Awesome "circle-chevron-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle chevron down", "arrow", "download", "dropdown", "menu", "more"])]
    [FontAwesomeCategories(["Arrows"])]
    ChevronCircleDown = 0xF13A,

    /// <summary>
    /// The Font Awesome "circle-chevron-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle chevron left", "arrow", "back", "previous"])]
    [FontAwesomeCategories(["Arrows"])]
    ChevronCircleLeft = 0xF137,

    /// <summary>
    /// The Font Awesome "circle-chevron-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle chevron right", "arrow", "forward", "next"])]
    [FontAwesomeCategories(["Arrows"])]
    ChevronCircleRight = 0xF138,

    /// <summary>
    /// The Font Awesome "circle-chevron-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle chevron up", "arrow", "collapse", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    ChevronCircleUp = 0xF139,

    /// <summary>
    /// The Font Awesome "chevron-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chevron down", "arrow", "download", "expand", "insert"])]
    [FontAwesomeCategories(["Arrows"])]
    ChevronDown = 0xF078,

    /// <summary>
    /// The Font Awesome "chevron-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chevron left", "left-pointing angle bracket", "arrow", "back", "bracket", "previous"])]
    [FontAwesomeCategories(["Arrows"])]
    ChevronLeft = 0xF053,

    /// <summary>
    /// The Font Awesome "chevron-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chevron right", "right-pointing angle bracket", "arrow", "bracket", "forward", "next"])]
    [FontAwesomeCategories(["Arrows"])]
    ChevronRight = 0xF054,

    /// <summary>
    /// The Font Awesome "chevron-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chevron up", "arrow", "collapse", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    ChevronUp = 0xF077,

    /// <summary>
    /// The Font Awesome "child" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["child", "boy", "girl", "kid", "toddler", "uer", "young", "youth"])]
    [FontAwesomeCategories(["Childhood", "Users + People"])]
    Child = 0xF1AE,

    /// <summary>
    /// The Font Awesome "child-combatant" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["child combatant", "combatant"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian"])]
    ChildCombatant = 0xE4E0,

    /// <summary>
    /// The Font Awesome "child-dress" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["child dress", "boy", "girl", "kid", "toddler", "uer", "young", "youth"])]
    [FontAwesomeCategories(["Childhood", "Users + People"])]
    ChildDress = 0xE59C,

    /// <summary>
    /// The Font Awesome "child-reaching" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["child reaching", "boy", "girl", "kid", "toddler", "uer", "young", "youth"])]
    [FontAwesomeCategories(["Childhood", "Users + People"])]
    ChildReaching = 0xE59D,

    /// <summary>
    /// The Font Awesome "children" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["children", "boy", "child", "girl", "kid", "kids", "together", "uer", "young", "youth"])]
    [FontAwesomeCategories(["Childhood", "Humanitarian", "Users + People"])]
    Children = 0xE4E1,

    /// <summary>
    /// The Font Awesome "church" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["christian", "building", "cathedral", "chapel", "church", "community", "cross", "religion"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Religion"])]
    Church = 0xF51D,

    /// <summary>
    /// The Font Awesome "circle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["black circle", "black large circle", "black circle", "blue", "blue circle", "brown", "brown circle", "chart", "circle", "circle-thin", "diameter", "dot", "ellipse", "fill", "geometric", "green", "green circle", "notification", "orange", "orange circle", "progress", "purple", "purple circle", "red", "red circle", "round", "white circle", "yellow", "yellow circle"])]
    [FontAwesomeCategories(["Film + Video", "Shapes", "Toggle"])]
    Circle = 0xF111,

    /// <summary>
    /// The Font Awesome "circle-nodes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle nodes", "cluster", "connect", "network"])]
    [FontAwesomeCategories(["Coding", "Connectivity", "Design", "Humanitarian"])]
    CircleNodes = 0xE4E2,

    /// <summary>
    /// The Font Awesome "circle-notch" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle notch", "circle-o-notch", "diameter", "dot", "ellipse", "round", "spinner"])]
    [FontAwesomeCategories(["Spinners"])]
    CircleNotch = 0xF1CE,

    /// <summary>
    /// The Font Awesome "city" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["buildings", "busy", "city", "cityscape", "skyscrapers", "urban", "windows"])]
    [FontAwesomeCategories(["Buildings", "Business"])]
    City = 0xF64F,

    /// <summary>
    /// The Font Awesome "clapperboard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clapperboard", "camera", "clapper", "clapper board", "director", "film", "movie", "record"])]
    [FontAwesomeCategories(["Film + Video"])]
    Clapperboard = 0xE131,

    /// <summary>
    /// The Font Awesome "house-chimney-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house chimney medical", "covid-19", "doctor", "general practitioner", "hospital", "infirmary", "medicine", "office", "outpatient"])]
    [FontAwesomeCategories(["Buildings", "Medical + Health"])]
    ClinicMedical = 0xF7F2,

    /// <summary>
    /// The Font Awesome "clipboard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clipboard", "copy", "notepad", "notes", "paste", "record"])]
    [FontAwesomeCategories(["Business"])]
    Clipboard = 0xF328,

    /// <summary>
    /// The Font Awesome "clipboard-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clipboard check", "accept", "agree", "confirm", "coupon", "done", "enable", "ok", "select", "success", "tick", "todo", "validate", "working", "yes"])]
    [FontAwesomeCategories(["Business", "Logistics", "Science"])]
    ClipboardCheck = 0xF46C,

    /// <summary>
    /// The Font Awesome "clipboard-list" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clipboard list", "cheatsheet", "checklist", "completed", "done", "finished", "intinerary", "ol", "schedule", "summary", "survey", "tick", "todo", "ul", "wishlist"])]
    [FontAwesomeCategories(["Logistics"])]
    ClipboardList = 0xF46D,

    /// <summary>
    /// The Font Awesome "clipboard-question" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clipboard question", "assistance", "faq", "interview", "query", "question"])]
    [FontAwesomeCategories(["Business", "Humanitarian", "Logistics"])]
    ClipboardQuestion = 0xE4E3,

    /// <summary>
    /// The Font Awesome "clipboard-user" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clipboard user", "attendance", "employee", "record", "roster", "staff", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Medical + Health", "Users + People"])]
    ClipboardUser = 0xF7F3,

    /// <summary>
    /// The Font Awesome "clock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["00", "4", "4:00", "clock", "date", "four", "four o’clock", "hour", "late", "minute", "o'clock", "o’clock", "pending", "schedule", "ticking", "time", "timer", "timestamp", "watch"])]
    [FontAwesomeCategories(["Time"])]
    Clock = 0xF017,

    /// <summary>
    /// The Font Awesome "clone" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clone", "add", "arrange", "copy", "duplicate", "new", "paste"])]
    [FontAwesomeCategories(["Design", "Files", "Photos + Images"])]
    Clone = 0xF24D,

    /// <summary>
    /// The Font Awesome "closed-captioning" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["closed captioning", "cc", "deaf", "hearing", "subtitle", "subtitling", "text", "video"])]
    [FontAwesomeCategories(["Accessibility", "Film + Video"])]
    ClosedCaptioning = 0xF20A,

    /// <summary>
    /// The Font Awesome "cloud" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["atmosphere", "cloud", "fog", "overcast", "save", "upload", "weather"])]
    [FontAwesomeCategories(["Connectivity", "Shapes", "Weather"])]
    Cloud = 0xF0C2,

    /// <summary>
    /// The Font Awesome "cloud-bolt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud bolt", "bolt", "cloud", "cloud with lightning", "lightning", "precipitation", "rain", "storm", "weather"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Weather"])]
    CloudBolt = 0xF76C,

    /// <summary>
    /// The Font Awesome "cloud-arrow-down" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF0ED.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud arrow down", "download", "export", "save"])]
    [FontAwesomeCategories(["Arrows", "Connectivity"])]
    CloudDownloadAlt = 0xF381,

    /// <summary>
    /// The Font Awesome "cloud-meatball" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud meatball", "fldsmdfr", "food", "spaghetti", "storm"])]
    [FontAwesomeCategories(["Food + Beverage", "Weather"])]
    CloudMeatball = 0xF73B,

    /// <summary>
    /// The Font Awesome "cloud-moon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud moon", "crescent", "evening", "lunar", "night", "partly cloudy", "sky"])]
    [FontAwesomeCategories(["Halloween", "Weather"])]
    CloudMoon = 0xF6C3,

    /// <summary>
    /// The Font Awesome "cloud-moon-rain" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud moon rain", "crescent", "evening", "lunar", "night", "partly cloudy", "precipitation", "rain", "sky", "storm"])]
    [FontAwesomeCategories(["Weather"])]
    CloudMoonRain = 0xF73C,

    /// <summary>
    /// The Font Awesome "cloud-rain" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud rain", "rain", "cloud", "cloud with rain", "precipitation", "rain", "sky", "storm"])]
    [FontAwesomeCategories(["Weather"])]
    CloudRain = 0xF73D,

    /// <summary>
    /// The Font Awesome "cloud-showers-heavy" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud showers heavy", "precipitation", "rain", "sky", "storm"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Weather"])]
    CloudShowersHeavy = 0xF740,

    /// <summary>
    /// The Font Awesome "cloud-showers-water" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud showers water", "cloud", "deluge", "flood", "rain", "storm", "surge"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Weather"])]
    CloudShowersWater = 0xE4E4,

    /// <summary>
    /// The Font Awesome "cloud-sun" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud sun", "clear", "cloud", "day", "daytime", "fall", "outdoors", "overcast", "partly cloudy", "sun", "sun behind cloud"])]
    [FontAwesomeCategories(["Nature", "Weather"])]
    CloudSun = 0xF6C4,

    /// <summary>
    /// The Font Awesome "cloud-sun-rain" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud sun rain", "cloud", "day", "overcast", "precipitation", "rain", "storm", "summer", "sun", "sun behind rain cloud", "sunshower"])]
    [FontAwesomeCategories(["Weather"])]
    CloudSunRain = 0xF743,

    /// <summary>
    /// The Font Awesome "cloud-arrow-up" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF0EE.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud arrow up", "import", "save", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows", "Connectivity"])]
    CloudUploadAlt = 0xF382,

    /// <summary>
    /// The Font Awesome "clover" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["4", "charm", "clover", "four", "four leaf clover", "four-leaf clover", "leaf", "leprechaun", "luck", "lucky"])]
    [FontAwesomeCategories(["Nature", "Shapes"])]
    Clover = 0xE139,

    /// <summary>
    /// The Font Awesome "martini-glass-citrus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["martini glass citrus", "alcohol", "beverage", "drink", "gin", "glass", "margarita", "martini", "vodka"])]
    [FontAwesomeCategories(["Food + Beverage", "Travel + Hotel"])]
    Cocktail = 0xF561,

    /// <summary>
    /// The Font Awesome "code" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["brackets", "code", "development", "html", "mysql", "sql"])]
    [FontAwesomeCategories(["Coding"])]
    Code = 0xF121,

    /// <summary>
    /// The Font Awesome "code-branch" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["code branch", "branch", "git", "github", "mysql", "rebase", "sql", "svn", "vcs", "version"])]
    [FontAwesomeCategories(["Coding"])]
    CodeBranch = 0xF126,

    /// <summary>
    /// The Font Awesome "code-commit" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["code commit", "commit", "git", "github", "hash", "rebase", "svn", "vcs", "version"])]
    [FontAwesomeCategories(["Coding"])]
    CodeCommit = 0xF386,

    /// <summary>
    /// The Font Awesome "code-compare" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["code compare", "compare", "git", "github", "svn", "version"])]
    [FontAwesomeCategories(["Coding"])]
    CodeCompare = 0xE13A,

    /// <summary>
    /// The Font Awesome "code-fork" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["code fork", "fork", "git", "github", "svn", "version"])]
    [FontAwesomeCategories(["Coding"])]
    CodeFork = 0xE13B,

    /// <summary>
    /// The Font Awesome "code-merge" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["code merge", "git", "github", "merge", "pr", "rebase", "svn", "vcs", "version"])]
    [FontAwesomeCategories(["Coding"])]
    CodeMerge = 0xF387,

    /// <summary>
    /// The Font Awesome "code-pull-request" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["code pull request", "git", "github", "pr", "svn", "version"])]
    [FontAwesomeCategories(["Coding"])]
    CodePullRequest = 0xE13C,

    /// <summary>
    /// The Font Awesome "mug-saucer" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mug saucer", "beverage", "breakfast", "cafe", "drink", "fall", "morning", "mug", "seasonal", "tea"])]
    [FontAwesomeCategories(["Business", "Coding", "Food + Beverage", "Household", "Maps", "Travel + Hotel"])]
    Coffee = 0xF0F4,

    /// <summary>
    /// The Font Awesome "gear" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cog", "cogwheel", "configuration", "gear", "mechanical", "modify", "settings", "sprocket", "tool", "wheel"])]
    [FontAwesomeCategories(["Coding", "Editing", "Spinners"])]
    Cog = 0xF013,

    /// <summary>
    /// The Font Awesome "gears" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["configuration", "gears", "mechanical", "modify", "settings", "sprocket", "wheel"])]
    [FontAwesomeCategories(["Coding", "Logistics"])]
    Cogs = 0xF085,

    /// <summary>
    /// The Font Awesome "coins" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["coins", "currency", "dime", "financial", "gold", "money", "penny", "premium"])]
    [FontAwesomeCategories(["Money"])]
    Coins = 0xF51E,

    /// <summary>
    /// The Font Awesome "colon-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["colon sign", "colon sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    ColonSign = 0xE140,

    /// <summary>
    /// The Font Awesome "table-columns" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table columns", "browser", "category", "dashboard", "organize", "panes", "split"])]
    [FontAwesomeCategories(["Business", "Text Formatting"])]
    Columns = 0xF0DB,

    /// <summary>
    /// The Font Awesome "comment" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comment", "right speech bubble", "answer", "bubble", "chat", "commenting", "conversation", "conversation", "discussion", "feedback", "message", "note", "notification", "sms", "speech", "talk", "talking", "texting"])]
    [FontAwesomeCategories(["Communication", "Shapes", "Social"])]
    Comment = 0xF075,

    /// <summary>
    /// The Font Awesome "message" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["answer", "bubble", "chat", "commenting", "conversation", "conversation", "discussion", "feedback", "message", "note", "notification", "sms", "speech", "talk", "talking", "texting"])]
    [FontAwesomeCategories(["Communication", "Social"])]
    CommentAlt = 0xF27A,

    /// <summary>
    /// The Font Awesome "comment-dollar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comment dollar", "answer", "bubble", "chat", "commenting", "conversation", "feedback", "message", "money", "note", "notification", "pay", "salary", "sms", "speech", "spend", "texting", "transfer"])]
    [FontAwesomeCategories(["Marketing", "Money"])]
    CommentDollar = 0xF651,

    /// <summary>
    /// The Font Awesome "comment-dots" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comment dots", "answer", "balloon", "bubble", "chat", "comic", "commenting", "conversation", "dialog", "feedback", "message", "more", "note", "notification", "reply", "request", "sms", "speech", "speech balloon", "texting"])]
    [FontAwesomeCategories(["Communication"])]
    CommentDots = 0xF4AD,

    /// <summary>
    /// The Font Awesome "comment-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comment medical", "advice", "answer", "bubble", "chat", "commenting", "conversation", "diagnose", "feedback", "message", "note", "notification", "prescription", "sms", "speech", "texting"])]
    [FontAwesomeCategories(["Communication", "Medical + Health"])]
    CommentMedical = 0xF7F5,

    /// <summary>
    /// The Font Awesome "comment-nodes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comment nodes", "ai", "artificial intelligence", "cluster", "language", "model", "network", "neuronal"])]
    [FontAwesomeCategories(["Coding", "Communication"])]
    CommentNodes = 0xE696,

    /// <summary>
    /// The Font Awesome "comments" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comments", "two speech bubbles", "answer", "bubble", "chat", "commenting", "conversation", "conversation", "discussion", "feedback", "message", "note", "notification", "sms", "speech", "talk", "talking", "texting"])]
    [FontAwesomeCategories(["Communication"])]
    Comments = 0xF086,

    /// <summary>
    /// The Font Awesome "comments-dollar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comments dollar", "answer", "bubble", "chat", "commenting", "conversation", "feedback", "message", "money", "note", "notification", "pay", "salary", "sms", "speech", "spend", "texting", "transfer"])]
    [FontAwesomeCategories(["Marketing", "Money"])]
    CommentsDollar = 0xF653,

    /// <summary>
    /// The Font Awesome "comment-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comment slash", "answer", "bubble", "cancel", "chat", "commenting", "conversation", "disabled", "feedback", "message", "mute", "note", "notification", "quiet", "sms", "speech", "texting"])]
    [FontAwesomeCategories(["Communication"])]
    CommentSlash = 0xF4B3,

    /// <summary>
    /// The Font Awesome "compact-disc" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["compact disc", "optical disc icon", "album", "blu-ray", "bluray", "cd", "computer", "disc", "disk", "dvd", "media", "movie", "music", "optical", "optical disk", "record", "video", "vinyl"])]
    [FontAwesomeCategories(["Devices + Hardware", "Film + Video", "Music + Audio", "Spinners"])]
    CompactDisc = 0xF51F,

    /// <summary>
    /// The Font Awesome "compass" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["compass", "directions", "directory", "location", "magnetic", "menu", "navigation", "orienteering", "safari", "travel"])]
    [FontAwesomeCategories(["Business", "Camping", "Spinners"])]
    Compass = 0xF14E,

    /// <summary>
    /// The Font Awesome "compress" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["compress", "collapse", "fullscreen", "minimize", "move", "resize", "shrink", "smaller"])]
    [FontAwesomeCategories(["Media Playback"])]
    Compress = 0xF066,

    /// <summary>
    /// The Font Awesome "down-left-and-up-right-to-center" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["down left and up right to center", "collapse", "fullscreen", "minimize", "move", "resize", "scale", "shrink", "size", "smaller"])]
    [FontAwesomeCategories(["Arrows", "Media Playback"])]
    CompressAlt = 0xF422,

    /// <summary>
    /// The Font Awesome "minimize" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["collapse", "fullscreen", "minimize", "move", "resize", "shrink", "smaller"])]
    [FontAwesomeCategories(["Media Playback", "Photos + Images"])]
    CompressArrowsAlt = 0xF78C,

    /// <summary>
    /// The Font Awesome "computer" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["computer", "desktop", "display", "monitor", "tower"])]
    [FontAwesomeCategories(["Devices + Hardware", "Household", "Humanitarian"])]
    Computer = 0xE4E5,

    /// <summary>
    /// The Font Awesome "bell-concierge" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bell concierge", "attention", "bell", "bellhop", "bellhop bell", "hotel", "receptionist", "request", "service", "support"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    ConciergeBell = 0xF562,

    /// <summary>
    /// The Font Awesome "cookie" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["baked good", "chips", "chocolate", "cookie", "dessert", "eat", "snack", "sweet", "treat"])]
    [FontAwesomeCategories(["Childhood", "Food + Beverage"])]
    Cookie = 0xF563,

    /// <summary>
    /// The Font Awesome "cookie-bite" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cookie bite", "baked good", "bitten", "chips", "chocolate", "eat", "snack", "sweet", "treat"])]
    [FontAwesomeCategories(["Childhood", "Holidays"])]
    CookieBite = 0xF564,

    /// <summary>
    /// The Font Awesome "copy" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["copy", "clone", "duplicate", "file", "files-o", "paper", "paste"])]
    [FontAwesomeCategories(["Business", "Design", "Files"])]
    Copy = 0xF0C5,

    /// <summary>
    /// The Font Awesome "copyright" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["brand", "c", "copyright", "mark", "register", "trademark"])]
    [FontAwesomeCategories(["Business"])]
    Copyright = 0xF1F9,

    /// <summary>
    /// The Font Awesome "couch" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["couch", "chair", "cushion", "furniture", "relax", "sofa"])]
    [FontAwesomeCategories(["Household", "Moving"])]
    Couch = 0xF4B8,

    /// <summary>
    /// The Font Awesome "cow" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["agriculture", "animal", "beef", "bovine", "co", "cow", "farm", "fauna", "livestock", "mammal", "milk", "moo"])]
    [FontAwesomeCategories(["Animals", "Humanitarian"])]
    Cow = 0xF6C8,

    /// <summary>
    /// The Font Awesome "credit-card" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["credit card", "buy", "card", "checkout", "credit", "credit card", "credit-card-alt", "debit", "money", "payment", "purchase"])]
    [FontAwesomeCategories(["Money", "Shopping"])]
    CreditCard = 0xF09D,

    /// <summary>
    /// The Font Awesome "crop" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["crop", "design", "frame", "mask", "modify", "resize", "shrink"])]
    [FontAwesomeCategories(["Design", "Editing"])]
    Crop = 0xF125,

    /// <summary>
    /// The Font Awesome "crop-simple" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["crop simple", "design", "frame", "mask", "modify", "resize", "shrink"])]
    [FontAwesomeCategories(["Design", "Editing"])]
    CropAlt = 0xF565,

    /// <summary>
    /// The Font Awesome "cross" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["christian", "heavy latin cross", "catholicism", "christianity", "church", "cross", "jesus", "latin cross", "religion"])]
    [FontAwesomeCategories(["Religion"])]
    Cross = 0xF654,

    /// <summary>
    /// The Font Awesome "crosshairs" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["crosshairs", "aim", "bullseye", "gpd", "picker", "position"])]
    [FontAwesomeCategories(["Design", "Maps", "Spinners"])]
    Crosshairs = 0xF05B,

    /// <summary>
    /// The Font Awesome "crow" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["crow", "bird", "bullfrog", "fauna", "halloween", "holiday", "toad"])]
    [FontAwesomeCategories(["Animals", "Halloween"])]
    Crow = 0xF520,

    /// <summary>
    /// The Font Awesome "crown" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["award", "clothing", "crown", "favorite", "king", "queen", "royal", "tiara", "vip"])]
    [FontAwesomeCategories(["Shapes"])]
    Crown = 0xF521,

    /// <summary>
    /// The Font Awesome "crutch" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["crutch", "cane", "injury", "mobility", "wheelchair"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Crutch = 0xF7F7,

    /// <summary>
    /// The Font Awesome "cruzeiro-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cruzeiro sign", "cruzeiro sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    CruzeiroSign = 0xE152,

    /// <summary>
    /// The Font Awesome "cube" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cube", "3d", "block", "dice", "package", "square", "tesseract"])]
    [FontAwesomeCategories(["Coding", "Design", "Editing"])]
    Cube = 0xF1B2,

    /// <summary>
    /// The Font Awesome "cubes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cubes", "3d", "block", "dice", "package", "pyramid", "square", "stack", "tesseract"])]
    [FontAwesomeCategories(["Coding", "Design"])]
    Cubes = 0xF1B3,

    /// <summary>
    /// The Font Awesome "cubes-stacked" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cubes stacked", "blocks", "cubes", "sugar"])]
    [FontAwesomeCategories(["Childhood", "Food + Beverage", "Humanitarian", "Shapes"])]
    CubesStacked = 0xE4E6,

    /// <summary>
    /// The Font Awesome "scissors" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["black safety scissors", "white scissors", "clip", "cutting", "equipment", "modify", "scissors", "snip", "tool"])]
    [FontAwesomeCategories(["Business", "Design", "Editing", "Files"])]
    Cut = 0xF0C4,

    /// <summary>
    /// The Font Awesome "database" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["database", "computer", "development", "directory", "memory", "mysql", "sql", "storage"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    Database = 0xF1C0,

    /// <summary>
    /// The Font Awesome "ear-deaf" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ear deaf", "ear", "hearing", "sign language"])]
    [FontAwesomeCategories(["Accessibility", "Communication"])]
    Deaf = 0xF2A4,

    /// <summary>
    /// The Font Awesome "democrat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["democrat", "american", "democratic party", "donkey", "election", "left", "left-wing", "liberal", "politics", "usa"])]
    [FontAwesomeCategories(["Political"])]
    Democrat = 0xF747,

    /// <summary>
    /// The Font Awesome "desktop" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF390.
    /// </summary>
    [FontAwesomeSearchTerms(["computer", "cpu", "demo", "desktop", "desktop computer", "device", "imac", "machine", "monitor", "pc", "screen"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    Desktop = 0xF108,

    /// <summary>
    /// The Font Awesome "dharmachakra" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dharmachakra", "buddhist", "buddhism", "buddhist", "dharma", "religion", "wheel", "wheel of dharma"])]
    [FontAwesomeCategories(["Religion", "Spinners"])]
    Dharmachakra = 0xF655,

    /// <summary>
    /// The Font Awesome "person-dots-from-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person dots from line", "allergy", "diagnosis", "uer"])]
    [FontAwesomeCategories(["Medical + Health", "Users + People"])]
    Diagnoses = 0xF470,

    /// <summary>
    /// The Font Awesome "diagram-next" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["diagram next", "cells", "chart", "gantt", "row", "subtask", "successor", "table"])]
    [FontAwesomeCategories(["Charts + Diagrams"])]
    DiagramNext = 0xE476,

    /// <summary>
    /// The Font Awesome "diagram-predecessor" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["diagram predecessor", "cells", "chart", "gantt", "predecessor", "previous", "row", "subtask", "table"])]
    [FontAwesomeCategories(["Charts + Diagrams"])]
    DiagramPredecessor = 0xE477,

    /// <summary>
    /// The Font Awesome "diagram-successor" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["diagram successor", "cells", "chart", "gantt", "next", "row", "subtask", "successor", "table"])]
    [FontAwesomeCategories(["Charts + Diagrams"])]
    DiagramSuccessor = 0xE47A,

    /// <summary>
    /// The Font Awesome "diamond" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["diamond", "ace", "card", "cards", "diamond suit", "game", "gem", "gemstone", "poker", "suit"])]
    [FontAwesomeCategories(["Gaming", "Shapes"])]
    Diamond = 0xF219,

    /// <summary>
    /// The Font Awesome "dice" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["chance", "dice", "die", "gambling", "game", "game die", "roll"])]
    [FontAwesomeCategories(["Gaming", "Travel + Hotel"])]
    Dice = 0xF522,

    /// <summary>
    /// The Font Awesome "dice-d20" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dice d20", "dungeons & dragons", "chance", "d&d", "dnd", "fantasy", "gambling", "game", "roll"])]
    [FontAwesomeCategories(["Gaming"])]
    DiceD20 = 0xF6CF,

    /// <summary>
    /// The Font Awesome "dice-d6" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dice d6", "dungeons & dragons", "chance", "d&d", "dnd", "fantasy", "gambling", "game", "roll"])]
    [FontAwesomeCategories(["Gaming"])]
    DiceD6 = 0xF6D1,

    /// <summary>
    /// The Font Awesome "dice-five" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dice five", "die face-5", "chance", "gambling", "game", "roll"])]
    [FontAwesomeCategories(["Gaming", "Travel + Hotel"])]
    DiceFive = 0xF523,

    /// <summary>
    /// The Font Awesome "dice-four" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dice four", "die face-4", "chance", "gambling", "game", "roll"])]
    [FontAwesomeCategories(["Gaming"])]
    DiceFour = 0xF524,

    /// <summary>
    /// The Font Awesome "dice-one" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dice one", "die face-1", "chance", "gambling", "game", "roll"])]
    [FontAwesomeCategories(["Gaming"])]
    DiceOne = 0xF525,

    /// <summary>
    /// The Font Awesome "dice-six" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dice six", "die face-6", "chance", "gambling", "game", "roll"])]
    [FontAwesomeCategories(["Gaming"])]
    DiceSix = 0xF526,

    /// <summary>
    /// The Font Awesome "dice-three" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dice three", "die face-3", "chance", "gambling", "game", "roll"])]
    [FontAwesomeCategories(["Gaming"])]
    DiceThree = 0xF527,

    /// <summary>
    /// The Font Awesome "dice-two" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dice two", "die face-2", "chance", "gambling", "game", "roll"])]
    [FontAwesomeCategories(["Gaming"])]
    DiceTwo = 0xF528,

    /// <summary>
    /// The Font Awesome "tachograph-digital" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tachograph digital", "data", "distance", "speed", "tachometer"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    DigitalTachograph = 0xF566,

    /// <summary>
    /// The Font Awesome "diamond-turn-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["diamond turn right", "map", "navigation", "sign", "turn"])]
    [FontAwesomeCategories(["Maps"])]
    Directions = 0xF5EB,

    /// <summary>
    /// The Font Awesome "disease" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["disease", "bacteria", "cancer", "coronavirus", "covid-19", "flu", "illness", "infection", "pandemic", "sickness", "virus"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    Disease = 0xF7FA,

    /// <summary>
    /// The Font Awesome "display" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["display", "screen", "computer", "desktop", "imac"])]
    [FontAwesomeCategories(["Devices + Hardware", "Humanitarian"])]
    Display = 0xE163,

    /// <summary>
    /// The Font Awesome "divide" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["division sign", "arithmetic", "calculus", "divide", "division", "math", "sign", "÷"])]
    [FontAwesomeCategories(["Mathematics"])]
    Divide = 0xF529,

    /// <summary>
    /// The Font Awesome "face-dizzy" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face dizzy", "dazed", "dead", "disapprove", "emoticon", "face"])]
    [FontAwesomeCategories(["Emoji"])]
    Dizzy = 0xF567,

    /// <summary>
    /// The Font Awesome "dna" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["biologist", "dna", "double helix", "evolution", "gene", "genetic", "genetics", "helix", "life", "molecule", "protein"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    Dna = 0xF471,

    /// <summary>
    /// The Font Awesome "dog" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["animal", "canine", "dog", "fauna", "mammal", "pet", "pooch", "puppy", "woof"])]
    [FontAwesomeCategories(["Animals"])]
    Dog = 0xF6D3,

    /// <summary>
    /// The Font Awesome "dollar-sign" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x24.
    /// </summary>
    [FontAwesomeSearchTerms(["dollar sign", "dollar sign", "coupon", "currency", "dollar", "heavy dollar sign", "investment", "money", "premium", "revenue", "salary"])]
    [FontAwesomeCategories(["Charity", "Maps", "Money"])]
    DollarSign = 0xF155,

    /// <summary>
    /// The Font Awesome "dolly" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dolly", "carry", "shipping", "transport"])]
    [FontAwesomeCategories(["Logistics", "Moving"])]
    Dolly = 0xF472,

    /// <summary>
    /// The Font Awesome "cart-flatbed" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cart flatbed", "carry", "inventory", "shipping", "transport"])]
    [FontAwesomeCategories(["Logistics"])]
    DollyFlatbed = 0xF474,

    /// <summary>
    /// The Font Awesome "circle-dollar-to-slot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle dollar to slot", "contribute", "generosity", "gift", "give", "premium"])]
    [FontAwesomeCategories(["Charity", "Money", "Political"])]
    Donate = 0xF4B9,

    /// <summary>
    /// The Font Awesome "dong-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dong sign", "dong sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    DongSign = 0xE169,

    /// <summary>
    /// The Font Awesome "door-closed" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["door closed", "doo", "door", "enter", "exit", "locked", "privacy"])]
    [FontAwesomeCategories(["Household", "Security", "Travel + Hotel"])]
    DoorClosed = 0xF52A,

    /// <summary>
    /// The Font Awesome "door-open" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["door open", "enter", "exit", "welcome"])]
    [FontAwesomeCategories(["Household", "Security", "Travel + Hotel"])]
    DoorOpen = 0xF52B,

    /// <summary>
    /// The Font Awesome "circle-dot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle dot", "bullseye", "button", "geometric", "notification", "radio", "radio button", "target"])]
    [FontAwesomeCategories(["Toggle"])]
    DotCircle = 0xF192,

    /// <summary>
    /// The Font Awesome "dove" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bird", "dove", "fauna", "fly", "flying", "peace", "war"])]
    [FontAwesomeCategories(["Animals", "Charity", "Political", "Religion"])]
    Dove = 0xF4BA,

    /// <summary>
    /// The Font Awesome "download" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["download", "export", "hard drive", "insert", "save", "transfer"])]
    [FontAwesomeCategories(["Arrows", "Devices + Hardware"])]
    Download = 0xF019,

    /// <summary>
    /// The Font Awesome "compass-drafting" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["compass drafting", "design", "map", "mechanical drawing", "plot", "plotting"])]
    [FontAwesomeCategories(["Construction", "Design"])]
    DraftingCompass = 0xF568,

    /// <summary>
    /// The Font Awesome "dragon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dungeons & dragons", "d&d", "dnd", "dragon", "fairy tale", "fantasy", "fire", "lizard", "serpent"])]
    [FontAwesomeCategories(["Animals", "Gaming"])]
    Dragon = 0xF6D5,

    /// <summary>
    /// The Font Awesome "draw-polygon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["draw polygon", "anchors", "lines", "object", "render", "shape"])]
    [FontAwesomeCategories(["Design", "Maps"])]
    DrawPolygon = 0xF5EE,

    /// <summary>
    /// The Font Awesome "drum" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["drum", "drumsticks", "instrument", "music", "percussion", "snare", "sound"])]
    [FontAwesomeCategories(["Music + Audio"])]
    Drum = 0xF569,

    /// <summary>
    /// The Font Awesome "drum-steelpan" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["drum steelpan", "calypso", "instrument", "music", "percussion", "reggae", "snare", "sound", "steel", "tropical"])]
    [FontAwesomeCategories(["Music + Audio"])]
    DrumSteelpan = 0xF56A,

    /// <summary>
    /// The Font Awesome "drumstick-bite" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["drumstick bite", "bone", "chicken", "leg", "meat", "poultry", "turkey"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    DrumstickBite = 0xF6D7,

    /// <summary>
    /// The Font Awesome "dumbbell" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dumbbell", "exercise", "gym", "strength", "weight", "weight-lifting", "workout"])]
    [FontAwesomeCategories(["Sports + Fitness", "Travel + Hotel"])]
    Dumbbell = 0xF44B,

    /// <summary>
    /// The Font Awesome "dumpster" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dumpster", "alley", "bin", "commercial", "trash", "waste"])]
    [FontAwesomeCategories(["Construction"])]
    Dumpster = 0xF793,

    /// <summary>
    /// The Font Awesome "dumpster-fire" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dumpster fire", "alley", "bin", "commercial", "danger", "dangerous", "euphemism", "flame", "heat", "hot", "trash", "waste"])]
    [FontAwesomeCategories(["Construction", "Political"])]
    DumpsterFire = 0xF794,

    /// <summary>
    /// The Font Awesome "dungeon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dungeon", "dungeons & dragons", "building", "d&d", "dnd", "door", "entrance", "fantasy", "gate"])]
    [FontAwesomeCategories(["Buildings", "Gaming", "Household", "Security"])]
    Dungeon = 0xF6D9,

    /// <summary>
    /// The Font Awesome "earth-oceania" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["earth oceania", "all", "australia", "country", "earth", "global", "globe", "gps", "language", "localize", "location", "map", "melanesia", "micronesia", "new zealand", "online", "place", "planet", "polynesia", "translate", "travel", "world"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    EarthOceania = 0xE47B,

    /// <summary>
    /// The Font Awesome "pen-to-square" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pen to square", "edit", "modify", "pen", "pencil", "update", "write"])]
    [FontAwesomeCategories(["Business", "Design", "Editing", "Writing"])]
    Edit = 0xF044,

    /// <summary>
    /// The Font Awesome "egg" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["breakfast", "chicken", "easter", "egg", "food", "shell", "yolk"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    Egg = 0xF7FB,

    /// <summary>
    /// The Font Awesome "eject" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["abort", "cancel", "cd", "discharge", "eject", "eject button"])]
    [FontAwesomeCategories(["Media Playback"])]
    Eject = 0xF052,

    /// <summary>
    /// The Font Awesome "elevator" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["accessibility", "elevator", "hoist", "lift", "uer", "users-people"])]
    [FontAwesomeCategories(["Travel + Hotel", "Users + People"])]
    Elevator = 0xE16D,

    /// <summary>
    /// The Font Awesome "ellipsis" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ellipsis", "dots", "drag", "kebab", "list", "menu", "nav", "navigation", "ol", "pacman", "reorder", "settings", "three dots", "ul"])]
    [FontAwesomeCategories(["Editing"])]
    EllipsisH = 0xF141,

    /// <summary>
    /// The Font Awesome "ellipsis-vertical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ellipsis vertical", "bullet", "dots", "drag", "kebab", "list", "menu", "nav", "navigation", "ol", "reorder", "settings", "three dots", "ul"])]
    [FontAwesomeCategories(["Editing"])]
    EllipsisV = 0xF142,

    /// <summary>
    /// The Font Awesome "envelope" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["back of envelope", "e-mail", "email", "envelope", "letter", "mail", "message", "newsletter", "notification", "offer", "support"])]
    [FontAwesomeCategories(["Business", "Communication", "Humanitarian", "Social", "Writing"])]
    Envelope = 0xF0E0,

    /// <summary>
    /// The Font Awesome "envelope-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["envelope circle check", "check", "email", "enable", "envelope", "mail", "not affected", "ok", "okay", "read", "sent", "validate", "working"])]
    [FontAwesomeCategories(["Business", "Communication", "Humanitarian"])]
    EnvelopeCircleCheck = 0xE4E8,

    /// <summary>
    /// The Font Awesome "envelope-open" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["envelope open", "e-mail", "email", "letter", "mail", "message", "newsletter", "notification", "offer", "support"])]
    [FontAwesomeCategories(["Business", "Communication", "Writing"])]
    EnvelopeOpen = 0xF2B6,

    /// <summary>
    /// The Font Awesome "envelope-open-text" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["envelope open text", "e-mail", "email", "letter", "mail", "message", "newsletter", "notification", "offer", "support"])]
    [FontAwesomeCategories(["Marketing"])]
    EnvelopeOpenText = 0xF658,

    /// <summary>
    /// The Font Awesome "square-envelope" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square envelope", "e-mail", "email", "letter", "mail", "message", "notification", "offer", "support"])]
    [FontAwesomeCategories(["Business", "Communication"])]
    EnvelopeSquare = 0xF199,

    /// <summary>
    /// The Font Awesome "equals" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x3D.
    /// </summary>
    [FontAwesomeSearchTerms(["equals", "equals sign", "arithmetic", "even", "match", "math"])]
    [FontAwesomeCategories(["Mathematics", "Punctuation + Symbols"])]
    Equals = 0xF52C,

    /// <summary>
    /// The Font Awesome "eraser" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["eraser", "art", "delete", "remove", "rubber"])]
    [FontAwesomeCategories(["Business", "Design", "Writing"])]
    Eraser = 0xF12D,

    /// <summary>
    /// The Font Awesome "ethernet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ethernet", "cable", "cat 5", "cat 6", "connection", "hardware", "internet", "network", "wired"])]
    [FontAwesomeCategories(["Connectivity", "Devices + Hardware"])]
    Ethernet = 0xF796,

    /// <summary>
    /// The Font Awesome "euro-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["euro sign", "euro sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    EuroSign = 0xF153,

    /// <summary>
    /// The Font Awesome "right-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["right left", "arrow", "arrows", "exchange", "reciprocate", "return", "swap", "transfer"])]
    [FontAwesomeCategories(["Arrows"])]
    ExchangeAlt = 0xF362,

    /// <summary>
    /// The Font Awesome "exclamation" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x21.
    /// </summary>
    [FontAwesomeSearchTerms(["!", "exclamation mark", "alert", "attention", "danger", "error", "exclamation", "failed", "important", "mark", "notice", "notification", "notify", "outlined", "problem", "punctuation", "red exclamation mark", "required", "warning", "white exclamation mark"])]
    [FontAwesomeCategories(["Alert", "Punctuation + Symbols"])]
    Exclamation = 0xF12A,

    /// <summary>
    /// The Font Awesome "circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle exclamation", "affect", "alert", "attention", "damage", "danger", "error", "failed", "important", "notice", "notification", "notify", "problem", "required", "warning"])]
    [FontAwesomeCategories(["Alert", "Punctuation + Symbols"])]
    ExclamationCircle = 0xF06A,

    /// <summary>
    /// The Font Awesome "triangle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["triangle exclamation", "alert", "attention", "danger", "error", "failed", "important", "notice", "notification", "notify", "problem", "required", "warnin", "warning"])]
    [FontAwesomeCategories(["Alert"])]
    ExclamationTriangle = 0xF071,

    /// <summary>
    /// The Font Awesome "expand" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows", "bigger", "enlarge", "expand", "fullscreen", "maximize", "resize", "resize", "scale", "size", "viewfinder"])]
    [FontAwesomeCategories(["Media Playback"])]
    Expand = 0xF065,

    /// <summary>
    /// The Font Awesome "up-right-and-down-left-from-center" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["up right and down left from center", "arrows", "bigger", "enlarge", "expand", "fullscreen", "maximize", "resize", "resize", "scale", "size"])]
    [FontAwesomeCategories(["Arrows", "Media Playback"])]
    ExpandAlt = 0xF424,

    /// <summary>
    /// The Font Awesome "maximize" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows", "bigger", "enlarge", "expand", "fullscreen", "maximize", "resize", "resize", "scale", "size"])]
    [FontAwesomeCategories(["Arrows", "Media Playback"])]
    ExpandArrowsAlt = 0xF31E,

    /// <summary>
    /// The Font Awesome "explosion" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["blast", "blowup", "boom", "crash", "detonation", "explosion"])]
    [FontAwesomeCategories(["Energy", "Humanitarian", "Science Fiction", "Security"])]
    Explosion = 0xE4E9,

    /// <summary>
    /// The Font Awesome "up-right-from-square" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["up right from square", "external-link", "new", "open", "share", "upgrade"])]
    [FontAwesomeCategories(["Arrows"])]
    ExternalLinkAlt = 0xF35D,

    /// <summary>
    /// The Font Awesome "square-up-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square up right", "arrow", "diagonal", "direction", "external-link-square", "intercardinal", "new", "northeast", "open", "share", "up-right arrow"])]
    [FontAwesomeCategories(["Arrows"])]
    ExternalLinkSquareAlt = 0xF360,

    /// <summary>
    /// The Font Awesome "eye" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["body", "eye", "look", "optic", "see", "seen", "show", "sight", "views", "visible"])]
    [FontAwesomeCategories(["Accessibility", "Design", "Maps", "Medical + Health", "Photos + Images", "Security"])]
    Eye = 0xF06E,

    /// <summary>
    /// The Font Awesome "eye-dropper" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["eye dropper", "beaker", "clone", "color", "copy", "eyedropper", "pipette"])]
    [FontAwesomeCategories(["Design", "Editing", "Medical + Health", "Photos + Images", "Science"])]
    EyeDropper = 0xF1FB,

    /// <summary>
    /// The Font Awesome "eye-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["eye slash", "blind", "disabled", "hide", "show", "toggle", "unseen", "views", "visible", "visiblity"])]
    [FontAwesomeCategories(["Design", "Editing", "Maps", "Photos + Images", "Security"])]
    EyeSlash = 0xF070,

    /// <summary>
    /// The Font Awesome "fan" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fan", "ac", "air conditioning", "blade", "blower", "cool", "hot"])]
    [FontAwesomeCategories(["Energy", "Household", "Spinners"])]
    Fan = 0xF863,

    /// <summary>
    /// The Font Awesome "backward-fast" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["backward fast", "arrow", "beginning", "first", "last track button", "previous", "previous scene", "previous track", "quick", "rewind", "start", "triangle"])]
    [FontAwesomeCategories(["Media Playback"])]
    FastBackward = 0xF049,

    /// <summary>
    /// The Font Awesome "forward-fast" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["forward fast", "arrow", "end", "last", "next", "next scene", "next track", "next track button", "quick", "triangle"])]
    [FontAwesomeCategories(["Media Playback"])]
    FastForward = 0xF050,

    /// <summary>
    /// The Font Awesome "faucet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["faucet", "covid-19", "drinking", "drip", "house", "hygiene", "kitchen", "potable", "potable water", "sanitation", "sink", "water"])]
    [FontAwesomeCategories(["Camping", "Household"])]
    Faucet = 0xE005,

    /// <summary>
    /// The Font Awesome "faucet-drip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["faucet drip", "drinking", "drip", "house", "hygiene", "kitchen", "potable", "potable water", "sanitation", "sink", "water"])]
    [FontAwesomeCategories(["Camping", "Household", "Humanitarian"])]
    FaucetDrip = 0xE006,

    /// <summary>
    /// The Font Awesome "fax" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fax icon", "business", "communicate", "copy", "facsimile", "fax", "fax machine", "send"])]
    [FontAwesomeCategories(["Business", "Communication", "Devices + Hardware", "Humanitarian"])]
    Fax = 0xF1AC,

    /// <summary>
    /// The Font Awesome "feather" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bird", "feather", "flight", "light", "plucked", "plumage", "quill", "write"])]
    [FontAwesomeCategories(["Animals", "Nature"])]
    Feather = 0xF52D,

    /// <summary>
    /// The Font Awesome "feather-pointed" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["feather pointed", "bird", "light", "plucked", "quill", "write"])]
    [FontAwesomeCategories(["Animals", "Nature"])]
    FeatherAlt = 0xF56B,

    /// <summary>
    /// The Font Awesome "person-dress" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person dress", "man", "skirt", "uer", "woman"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    Female = 0xF182,

    /// <summary>
    /// The Font Awesome "ferry" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ferry", "barge", "boat", "carry", "ferryboat", "ship"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maritime", "Transportation"])]
    Ferry = 0xE4EA,

    /// <summary>
    /// The Font Awesome "jet-fighter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["jet fighter", "airforce", "airplane", "airport", "fast", "fly", "goose", "marines", "maverick", "military", "plane", "quick", "top gun", "transportation", "travel"])]
    [FontAwesomeCategories(["Maps", "Transportation"])]
    FighterJet = 0xF0FB,

    /// <summary>
    /// The Font Awesome "file" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file", "empty document", "cv", "document", "new", "page", "page facing up", "pdf", "resume"])]
    [FontAwesomeCategories(["Business", "Coding", "Files", "Humanitarian", "Shapes", "Writing"])]
    File = 0xF15B,

    /// <summary>
    /// The Font Awesome "file-lines" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file lines", "document", "document with text", "document", "file-text", "invoice", "new", "page", "pdf"])]
    [FontAwesomeCategories(["Business", "Coding", "Files", "Writing"])]
    FileAlt = 0xF15C,

    /// <summary>
    /// The Font Awesome "file-zipper" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file zipper", ".zip", "bundle", "compress", "compression", "download", "zip"])]
    [FontAwesomeCategories(["Files"])]
    FileArchive = 0xF1C6,

    /// <summary>
    /// The Font Awesome "file-audio" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file audio", "document", "mp3", "music", "page", "play", "sound"])]
    [FontAwesomeCategories(["Files", "Film + Video", "Music + Audio"])]
    FileAudio = 0xF1C7,

    /// <summary>
    /// The Font Awesome "file-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file circle check", "document", "enable", "file", "not affected", "ok", "okay", "paper", "validate", "working"])]
    [FontAwesomeCategories(["Files", "Humanitarian"])]
    FileCircleCheck = 0xE5A0,

    /// <summary>
    /// The Font Awesome "file-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file circle exclamation", "document", "failed", "file", "paper"])]
    [FontAwesomeCategories(["Files", "Humanitarian"])]
    FileCircleExclamation = 0xE4EB,

    /// <summary>
    /// The Font Awesome "file-circle-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file circle minus", "document", "file", "paper"])]
    [FontAwesomeCategories(["Files", "Humanitarian"])]
    FileCircleMinus = 0xE4ED,

    /// <summary>
    /// The Font Awesome "file-circle-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file circle plus", "add", "document", "file", "new", "page", "paper", "pdf"])]
    [FontAwesomeCategories(["Business", "Files", "Humanitarian"])]
    FileCirclePlus = 0xE494,

    /// <summary>
    /// The Font Awesome "file-circle-question" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file circle question", "document", "file", "paper"])]
    [FontAwesomeCategories(["Files", "Humanitarian"])]
    FileCircleQuestion = 0xE4EF,

    /// <summary>
    /// The Font Awesome "file-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file circle xmark", "document", "file", "paper", "uncheck"])]
    [FontAwesomeCategories(["Files", "Humanitarian"])]
    FileCircleXmark = 0xE5A1,

    /// <summary>
    /// The Font Awesome "file-code" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file code", "css", "development", "document", "html", "mysql", "sql"])]
    [FontAwesomeCategories(["Coding", "Files"])]
    FileCode = 0xF1C9,

    /// <summary>
    /// The Font Awesome "file-contract" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file contract", "agreement", "binding", "document", "legal", "signature", "username"])]
    [FontAwesomeCategories(["Security"])]
    FileContract = 0xF56C,

    /// <summary>
    /// The Font Awesome "file-csv" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file csv", "document", "excel", "numbers", "spreadsheets", "table"])]
    [FontAwesomeCategories(["Files", "Humanitarian"])]
    FileCsv = 0xF6DD,

    /// <summary>
    /// The Font Awesome "file-arrow-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file arrow down", "archive", "document", "export", "insert", "save"])]
    [FontAwesomeCategories(["Files"])]
    FileDownload = 0xF56D,

    /// <summary>
    /// The Font Awesome "file-excel" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file excel", "csv", "document", "numbers", "spreadsheets", "table"])]
    [FontAwesomeCategories(["Files"])]
    FileExcel = 0xF1C3,

    /// <summary>
    /// The Font Awesome "file-export" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file export", "download", "save"])]
    [FontAwesomeCategories(["Files"])]
    FileExport = 0xF56E,

    /// <summary>
    /// The Font Awesome "file-fragment" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file fragment", "block", "data", "partial", "piece"])]
    [FontAwesomeCategories(["Files"])]
    FileFragment = 0xE697,

    /// <summary>
    /// The Font Awesome "file-half-dashed" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file half dashed", "data", "fragment", "partial", "piece"])]
    [FontAwesomeCategories(["Files"])]
    FileHalfDashed = 0xE698,

    /// <summary>
    /// The Font Awesome "file-image" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file image", "document with picture", "document", "image", "img", "jpg", "photo", "png"])]
    [FontAwesomeCategories(["Files", "Photos + Images"])]
    FileImage = 0xF1C5,

    /// <summary>
    /// The Font Awesome "file-import" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file import", "copy", "document", "insert", "send", "upload"])]
    [FontAwesomeCategories(["Files"])]
    FileImport = 0xF56F,

    /// <summary>
    /// The Font Awesome "file-invoice" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file invoice", "account", "bill", "charge", "document", "payment", "receipt"])]
    [FontAwesomeCategories(["Money"])]
    FileInvoice = 0xF570,

    /// <summary>
    /// The Font Awesome "file-invoice-dollar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file invoice dollar", "$", "account", "bill", "charge", "document", "dollar-sign", "money", "payment", "receipt", "revenue", "salary", "usd"])]
    [FontAwesomeCategories(["Money"])]
    FileInvoiceDollar = 0xF571,

    /// <summary>
    /// The Font Awesome "file-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file medical", "document", "health", "history", "prescription", "record"])]
    [FontAwesomeCategories(["Medical + Health"])]
    FileMedical = 0xF477,

    /// <summary>
    /// The Font Awesome "file-waveform" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file waveform", "document", "health", "history", "prescription", "record"])]
    [FontAwesomeCategories(["Medical + Health"])]
    FileMedicalAlt = 0xF478,

    /// <summary>
    /// The Font Awesome "file-pdf" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file pdf", "acrobat", "document", "preview", "save"])]
    [FontAwesomeCategories(["Files", "Humanitarian"])]
    FilePdf = 0xF1C1,

    /// <summary>
    /// The Font Awesome "file-pen" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file pen", "edit", "memo", "modify", "pen", "pencil", "update", "write"])]
    [FontAwesomeCategories(["Files", "Humanitarian"])]
    FilePen = 0xF31C,

    /// <summary>
    /// The Font Awesome "file-powerpoint" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file powerpoint", "display", "document", "keynote", "presentation"])]
    [FontAwesomeCategories(["Files"])]
    FilePowerpoint = 0xF1C4,

    /// <summary>
    /// The Font Awesome "file-prescription" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file prescription", "document", "drugs", "medical", "medicine", "rx"])]
    [FontAwesomeCategories(["Medical + Health"])]
    FilePrescription = 0xF572,

    /// <summary>
    /// The Font Awesome "file-shield" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file shield", "antivirus", "data", "document", "protect", "safe", "safety", "secure"])]
    [FontAwesomeCategories(["Files", "Humanitarian", "Security"])]
    FileShield = 0xE4F0,

    /// <summary>
    /// The Font Awesome "file-signature" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file signature", "john hancock", "contract", "document", "name", "username"])]
    [FontAwesomeCategories(["Security"])]
    FileSignature = 0xF573,

    /// <summary>
    /// The Font Awesome "file-arrow-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file arrow up", "document", "import", "page", "save", "upgrade"])]
    [FontAwesomeCategories(["Files"])]
    FileUpload = 0xF574,

    /// <summary>
    /// The Font Awesome "file-video" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file video", "document", "m4v", "movie", "mp4", "play"])]
    [FontAwesomeCategories(["Files", "Film + Video"])]
    FileVideo = 0xF1C8,

    /// <summary>
    /// The Font Awesome "file-word" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["file word", "document", "edit", "page", "text", "writing"])]
    [FontAwesomeCategories(["Files"])]
    FileWord = 0xF1C2,

    /// <summary>
    /// The Font Awesome "fill" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fill", "bucket", "color", "paint", "paint bucket"])]
    [FontAwesomeCategories(["Design"])]
    Fill = 0xF575,

    /// <summary>
    /// The Font Awesome "fill-drip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fill drip", "bucket", "color", "drop", "paint", "paint bucket", "spill"])]
    [FontAwesomeCategories(["Design"])]
    FillDrip = 0xF576,

    /// <summary>
    /// The Font Awesome "film" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cinema", "film", "film frames", "frames", "movie", "strip", "video"])]
    [FontAwesomeCategories(["Film + Video", "Photos + Images"])]
    Film = 0xF008,

    /// <summary>
    /// The Font Awesome "filter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["filter", "funnel", "options", "separate", "sort"])]
    [FontAwesomeCategories(["Coding", "Science"])]
    Filter = 0xF0B0,

    /// <summary>
    /// The Font Awesome "filter-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["filter circle xmark", "cancel", "funnel", "options", "remove", "separate", "sort", "uncheck"])]
    [FontAwesomeCategories(["Text Formatting"])]
    FilterCircleXmark = 0xE17B,

    /// <summary>
    /// The Font Awesome "fingerprint" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fingerprint", "human", "id", "identification", "lock", "privacy", "smudge", "touch", "unique", "unlock"])]
    [FontAwesomeCategories(["Accessibility", "Security"])]
    Fingerprint = 0xF577,

    /// <summary>
    /// The Font Awesome "fire" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["burn", "caliente", "fire", "flame", "heat", "hot", "popular", "tool"])]
    [FontAwesomeCategories(["Camping", "Energy", "Maps", "Nature", "Science"])]
    Fire = 0xF06D,

    /// <summary>
    /// The Font Awesome "fire-flame-curved" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fire flame curved", "burn", "caliente", "flame", "heat", "hot", "popular"])]
    [FontAwesomeCategories(["Camping", "Energy", "Maps", "Science", "Sports + Fitness"])]
    FireAlt = 0xF7E4,

    /// <summary>
    /// The Font Awesome "fire-burner" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fire burner", "cook", "fire", "flame", "kitchen", "stove"])]
    [FontAwesomeCategories(["Camping", "Household", "Humanitarian"])]
    FireBurner = 0xE4F1,

    /// <summary>
    /// The Font Awesome "fire-extinguisher" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fire extinguisher", "burn", "caliente", "extinguish", "fire", "fire extinguisher", "fire fighter", "flame", "heat", "hot", "quench", "rescue"])]
    [FontAwesomeCategories(["Coding", "Maps"])]
    FireExtinguisher = 0xF134,

    /// <summary>
    /// The Font Awesome "kit-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["kit medical", "emergency", "emt", "health", "medical", "rescue"])]
    [FontAwesomeCategories(["Camping", "Medical + Health"])]
    FirstAid = 0xF479,

    /// <summary>
    /// The Font Awesome "fish" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pisces", "fauna", "fish", "gold", "seafood", "swimming", "zodiac"])]
    [FontAwesomeCategories(["Animals", "Food + Beverage", "Maritime"])]
    Fish = 0xF578,

    /// <summary>
    /// The Font Awesome "fish-fins" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["fish fins", "fish", "fishery", "pisces", "seafood"])]
    [FontAwesomeCategories(["Animals", "Food + Beverage", "Humanitarian", "Maritime"])]
    FishFins = 0xE4F2,

    /// <summary>
    /// The Font Awesome "hand-fist" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand fist", "dungeons & dragons", "clenched", "d&d", "dnd", "fantasy", "fist", "hand", "ki", "monk", "punch", "raised fist", "resist", "strength", "unarmed combat"])]
    [FontAwesomeCategories(["Gaming", "Hands", "Political"])]
    FistRaised = 0xF6DE,

    /// <summary>
    /// The Font Awesome "flag" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["flag", "black flag", "country", "notice", "notification", "notify", "pole", "report", "symbol", "waving"])]
    [FontAwesomeCategories(["Humanitarian", "Maps"])]
    Flag = 0xF024,

    /// <summary>
    /// The Font Awesome "flag-checkered" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["flag checkered", "checkered", "chequered", "chequered flag", "finish", "notice", "notification", "notify", "pole", "racing", "report", "start", "symbol", "win"])]
    [FontAwesomeCategories(["Maps"])]
    FlagCheckered = 0xF11E,

    /// <summary>
    /// The Font Awesome "flag-usa" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["flag usa", "betsy ross", "country", "fla", "flag: united states", "old glory", "stars", "stripes", "symbol"])]
    [FontAwesomeCategories(["Political"])]
    FlagUsa = 0xF74D,

    /// <summary>
    /// The Font Awesome "flask" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["flask", "beaker", "chemicals", "experiment", "experimental", "knowledge", "labs", "liquid", "potion", "science", "vial"])]
    [FontAwesomeCategories(["Food + Beverage", "Maps", "Medical + Health", "Science"])]
    Flask = 0xF0C3,

    /// <summary>
    /// The Font Awesome "flask-vial" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["flask vial", "ampule", "beaker", "chemicals", "chemistry", "experiment", "experimental", "lab", "laboratory", "labs", "liquid", "potion", "science", "test", "test tube", "vial"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health", "Science"])]
    FlaskVial = 0xE4F3,

    /// <summary>
    /// The Font Awesome "florin-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["florin sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    FlorinSign = 0xE184,

    /// <summary>
    /// The Font Awesome "face-flushed" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face flushed", "dazed", "embarrassed", "emoticon", "face", "flushed", "flushed face"])]
    [FontAwesomeCategories(["Emoji"])]
    Flushed = 0xF579,

    /// <summary>
    /// The Font Awesome "folder" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["black folder", "archive", "directory", "document", "file", "file folder", "folder"])]
    [FontAwesomeCategories(["Business", "Coding", "Files", "Shapes", "Writing"])]
    Folder = 0xF07B,

    /// <summary>
    /// The Font Awesome "folder-closed" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["folder closed", "file"])]
    [FontAwesomeCategories(["Files"])]
    FolderClosed = 0xE185,

    /// <summary>
    /// The Font Awesome "folder-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["folder minus", "archive", "delete", "directory", "document", "file", "negative", "remove"])]
    [FontAwesomeCategories(["Business"])]
    FolderMinus = 0xF65D,

    /// <summary>
    /// The Font Awesome "folder-open" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["folder open", "open folder", "archive", "directory", "document", "empty", "file", "folder", "new", "open", "open file folder"])]
    [FontAwesomeCategories(["Business", "Coding", "Files", "Writing"])]
    FolderOpen = 0xF07C,

    /// <summary>
    /// The Font Awesome "folder-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["folder plus", "add", "archive", "create", "directory", "document", "file", "new", "positive"])]
    [FontAwesomeCategories(["Business"])]
    FolderPlus = 0xF65E,

    /// <summary>
    /// The Font Awesome "folder-tree" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["folder tree", "archive", "directory", "document", "file", "search", "structure"])]
    [FontAwesomeCategories(["Business"])]
    FolderTree = 0xF802,

    /// <summary>
    /// The Font Awesome "font" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["font", "alphabet", "glyph", "text", "type", "typeface"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Font = 0xF031,

    /// <summary>
    /// The Font Awesome "font-awesome" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["font awesome", "awesome", "flag", "font", "icons", "typeface"])]
    [FontAwesomeCategories(["Coding", "Design"])]
    FontAwesome = 0xF2B4,

    /// <summary>
    /// The Font Awesome "font-awesome" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF2B4.
    /// </summary>
    [FontAwesomeSearchTerms(["font awesome", "awesome", "flag", "font", "icons", "typeface"])]
    [FontAwesomeCategories(["Coding", "Design"])]
    FontAwesomeFlag = 0xF425,

    /// <summary>
    /// The Font Awesome "font-awesome" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF2B4.
    /// </summary>
    [FontAwesomeSearchTerms(["font awesome", "awesome", "flag", "font", "icons", "typeface"])]
    [FontAwesomeCategories(["Coding", "Design"])]
    FontAwesomeLogoFull = 0xF4E6,

    /// <summary>
    /// The Font Awesome "football" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["american", "american football", "ball", "fall", "football", "nfl", "pigskin", "seasonal"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    FootballBall = 0xF44E,

    /// <summary>
    /// The Font Awesome "forward" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow", "double", "fast", "fast-forward button", "forward", "next", "skip"])]
    [FontAwesomeCategories(["Media Playback"])]
    Forward = 0xF04E,

    /// <summary>
    /// The Font Awesome "franc-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["franc sign", "french franc sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    FrancSign = 0xE18F,

    /// <summary>
    /// The Font Awesome "frog" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["frog", "amphibian", "bullfrog", "fauna", "hop", "kermit", "kiss", "prince", "ribbit", "toad", "wart"])]
    [FontAwesomeCategories(["Animals", "Camping", "Nature", "Science"])]
    Frog = 0xF52E,

    /// <summary>
    /// The Font Awesome "face-frown" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face frown", "disapprove", "emoticon", "face", "frown", "frowning face", "rating", "sad", "uer"])]
    [FontAwesomeCategories(["Communication", "Emoji", "Users + People"])]
    Frown = 0xF119,

    /// <summary>
    /// The Font Awesome "face-frown-open" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face frown open", "disapprove", "emoticon", "face", "frown", "frowning face with open mouth", "mouth", "open", "rating", "sad"])]
    [FontAwesomeCategories(["Emoji"])]
    FrownOpen = 0xF57A,

    /// <summary>
    /// The Font Awesome "filter-circle-dollar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["filter circle dollar", "filter", "money", "options", "premium", "separate", "sort"])]
    [FontAwesomeCategories(["Marketing"])]
    FunnelDollar = 0xF662,

    /// <summary>
    /// The Font Awesome "futbol" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["futbol", "ball", "football", "mls", "soccer", "soccer ball"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    Futbol = 0xF1E3,

    /// <summary>
    /// The Font Awesome "gamepad" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gamepad", "arcade", "controller", "d-pad", "joystick", "playstore", "video", "video game"])]
    [FontAwesomeCategories(["Childhood", "Devices + Hardware", "Gaming", "Maps"])]
    Gamepad = 0xF11B,

    /// <summary>
    /// The Font Awesome "gas-pump" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gas pump", "car", "diesel", "fuel", "fuel pump", "fuelpump", "gas", "gasoline", "petrol", "pump", "station"])]
    [FontAwesomeCategories(["Automotive", "Energy", "Humanitarian", "Logistics"])]
    GasPump = 0xF52F,

    /// <summary>
    /// The Font Awesome "gauge" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gauge", "dashboard", "fast", "odometer", "speed", "speedometer"])]
    [FontAwesomeCategories(["Automotive"])]
    Gauge = 0xF624,

    /// <summary>
    /// The Font Awesome "gauge-simple" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gauge simple", "dashboard", "fast", "odometer", "speed", "speedometer"])]
    [FontAwesomeCategories(["Automotive"])]
    GaugeSimple = 0xF629,

    /// <summary>
    /// The Font Awesome "gauge-simple-high" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gauge simple high", "dashboard", "fast", "odometer", "quick", "speed", "speedometer"])]
    [FontAwesomeCategories(["Automotive"])]
    GaugeSimpleHigh = 0xF62A,

    /// <summary>
    /// The Font Awesome "gavel" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gavel", "hammer", "judge", "law", "lawyer", "opinion"])]
    [FontAwesomeCategories(["Maps"])]
    Gavel = 0xF0E3,

    /// <summary>
    /// The Font Awesome "gem" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["diamond", "gem", "gem stone", "jewel", "jewelry", "sapphire", "stone", "treasure"])]
    [FontAwesomeCategories(["Shopping"])]
    Gem = 0xF3A5,

    /// <summary>
    /// The Font Awesome "genderless" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["genderless", "androgynous", "asexual", "gender", "sexless"])]
    [FontAwesomeCategories(["Genders"])]
    Genderless = 0xF22D,

    /// <summary>
    /// The Font Awesome "ghost" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["apparition", "blinky", "clyde", "creature", "face", "fairy tale", "fantasy", "floating", "ghost", "halloween", "holiday", "inky", "monster", "pacman", "pinky", "spirit"])]
    [FontAwesomeCategories(["Gaming", "Halloween"])]
    Ghost = 0xF6E2,

    /// <summary>
    /// The Font Awesome "gift" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["box", "celebration", "christmas", "generosity", "gift", "giving", "holiday", "party", "present", "wrapped", "wrapped gift", "xmas"])]
    [FontAwesomeCategories(["Charity", "Holidays", "Maps", "Shopping"])]
    Gift = 0xF06B,

    /// <summary>
    /// The Font Awesome "gifts" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gifts", "christmas", "generosity", "giving", "holiday", "party", "present", "wrapped", "xmas"])]
    [FontAwesomeCategories(["Holidays", "Shopping"])]
    Gifts = 0xF79C,

    /// <summary>
    /// The Font Awesome "champagne-glasses" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["champagne glasses", "alcohol", "bar", "beverage", "celebrate", "celebration", "champagne", "clink", "clinking glasses", "drink", "glass", "holiday", "new year's eve", "party", "toast"])]
    [FontAwesomeCategories(["Food + Beverage", "Holidays"])]
    GlassCheers = 0xF79F,

    /// <summary>
    /// The Font Awesome "glasses" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["glasses", "hipster", "nerd", "reading", "sight", "spectacles", "vision"])]
    [FontAwesomeCategories(["Business", "Clothing + Fashion"])]
    Glasses = 0xF530,

    /// <summary>
    /// The Font Awesome "martini-glass-empty" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["martini glass empty", "alcohol", "bar", "beverage", "drink", "liquor"])]
    [FontAwesomeCategories(["Food + Beverage", "Maps", "Travel + Hotel"])]
    GlassMartini = 0xF000,

    /// <summary>
    /// The Font Awesome "martini-glass" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["martini glass", "alcohol", "bar", "beverage", "cocktail", "cocktail glass", "drink", "glass", "liquor"])]
    [FontAwesomeCategories(["Food + Beverage", "Travel + Hotel"])]
    GlassMartiniAlt = 0xF57B,

    /// <summary>
    /// The Font Awesome "glass-water" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["glass water", "potable", "water"])]
    [FontAwesomeCategories(["Food + Beverage", "Humanitarian"])]
    GlassWater = 0xE4F4,

    /// <summary>
    /// The Font Awesome "glass-water-droplet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["glass water droplet", "potable", "water"])]
    [FontAwesomeCategories(["Food + Beverage", "Humanitarian"])]
    GlassWaterDroplet = 0xE4F5,

    /// <summary>
    /// The Font Awesome "whiskey-glass" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["whiskey glass", "alcohol", "bar", "beverage", "bourbon", "drink", "glass", "liquor", "neat", "rye", "scotch", "shot", "tumbler", "tumbler glass", "whisky"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    GlassWhiskey = 0xF7A0,

    /// <summary>
    /// The Font Awesome "globe" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["all", "coordinates", "country", "earth", "global", "globe", "globe with meridians", "gps", "internet", "language", "localize", "location", "map", "meridians", "network", "online", "place", "planet", "translate", "travel", "world", "www"])]
    [FontAwesomeCategories(["Astronomy", "Business", "Charity", "Connectivity", "Maps"])]
    Globe = 0xF0AC,

    /// <summary>
    /// The Font Awesome "earth-africa" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["earth africa", "africa", "all", "country", "earth", "europe", "global", "globe", "gps", "language", "localize", "location", "map", "online", "place", "planet", "translate", "travel", "world"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    GlobeAfrica = 0xF57C,

    /// <summary>
    /// The Font Awesome "earth-americas" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["earth americas", "all", "america", "country", "earth", "global", "globe", "gps", "language", "localize", "location", "map", "online", "place", "planet", "translate", "travel", "world"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    GlobeAmericas = 0xF57D,

    /// <summary>
    /// The Font Awesome "earth-asia" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["earth asia", "all", "asia", "australia", "country", "earth", "global", "globe", "gps", "language", "localize", "location", "map", "online", "place", "planet", "translate", "travel", "world"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    GlobeAsia = 0xF57E,

    /// <summary>
    /// The Font Awesome "earth-europe" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["earth europe", "all", "country", "earth", "europe", "global", "globe", "gps", "language", "localize", "location", "map", "online", "place", "planet", "translate", "travel", "world"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    GlobeEurope = 0xF7A2,

    /// <summary>
    /// The Font Awesome "golf-ball-tee" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["golf ball tee", "caddy", "eagle", "putt", "tee"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    GolfBall = 0xF450,

    /// <summary>
    /// The Font Awesome "gopuram" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gopuram", "building", "entrance", "hinduism", "temple", "tower"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Religion"])]
    Gopuram = 0xF664,

    /// <summary>
    /// The Font Awesome "graduation-cap" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["graduation cap", "cap", "celebration", "ceremony", "clothing", "college", "graduate", "graduation", "graduation cap", "hat", "learning", "school", "student"])]
    [FontAwesomeCategories(["Clothing + Fashion", "Education", "Maps"])]
    GraduationCap = 0xF19D,

    /// <summary>
    /// The Font Awesome "greater-than" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x3E.
    /// </summary>
    [FontAwesomeSearchTerms(["greater than", "greater-than sign", "arithmetic", "compare", "math"])]
    [FontAwesomeCategories(["Mathematics", "Punctuation + Symbols"])]
    GreaterThan = 0xF531,

    /// <summary>
    /// The Font Awesome "greater-than-equal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["greater than equal", "arithmetic", "compare", "math"])]
    [FontAwesomeCategories(["Mathematics"])]
    GreaterThanEqual = 0xF532,

    /// <summary>
    /// The Font Awesome "face-grimace" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grimace", "cringe", "emoticon", "face", "grimace", "grimacing face", "teeth"])]
    [FontAwesomeCategories(["Emoji"])]
    Grimace = 0xF57F,

    /// <summary>
    /// The Font Awesome "face-grin" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin", "emoticon", "face", "grin", "grinning face", "laugh", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    Grin = 0xF580,

    /// <summary>
    /// The Font Awesome "face-grin-wide" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin wide", "emoticon", "face", "grinning face with big eyes", "laugh", "mouth", "open", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinAlt = 0xF581,

    /// <summary>
    /// The Font Awesome "face-grin-beam" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin beam", "emoticon", "eye", "face", "grinning face with smiling eyes", "laugh", "mouth", "open", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinBeam = 0xF582,

    /// <summary>
    /// The Font Awesome "face-grin-beam-sweat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin beam sweat", "cold", "embarass", "emoticon", "face", "grinning face with sweat", "open", "smile", "sweat"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinBeamSweat = 0xF583,

    /// <summary>
    /// The Font Awesome "face-grin-hearts" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin hearts", "emoticon", "eye", "face", "love", "smile", "smiling face with heart-eyes"])]
    [FontAwesomeCategories(["Emoji", "Holidays"])]
    GrinHearts = 0xF584,

    /// <summary>
    /// The Font Awesome "face-grin-squint" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin squint", "emoticon", "face", "grinning squinting face", "laugh", "mouth", "satisfied", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinSquint = 0xF585,

    /// <summary>
    /// The Font Awesome "face-grin-squint-tears" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin squint tears", "emoticon", "face", "floor", "happy", "laugh", "rolling", "rolling on the floor laughing", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinSquintTears = 0xF586,

    /// <summary>
    /// The Font Awesome "face-grin-stars" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin stars", "emoticon", "eyes", "face", "grinning", "quality", "star", "star-struck", "starry-eyed", "vip"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinStars = 0xF587,

    /// <summary>
    /// The Font Awesome "face-grin-tears" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin tears", "lol", "emoticon", "face", "face with tears of joy", "joy", "laugh", "tear"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinTears = 0xF588,

    /// <summary>
    /// The Font Awesome "face-grin-tongue" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin tongue", "lol", "emoticon", "face", "face with tongue", "tongue"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinTongue = 0xF589,

    /// <summary>
    /// The Font Awesome "face-grin-tongue-squint" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin tongue squint", "lol", "emoticon", "eye", "face", "horrible", "squinting face with tongue", "taste", "tongue"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinTongueSquint = 0xF58A,

    /// <summary>
    /// The Font Awesome "face-grin-tongue-wink" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin tongue wink", "lol", "emoticon", "eye", "face", "joke", "tongue", "wink", "winking face with tongue"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinTongueWink = 0xF58B,

    /// <summary>
    /// The Font Awesome "face-grin-wink" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face grin wink", "emoticon", "face", "flirt", "laugh", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    GrinWink = 0xF58C,

    /// <summary>
    /// The Font Awesome "grip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["grip", "affordance", "app", "collection", "dashboard", "drag", "drop", "grab", "grid", "handle", "launcher", "square"])]
    [FontAwesomeCategories(["Editing"])]
    GripHorizontal = 0xF58D,

    /// <summary>
    /// The Font Awesome "grip-lines" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["grip lines", "affordance", "drag", "drop", "grab", "handle"])]
    [FontAwesomeCategories(["Editing"])]
    GripLines = 0xF7A4,

    /// <summary>
    /// The Font Awesome "grip-lines-vertical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["grip lines vertical", "affordance", "drag", "drop", "grab", "handle"])]
    [FontAwesomeCategories(["Editing"])]
    GripLinesVertical = 0xF7A5,

    /// <summary>
    /// The Font Awesome "grip-vertical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["grip vertical", "affordance", "drag", "drop", "grab", "handle"])]
    [FontAwesomeCategories(["Editing"])]
    GripVertical = 0xF58E,

    /// <summary>
    /// The Font Awesome "group-arrows-rotate" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["group arrows rotate", "community", "engagement", "spin", "sync"])]
    [FontAwesomeCategories(["Humanitarian", "Marketing"])]
    GroupArrowsRotate = 0xE4F6,

    /// <summary>
    /// The Font Awesome "guarani-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["guarani sign", "guarani sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    GuaraniSign = 0xE19A,

    /// <summary>
    /// The Font Awesome "guitar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["guitar", "acoustic", "instrument", "music", "rock", "rock and roll", "song", "strings"])]
    [FontAwesomeCategories(["Music + Audio"])]
    Guitar = 0xF7A6,

    /// <summary>
    /// The Font Awesome "gun" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gun", "firearm", "pistol", "weapon"])]
    [FontAwesomeCategories(["Security"])]
    Gun = 0xE19B,

    /// <summary>
    /// The Font Awesome "burger" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bacon", "beef", "burger", "burger king", "cheeseburger", "fast food", "grill", "ground beef", "mcdonalds", "sandwich"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    Hamburger = 0xF805,

    /// <summary>
    /// The Font Awesome "hammer" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["admin", "configuration", "equipment", "fix", "hammer", "maintenance", "modify", "recovery", "repair", "settings", "tool"])]
    [FontAwesomeCategories(["Construction", "Humanitarian"])]
    Hammer = 0xF6E3,

    /// <summary>
    /// The Font Awesome "hamsa" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hamsa", "amulet", "christianity", "islam", "jewish", "judaism", "muslim", "protection"])]
    [FontAwesomeCategories(["Religion"])]
    Hamsa = 0xF665,

    /// <summary>
    /// The Font Awesome "handcuffs" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrest", "criminal", "handcuffs", "jail", "lock", "police", "wrist"])]
    [FontAwesomeCategories(["Humanitarian", "Security"])]
    Handcuffs = 0xE4F8,

    /// <summary>
    /// The Font Awesome "hand-holding" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand holding", "carry", "lift"])]
    [FontAwesomeCategories(["Hands"])]
    HandHolding = 0xF4BD,

    /// <summary>
    /// The Font Awesome "hand-holding-droplet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand holding droplet", "blood", "carry", "covid-19", "drought", "grow", "lift", "sanitation"])]
    [FontAwesomeCategories(["Charity", "Hands", "Medical + Health"])]
    HandHoldingDroplet = 0xF4C1,

    /// <summary>
    /// The Font Awesome "hand-holding-hand" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand holding hand", "care", "give", "help", "hold", "protect"])]
    [FontAwesomeCategories(["Charity", "Hands", "Humanitarian"])]
    HandHoldingHand = 0xE4F7,

    /// <summary>
    /// The Font Awesome "hand-holding-heart" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand holding heart", "carry", "charity", "gift", "lift", "package", "wishlist"])]
    [FontAwesomeCategories(["Charity", "Hands"])]
    HandHoldingHeart = 0xF4BE,

    /// <summary>
    /// The Font Awesome "hand-holding-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand holding medical", "care", "covid-19", "donate", "help"])]
    [FontAwesomeCategories(["Hands", "Medical + Health"])]
    HandHoldingMedical = 0xE05C,

    /// <summary>
    /// The Font Awesome "hand-holding-dollar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand holding dollar", "$", "carry", "coupon", "dollar sign", "donate", "donation", "giving", "investment", "lift", "money", "premium", "price", "revenue", "salary"])]
    [FontAwesomeCategories(["Charity", "Hands", "Money"])]
    HandHoldingUsd = 0xF4C0,

    /// <summary>
    /// The Font Awesome "hand-lizard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand lizard", "game", "roshambo"])]
    [FontAwesomeCategories(["Hands"])]
    HandLizard = 0xF258,

    /// <summary>
    /// The Font Awesome "hand-middle-finger" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand middle finger", "finger", "flip the bird", "gesture", "hand", "hate", "middle finger", "rude"])]
    [FontAwesomeCategories(["Hands"])]
    HandMiddleFinger = 0xF806,

    /// <summary>
    /// The Font Awesome "hand" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand", "raised hand", "backhand", "game", "halt", "palm", "raised", "raised back of hand", "request", "roshambo", "stop"])]
    [FontAwesomeCategories(["Hands", "Media Playback"])]
    HandPaper = 0xF256,

    /// <summary>
    /// The Font Awesome "hand-peace" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand peace", "hand", "rest", "truce", "v", "victory", "victory hand"])]
    [FontAwesomeCategories(["Hands"])]
    HandPeace = 0xF25B,

    /// <summary>
    /// The Font Awesome "hand-point-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand point down", "finger", "hand-o-down", "point"])]
    [FontAwesomeCategories(["Hands"])]
    HandPointDown = 0xF0A7,

    /// <summary>
    /// The Font Awesome "hand-pointer" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand pointer", "arrow", "cursor", "select"])]
    [FontAwesomeCategories(["Hands"])]
    HandPointer = 0xF25A,

    /// <summary>
    /// The Font Awesome "hand-point-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand point left", "back", "finger", "hand-o-left", "left", "point", "previous"])]
    [FontAwesomeCategories(["Hands"])]
    HandPointLeft = 0xF0A5,

    /// <summary>
    /// The Font Awesome "hand-point-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand point right", "finger", "forward", "hand-o-right", "next", "point", "right"])]
    [FontAwesomeCategories(["Hands"])]
    HandPointRight = 0xF0A4,

    /// <summary>
    /// The Font Awesome "hand-point-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand point up", "finger", "hand", "hand-o-up", "index", "index pointing up", "point", "request", "up", "upgrade"])]
    [FontAwesomeCategories(["Hands"])]
    HandPointUp = 0xF0A6,

    /// <summary>
    /// The Font Awesome "hand-back-fist" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand back fist", "fist", "game", "roshambo"])]
    [FontAwesomeCategories(["Hands"])]
    HandRock = 0xF255,

    /// <summary>
    /// The Font Awesome "hands-holding" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hands holding", "carry", "hold", "lift"])]
    [FontAwesomeCategories(["Hands"])]
    Hands = 0xF4C2,

    /// <summary>
    /// The Font Awesome "hands-bound" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hands bound", "abduction", "bound", "handcuff", "wrist"])]
    [FontAwesomeCategories(["Hands", "Humanitarian", "Security"])]
    HandsBound = 0xE4F9,

    /// <summary>
    /// The Font Awesome "hands-bubbles" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hands bubbles", "covid-19", "hygiene", "soap", "wash"])]
    [FontAwesomeCategories(["Hands", "Humanitarian"])]
    HandsBubbles = 0xE05E,

    /// <summary>
    /// The Font Awesome "hand-scissors" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand scissors", "cut", "game", "roshambo"])]
    [FontAwesomeCategories(["Hands"])]
    HandScissors = 0xF257,

    /// <summary>
    /// The Font Awesome "hands-clapping" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hands clapping", "applause", "clap", "clapping hands", "hand"])]
    [FontAwesomeCategories(["Hands"])]
    HandsClapping = 0xE1A8,

    /// <summary>
    /// The Font Awesome "handshake" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["handshake", "agreement", "greeting", "meeting", "partnership"])]
    [FontAwesomeCategories(["Charity", "Hands", "Humanitarian", "Political", "Shopping"])]
    Handshake = 0xF2B5,

    /// <summary>
    /// The Font Awesome "handshake" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF2B5.
    /// </summary>
    [FontAwesomeSearchTerms(["handshake", "agreement", "greeting", "meeting", "partnership"])]
    [FontAwesomeCategories(["Charity", "Hands", "Humanitarian", "Political", "Shopping"])]
    HandshakeSimple = 0xF4C6,

    /// <summary>
    /// The Font Awesome "handshake-slash" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xE060.
    /// </summary>
    [FontAwesomeSearchTerms(["handshake slash", "broken", "covid-19", "disabled", "social distance"])]
    [FontAwesomeCategories(["Hands"])]
    HandshakeSimpleSlash = 0xE05F,

    /// <summary>
    /// The Font Awesome "handshake-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["handshake slash", "broken", "covid-19", "disabled", "social distance"])]
    [FontAwesomeCategories(["Hands"])]
    HandshakeSlash = 0xE060,

    /// <summary>
    /// The Font Awesome "handshake-angle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["handshake angle", "aid", "assistance", "handshake", "partnership", "volunteering"])]
    [FontAwesomeCategories(["Accessibility", "Charity", "Hands"])]
    HandsHelping = 0xF4C4,

    /// <summary>
    /// The Font Awesome "hands-holding-child" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hands holding child", "care", "give", "help", "hold", "parent", "protect"])]
    [FontAwesomeCategories(["Charity", "Childhood", "Hands", "Humanitarian", "Security"])]
    HandsHoldingChild = 0xE4FA,

    /// <summary>
    /// The Font Awesome "hands-holding-circle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hands holding circle", "circle", "gift", "protection"])]
    [FontAwesomeCategories(["Charity", "Hands", "Humanitarian", "Security"])]
    HandsHoldingCircle = 0xE4FB,

    /// <summary>
    /// The Font Awesome "hand-sparkles" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand sparkles", "clean", "covid-19", "hygiene", "magic", "palm", "soap", "wash"])]
    [FontAwesomeCategories(["Hands"])]
    HandSparkles = 0xE05D,

    /// <summary>
    /// The Font Awesome "hand-spock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hand spock", "finger", "hand", "live long", "palm", "prosper", "salute", "spock", "star trek", "vulcan", "vulcan salute"])]
    [FontAwesomeCategories(["Hands", "Science Fiction"])]
    HandSpock = 0xF259,

    /// <summary>
    /// The Font Awesome "hanukiah" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hanukiah", "candelabrum", "candle", "candlestick", "hanukkah", "jewish", "judaism", "light", "menorah", "religion"])]
    [FontAwesomeCategories(["Religion"])]
    Hanukiah = 0xF6E6,

    /// <summary>
    /// The Font Awesome "helmet-safety" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["helmet safety", "construction", "hardhat", "helmet", "maintenance", "safety"])]
    [FontAwesomeCategories(["Construction", "Logistics"])]
    HardHat = 0xF807,

    /// <summary>
    /// The Font Awesome "hashtag" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x23.
    /// </summary>
    [FontAwesomeSearchTerms(["hashtag", "number sign", "twitter", "instagram", "pound", "social media", "tag"])]
    [FontAwesomeCategories(["Punctuation + Symbols", "Social"])]
    Hashtag = 0xF292,

    /// <summary>
    /// The Font Awesome "hat-cowboy" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hat cowboy", "buckaroo", "horse", "jackeroo", "john b.", "old west", "pardner", "ranch", "rancher", "rodeo", "western", "wrangler"])]
    [FontAwesomeCategories(["Clothing + Fashion"])]
    HatCowboy = 0xF8C0,

    /// <summary>
    /// The Font Awesome "hat-cowboy-side" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hat cowboy side", "buckaroo", "horse", "jackeroo", "john b.", "old west", "pardner", "ranch", "rancher", "rodeo", "western", "wrangler"])]
    [FontAwesomeCategories(["Clothing + Fashion"])]
    HatCowboySide = 0xF8C1,

    /// <summary>
    /// The Font Awesome "hat-wizard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hat wizard", "dungeons & dragons", "accessory", "buckle", "clothing", "d&d", "dnd", "fantasy", "halloween", "head", "holiday", "mage", "magic", "pointy", "witch"])]
    [FontAwesomeCategories(["Clothing + Fashion", "Gaming", "Halloween"])]
    HatWizard = 0xF6E8,

    /// <summary>
    /// The Font Awesome "hard-drive" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hard drive", "hard disk", "cpu", "hard drive", "harddrive", "machine", "save", "storage"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    Hdd = 0xF0A0,

    /// <summary>
    /// The Font Awesome "heading" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heading", "format", "header", "text", "title"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Heading = 0xF1DC,

    /// <summary>
    /// The Font Awesome "headphones" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["headphones", "audio", "earbud", "headphone", "listen", "music", "sound", "speaker"])]
    [FontAwesomeCategories(["Devices + Hardware", "Film + Video", "Music + Audio"])]
    Headphones = 0xF025,

    /// <summary>
    /// The Font Awesome "headphones" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF025.
    /// </summary>
    [FontAwesomeSearchTerms(["headphones", "audio", "earbud", "headphone", "listen", "music", "sound", "speaker"])]
    [FontAwesomeCategories(["Devices + Hardware", "Film + Video", "Music + Audio"])]
    HeadphonesAlt = 0xF58F,

    /// <summary>
    /// The Font Awesome "headset" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["headset", "audio", "gamer", "gaming", "listen", "live chat", "microphone", "shot caller", "sound", "support", "telemarketer"])]
    [FontAwesomeCategories(["Gaming", "Humanitarian"])]
    Headset = 0xF590,

    /// <summary>
    /// The Font Awesome "head-side-cough" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["head side cough", "cough", "covid-19", "germs", "lungs", "respiratory", "sick", "uer"])]
    [FontAwesomeCategories(["Medical + Health", "Users + People"])]
    HeadSideCough = 0xE061,

    /// <summary>
    /// The Font Awesome "head-side-cough-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["head side cough slash", "cough", "covid-19", "disabled", "germs", "lungs", "respiratory", "sick", "uer"])]
    [FontAwesomeCategories(["Medical + Health", "Users + People"])]
    HeadSideCoughSlash = 0xE062,

    /// <summary>
    /// The Font Awesome "head-side-mask" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["head side mask", "breath", "coronavirus", "covid-19", "filter", "flu", "infection", "pandemic", "respirator", "uer", "virus"])]
    [FontAwesomeCategories(["Medical + Health", "Users + People"])]
    HeadSideMask = 0xE063,

    /// <summary>
    /// The Font Awesome "head-side-virus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["head side virus", "cold", "coronavirus", "covid-19", "flu", "infection", "pandemic", "sick", "uer"])]
    [FontAwesomeCategories(["Medical + Health", "Users + People"])]
    HeadSideVirus = 0xE064,

    /// <summary>
    /// The Font Awesome "heart" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ace", "card", "favorite", "game", "heart", "heart suit", "like", "love", "relationship", "valentine", "wishlist"])]
    [FontAwesomeCategories(["Charity", "Gaming", "Holidays", "Maps", "Medical + Health", "Shapes", "Shopping", "Social", "Sports + Fitness"])]
    Heart = 0xF004,

    /// <summary>
    /// The Font Awesome "heart-pulse" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heart pulse", "ekg", "electrocardiogram", "health", "lifeline", "vital signs"])]
    [FontAwesomeCategories(["Maps", "Medical + Health", "Sports + Fitness"])]
    Heartbeat = 0xF21E,

    /// <summary>
    /// The Font Awesome "heart-crack" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heart crack", "break", "breakup", "broken", "broken heart", "crushed", "dislike", "dumped", "grief", "love", "lovesick", "relationship", "sad"])]
    [FontAwesomeCategories(["Shapes"])]
    HeartBroken = 0xF7A9,

    /// <summary>
    /// The Font Awesome "heart-circle-bolt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heart circle bolt", "cardiogram", "ekg", "electric", "heart", "love", "pacemaker"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    HeartCircleBolt = 0xE4FC,

    /// <summary>
    /// The Font Awesome "heart-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heart circle check", "enable", "favorite", "heart", "love", "not affected", "ok", "okay", "validate", "working"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    HeartCircleCheck = 0xE4FD,

    /// <summary>
    /// The Font Awesome "heart-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heart circle exclamation", "failed", "favorite", "heart", "love"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    HeartCircleExclamation = 0xE4FE,

    /// <summary>
    /// The Font Awesome "heart-circle-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heart circle minus", "favorite", "heart", "love"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    HeartCircleMinus = 0xE4FF,

    /// <summary>
    /// The Font Awesome "heart-circle-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heart circle plus", "favorite", "heart", "love"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    HeartCirclePlus = 0xE500,

    /// <summary>
    /// The Font Awesome "heart-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heart circle xmark", "favorite", "heart", "love", "uncheck"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    HeartCircleXmark = 0xE501,

    /// <summary>
    /// The Font Awesome "helicopter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["airwolf", "apache", "chopper", "flight", "fly", "helicopter", "travel", "vehicle"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maps", "Transportation"])]
    Helicopter = 0xF533,

    /// <summary>
    /// The Font Awesome "helicopter-symbol" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["helicopter symbol", "chopper", "helicopter", "landing pad", "whirlybird"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maps"])]
    HelicopterSymbol = 0xE502,

    /// <summary>
    /// The Font Awesome "helmet-un" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["helmet un", "helmet", "united nations"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian"])]
    HelmetUn = 0xE503,

    /// <summary>
    /// The Font Awesome "hexagon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hexagon", "horizontal black hexagon", "geometry", "honeycomb", "polygon", "shape"])]
    [FontAwesomeCategories(["Shapes"])]
    Hexagon = 0xF312,

    /// <summary>
    /// The Font Awesome "hexagon-nodes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hexagon nodes", "action", "ai", "artificial intelligence", "cluster", "graph", "language", "llm", "model", "network", "neuronal"])]
    [FontAwesomeCategories(["Charts + Diagrams", "Coding"])]
    HexagonNodes = 0xE699,

    /// <summary>
    /// The Font Awesome "hexagon-nodes-bolt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hexagon nodes bolt", "llm", "action", "ai", "artificial intelligence", "cluster", "graph", "language", "llm", "model", "network", "neuronal"])]
    [FontAwesomeCategories(["Charts + Diagrams", "Coding"])]
    HexagonNodesBolt = 0xE69A,

    /// <summary>
    /// The Font Awesome "highlighter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["highlighter", "edit", "marker", "modify", "sharpie", "update", "write"])]
    [FontAwesomeCategories(["Business", "Design", "Text Formatting"])]
    Highlighter = 0xF591,

    /// <summary>
    /// The Font Awesome "person-hiking" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person hiking", "autumn", "fall", "follow", "hike", "mountain", "outdoors", "summer", "uer", "walk"])]
    [FontAwesomeCategories(["Camping", "Nature", "Sports + Fitness", "Users + People"])]
    Hiking = 0xF6EC,

    /// <summary>
    /// The Font Awesome "hill-avalanche" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hill avalanche", "mudslide", "snow", "winter"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian"])]
    HillAvalanche = 0xE507,

    /// <summary>
    /// The Font Awesome "hill-rockslide" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hill rockslide", "mudslide"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian"])]
    HillRockslide = 0xE508,

    /// <summary>
    /// The Font Awesome "hippo" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["animal", "fauna", "hippo", "hippopotamus", "hungry", "mammal"])]
    [FontAwesomeCategories(["Animals"])]
    Hippo = 0xF6ED,

    /// <summary>
    /// The Font Awesome "clock-rotate-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clock rotate left", "rewind", "clock", "pending", "reverse", "time", "time machine", "time travel", "waiting"])]
    [FontAwesomeCategories(["Arrows", "Medical + Health"])]
    History = 0xF1DA,

    /// <summary>
    /// The Font Awesome "hockey-puck" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hockey puck", "ice", "nhl", "sport"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    HockeyPuck = 0xF453,

    /// <summary>
    /// The Font Awesome "holly-berry" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["holly berry", "catwoman", "christmas", "decoration", "flora", "halle", "holiday", "ororo munroe", "plant", "storm", "xmas"])]
    [FontAwesomeCategories(["Holidays"])]
    HollyBerry = 0xF7AA,

    /// <summary>
    /// The Font Awesome "house" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["abode", "building", "home", "house", "main", "residence"])]
    [FontAwesomeCategories(["Buildings", "Maps"])]
    Home = 0xF015,

    /// <summary>
    /// The Font Awesome "horse" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["equestrian", "equus", "fauna", "horse", "mammmal", "mare", "neigh", "pony", "racehorse", "racing"])]
    [FontAwesomeCategories(["Animals", "Transportation"])]
    Horse = 0xF6F0,

    /// <summary>
    /// The Font Awesome "horse-head" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["horse head", "equus", "fauna", "mammmal", "mare", "neigh", "pony"])]
    [FontAwesomeCategories(["Animals"])]
    HorseHead = 0xF7AB,

    /// <summary>
    /// The Font Awesome "hospital" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building", "covid-19", "doctor", "emergency room", "hospital", "medical center", "medicine"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Maps", "Medical + Health"])]
    Hospital = 0xF0F8,

    /// <summary>
    /// The Font Awesome "hospital" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF0F8.
    /// </summary>
    [FontAwesomeSearchTerms(["building", "covid-19", "doctor", "emergency room", "hospital", "medical center", "medicine"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Maps", "Medical + Health"])]
    HospitalAlt = 0xF47D,

    /// <summary>
    /// The Font Awesome "circle-h" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle h", "circled latin capital letter h", "clinic", "covid-19", "emergency", "letter", "map"])]
    [FontAwesomeCategories(["Alphabet", "Humanitarian", "Medical + Health"])]
    HospitalSymbol = 0xF47E,

    /// <summary>
    /// The Font Awesome "hospital-user" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hospital user", "covid-19", "doctor", "network", "patient", "primary care", "uer"])]
    [FontAwesomeCategories(["Buildings", "Medical + Health", "Users + People"])]
    HospitalUser = 0xF80D,

    /// <summary>
    /// The Font Awesome "hotdog" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bun", "chili", "frankfurt", "frankfurter", "hot dog", "hotdog", "kosher", "polish", "sandwich", "sausage", "vienna", "weiner"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    Hotdog = 0xF80F,

    /// <summary>
    /// The Font Awesome "hotel" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building", "hotel", "inn", "lodging", "motel", "resort", "travel"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Travel + Hotel"])]
    Hotel = 0xF594,

    /// <summary>
    /// The Font Awesome "hot-tub-person" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hot tub person", "jacuzzi", "spa", "uer"])]
    [FontAwesomeCategories(["Travel + Hotel", "Users + People"])]
    HotTub = 0xF593,

    /// <summary>
    /// The Font Awesome "hourglass" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hour", "hourglass", "hourglass not done", "minute", "sand", "stopwatch", "time", "timer"])]
    [FontAwesomeCategories(["Time"])]
    Hourglass = 0xF254,

    /// <summary>
    /// The Font Awesome "hourglass-end" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hourglass end", "hour", "hourglass done", "minute", "pending", "sand", "stopwatch", "time", "timer", "waiting"])]
    [FontAwesomeCategories(["Time"])]
    HourglassEnd = 0xF253,

    /// <summary>
    /// The Font Awesome "hourglass-half" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hourglass half", "hour", "minute", "pending", "sand", "stopwatch", "time", "waiting"])]
    [FontAwesomeCategories(["Time"])]
    HourglassHalf = 0xF252,

    /// <summary>
    /// The Font Awesome "hourglass-start" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hourglass start", "hour", "minute", "sand", "stopwatch", "time", "waiting"])]
    [FontAwesomeCategories(["Time"])]
    HourglassStart = 0xF251,

    /// <summary>
    /// The Font Awesome "house-chimney" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house chimney", "abode", "building", "chimney", "house", "main", "residence", "smokestack"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Moving"])]
    HouseChimney = 0xE3AF,

    /// <summary>
    /// The Font Awesome "house-chimney-user" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house chimney user", "covid-19", "home", "isolation", "quarantine", "uer"])]
    [FontAwesomeCategories(["Household", "Users + People"])]
    HouseChimneyUser = 0xE065,

    /// <summary>
    /// The Font Awesome "house-chimney-window" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house chimney window", "abode", "building", "family", "home", "residence"])]
    [FontAwesomeCategories(["Buildings", "Household"])]
    HouseChimneyWindow = 0xE00D,

    /// <summary>
    /// The Font Awesome "house-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house circle check", "abode", "enable", "home", "house", "not affected", "ok", "okay", "validate", "working"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    HouseCircleCheck = 0xE509,

    /// <summary>
    /// The Font Awesome "house-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house circle exclamation", "abode", "affected", "failed", "home", "house"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    HouseCircleExclamation = 0xE50A,

    /// <summary>
    /// The Font Awesome "house-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house circle xmark", "abode", "destroy", "home", "house", "uncheck"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    HouseCircleXmark = 0xE50B,

    /// <summary>
    /// The Font Awesome "house-crack" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house crack", "building", "devastation", "disaster", "earthquake", "home", "insurance"])]
    [FontAwesomeCategories(["Buildings", "Disaster + Crisis"])]
    HouseCrack = 0xE3B1,

    /// <summary>
    /// The Font Awesome "house-chimney-crack" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house chimney crack", "building", "devastation", "disaster", "earthquake", "home", "insurance"])]
    [FontAwesomeCategories(["Buildings", "Disaster + Crisis", "Humanitarian"])]
    HouseDamage = 0xF6F1,

    /// <summary>
    /// The Font Awesome "house-fire" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house fire", "burn", "emergency", "home"])]
    [FontAwesomeCategories(["Buildings", "Disaster + Crisis", "Household", "Humanitarian", "Security"])]
    HouseFire = 0xE50C,

    /// <summary>
    /// The Font Awesome "house-flag" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house flag", "camp", "home"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian"])]
    HouseFlag = 0xE50D,

    /// <summary>
    /// The Font Awesome "house-flood-water" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house flood water", "damage", "flood", "water"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian"])]
    HouseFloodWater = 0xE50E,

    /// <summary>
    /// The Font Awesome "house-flood-water-circle-arrow-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house flood water circle arrow right", "damage", "flood", "water"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian"])]
    HouseFloodWaterCircleArrowRight = 0xE50F,

    /// <summary>
    /// The Font Awesome "house-laptop" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house laptop", "computer", "covid-19", "device", "office", "remote", "work from home"])]
    [FontAwesomeCategories(["Business", "Devices + Hardware", "Household"])]
    HouseLaptop = 0xE066,

    /// <summary>
    /// The Font Awesome "house-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house lock", "closed", "home", "house", "lockdown", "padlock", "privacy", "quarantine"])]
    [FontAwesomeCategories(["Buildings", "Household", "Humanitarian", "Security"])]
    HouseLock = 0xE510,

    /// <summary>
    /// The Font Awesome "house-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house medical", "covid-19", "doctor", "facility", "general practitioner", "health", "hospital", "infirmary", "medicine", "office", "outpatient"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Medical + Health"])]
    HouseMedical = 0xE3B2,

    /// <summary>
    /// The Font Awesome "house-medical-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house medical circle check", "clinic", "enable", "hospital", "not affected", "ok", "okay", "validate", "working"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Medical + Health"])]
    HouseMedicalCircleCheck = 0xE511,

    /// <summary>
    /// The Font Awesome "house-medical-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house medical circle exclamation", "affected", "clinic", "failed", "hospital"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Medical + Health"])]
    HouseMedicalCircleExclamation = 0xE512,

    /// <summary>
    /// The Font Awesome "house-medical-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house medical circle xmark", "clinic", "destroy", "hospital", "uncheck"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Medical + Health"])]
    HouseMedicalCircleXmark = 0xE513,

    /// <summary>
    /// The Font Awesome "house-medical-flag" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house medical flag", "clinic", "hospital", "mash"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Medical + Health"])]
    HouseMedicalFlag = 0xE514,

    /// <summary>
    /// The Font Awesome "house-signal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house signal", "abode", "building", "connect", "family", "home", "residence", "smart home", "wifi", "www"])]
    [FontAwesomeCategories(["Connectivity", "Household", "Humanitarian"])]
    HouseSignal = 0xE012,

    /// <summary>
    /// The Font Awesome "house-tsunami" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house tsunami", "damage", "flood", "tidal wave", "wave"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Weather"])]
    HouseTsunami = 0xE515,

    /// <summary>
    /// The Font Awesome "house-user" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["house user", "house", "uer"])]
    [FontAwesomeCategories(["Household", "Users + People"])]
    HouseUser = 0xE1B0,

    /// <summary>
    /// The Font Awesome "hryvnia-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hryvnia sign", "hryvnia sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    Hryvnia = 0xF6F2,

    /// <summary>
    /// The Font Awesome "square-h" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square h", "directions", "emergency", "hospital", "hotel", "letter", "map"])]
    [FontAwesomeCategories(["Alphabet", "Maps", "Medical + Health"])]
    HSquare = 0xF0FD,

    /// <summary>
    /// The Font Awesome "hurricane" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hurricane", "coriolis effect", "eye", "storm", "tropical cyclone", "typhoon"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Spinners", "Weather"])]
    Hurricane = 0xF751,

    /// <summary>
    /// The Font Awesome "ice-cream" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ice cream", "chocolate", "cone", "cream", "dessert", "frozen", "ice", "ice cream", "scoop", "sorbet", "sweet", "vanilla", "yogurt"])]
    [FontAwesomeCategories(["Childhood", "Food + Beverage"])]
    IceCream = 0xF810,

    /// <summary>
    /// The Font Awesome "icicles" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["icicles", "cold", "frozen", "hanging", "ice", "seasonal", "sharp"])]
    [FontAwesomeCategories(["Nature", "Weather"])]
    Icicles = 0xF7AD,

    /// <summary>
    /// The Font Awesome "icons" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["icons", "bolt", "category", "emoji", "heart", "image", "music", "photo", "symbols"])]
    [FontAwesomeCategories(["Communication", "Design", "Social", "Text Formatting"])]
    Icons = 0xF86D,

    /// <summary>
    /// The Font Awesome "i-cursor" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["i cursor", "editing", "i-beam", "type", "writing"])]
    [FontAwesomeCategories(["Text Formatting"])]
    ICursor = 0xF246,

    /// <summary>
    /// The Font Awesome "id-badge" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["id badge", "address", "contact", "identification", "license", "profile", "uer", "username"])]
    [FontAwesomeCategories(["Photos + Images", "Security", "Users + People"])]
    IdBadge = 0xF2C1,

    /// <summary>
    /// The Font Awesome "id-card" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["id card", "contact", "demographics", "document", "identification", "issued", "profile", "registration", "uer", "username"])]
    [FontAwesomeCategories(["Humanitarian", "Photos + Images", "Security", "Users + People"])]
    IdCard = 0xF2C2,

    /// <summary>
    /// The Font Awesome "id-card-clip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["id card clip", "contact", "demographics", "document", "identification", "issued", "profile", "uer", "username"])]
    [FontAwesomeCategories(["Medical + Health", "Security", "Users + People"])]
    IdCardAlt = 0xF47F,

    /// <summary>
    /// The Font Awesome "igloo" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["igloo", "dome", "dwelling", "eskimo", "home", "house", "ice", "snow"])]
    [FontAwesomeCategories(["Buildings"])]
    Igloo = 0xF7AE,

    /// <summary>
    /// The Font Awesome "image" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["image", "album", "img", "landscape", "photo", "picture"])]
    [FontAwesomeCategories(["Maps", "Photos + Images", "Social"])]
    Image = 0xF03E,

    /// <summary>
    /// The Font Awesome "images" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["images", "album", "img", "landscape", "photo", "picture"])]
    [FontAwesomeCategories(["Maps", "Photos + Images", "Social"])]
    Images = 0xF302,

    /// <summary>
    /// The Font Awesome "inbox" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["inbox", "archive", "desk", "email", "mail", "message"])]
    [FontAwesomeCategories(["Communication"])]
    Inbox = 0xF01C,

    /// <summary>
    /// The Font Awesome "indent" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["indent", "align", "justify", "paragraph", "tab"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Indent = 0xF03C,

    /// <summary>
    /// The Font Awesome "indian-rupee-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["indian rupee sign", "indian rupee sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    IndianRupeeSign = 0xE1BC,

    /// <summary>
    /// The Font Awesome "industry" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["industry", "building", "factory", "industrial", "manufacturing", "mill", "warehouse"])]
    [FontAwesomeCategories(["Buildings", "Business", "Energy", "Maps"])]
    Industry = 0xF275,

    /// <summary>
    /// The Font Awesome "infinity" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["infinity", "eternity", "forever", "infinity", "math", "unbounded", "universal"])]
    [FontAwesomeCategories(["Mathematics", "Travel + Hotel"])]
    Infinity = 0xF534,

    /// <summary>
    /// The Font Awesome "info" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["info", "details", "help", "information", "more", "support"])]
    [FontAwesomeCategories(["Maps"])]
    Info = 0xF129,

    /// <summary>
    /// The Font Awesome "circle-info" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle info", "details", "help", "information", "more", "support"])]
    [FontAwesomeCategories(["Accessibility", "Maps"])]
    InfoCircle = 0xF05A,

    /// <summary>
    /// The Font Awesome "instagramsquare" icon unicode character.
    /// </summary>
    [Obsolete]
    InstagramSquare = 0xF955,

    /// <summary>
    /// The Font Awesome "italic" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["italic", "edit", "emphasis", "font", "format", "text", "type"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Italic = 0xF033,

    /// <summary>
    /// The Font Awesome "jar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["jar", "jam", "jelly", "storage"])]
    [FontAwesomeCategories(["Food + Beverage", "Household", "Humanitarian"])]
    Jar = 0xE516,

    /// <summary>
    /// The Font Awesome "jar-wheat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["jar wheat", "flour", "storage"])]
    [FontAwesomeCategories(["Food + Beverage", "Household", "Humanitarian"])]
    JarWheat = 0xE517,

    /// <summary>
    /// The Font Awesome "jedi" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["jedi", "crest", "force", "sith", "skywalker", "star wars", "yoda"])]
    [FontAwesomeCategories(["Religion", "Science Fiction"])]
    Jedi = 0xF669,

    /// <summary>
    /// The Font Awesome "jet-fighter-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["jet fighter up", "airforce", "airplane", "airport", "fast", "fly", "goose", "marines", "maverick", "military", "plane", "quick", "top gun", "transportation", "travel"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Transportation"])]
    JetFighterUp = 0xE518,

    /// <summary>
    /// The Font Awesome "joint" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["joint", "blunt", "cannabis", "doobie", "drugs", "marijuana", "roach", "smoke", "smoking", "spliff"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Joint = 0xF595,

    /// <summary>
    /// The Font Awesome "book-journal-whills" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book journal whills", "book", "force", "jedi", "sith", "star wars", "yoda"])]
    [FontAwesomeCategories(["Religion", "Science Fiction"])]
    JournalWhills = 0xF66A,

    /// <summary>
    /// The Font Awesome "jug-detergent" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["jug detergent", "detergent", "laundry", "soap", "wash"])]
    [FontAwesomeCategories(["Household", "Humanitarian"])]
    JugDetergent = 0xE519,

    /// <summary>
    /// The Font Awesome "kaaba" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["muslim", "building", "cube", "islam", "kaaba", "muslim", "religion"])]
    [FontAwesomeCategories(["Buildings", "Religion"])]
    Kaaba = 0xF66B,

    /// <summary>
    /// The Font Awesome "key" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["key", "lock", "password", "private", "secret", "unlock"])]
    [FontAwesomeCategories(["Maps", "Security", "Shopping", "Travel + Hotel"])]
    Key = 0xF084,

    /// <summary>
    /// The Font Awesome "keyboard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["accessory", "computer", "edit", "input", "keyboard", "text", "type", "write"])]
    [FontAwesomeCategories(["Coding", "Devices + Hardware", "Writing"])]
    Keyboard = 0xF11C,

    /// <summary>
    /// The Font Awesome "khanda" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["khanda", "adi shakti", "chakkar", "sikh", "sikhism", "sword"])]
    [FontAwesomeCategories(["Religion"])]
    Khanda = 0xF66D,

    /// <summary>
    /// The Font Awesome "kip-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["kip sign", "kip sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    KipSign = 0xE1C4,

    /// <summary>
    /// The Font Awesome "face-kiss" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face kiss", "beso", "emoticon", "face", "kiss", "kissing face", "love", "smooch"])]
    [FontAwesomeCategories(["Emoji"])]
    Kiss = 0xF596,

    /// <summary>
    /// The Font Awesome "face-kiss-beam" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face kiss beam", "beso", "emoticon", "eye", "face", "kiss", "kissing face with smiling eyes", "love", "smile", "smooch"])]
    [FontAwesomeCategories(["Emoji"])]
    KissBeam = 0xF597,

    /// <summary>
    /// The Font Awesome "face-kiss-wink-heart" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face kiss wink heart", "beso", "emoticon", "face", "face blowing a kiss", "kiss", "love", "smooch"])]
    [FontAwesomeCategories(["Emoji", "Holidays"])]
    KissWinkHeart = 0xF598,

    /// <summary>
    /// The Font Awesome "kitchen-set" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["kitchen set", "chef", "cook", "cup", "kitchen", "pan", "pot", "skillet"])]
    [FontAwesomeCategories(["Household", "Humanitarian", "Travel + Hotel"])]
    KitchenSet = 0xE51A,

    /// <summary>
    /// The Font Awesome "kiwi-bird" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["kiwi bird", "bird", "fauna", "new zealand"])]
    [FontAwesomeCategories(["Animals"])]
    KiwiBird = 0xF535,

    /// <summary>
    /// The Font Awesome "landmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["landmark", "building", "classical", "historic", "memorable", "monument", "museum", "politics", "society"])]
    [FontAwesomeCategories(["Buildings", "Business", "Humanitarian", "Maps", "Money"])]
    Landmark = 0xF66F,

    /// <summary>
    /// The Font Awesome "landmark-dome" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["landmark dome", "building", "historic", "memorable", "monument", "politics"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Political"])]
    LandmarkDome = 0xF752,

    /// <summary>
    /// The Font Awesome "landmark-flag" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["landmark flag", "capitol", "flag", "landmark", "memorial"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Maps", "Political"])]
    LandmarkFlag = 0xE51C,

    /// <summary>
    /// The Font Awesome "land-mine-on" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["land mine on", "bomb", "danger", "explosion", "war"])]
    [FontAwesomeCategories(["Humanitarian", "Security"])]
    LandMineOn = 0xE51B,

    /// <summary>
    /// The Font Awesome "language" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["language", "dialect", "idiom", "localize", "speech", "translate", "vernacular"])]
    [FontAwesomeCategories(["Communication"])]
    Language = 0xF1AB,

    /// <summary>
    /// The Font Awesome "laptop" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["computer", "cpu", "dell", "demo", "device", "fabook", "fb", "laptop", "mac", "macbook", "machine", "pc", "personal"])]
    [FontAwesomeCategories(["Devices + Hardware", "Humanitarian"])]
    Laptop = 0xF109,

    /// <summary>
    /// The Font Awesome "laptop-code" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["laptop code", "computer", "cpu", "dell", "demo", "develop", "device", "fabook", "fb", "mac", "macbook", "machine", "mysql", "pc", "sql"])]
    [FontAwesomeCategories(["Coding", "Education"])]
    LaptopCode = 0xF5FC,

    /// <summary>
    /// The Font Awesome "laptop-file" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["laptop file", "computer", "education", "laptop", "learning", "remote work"])]
    [FontAwesomeCategories(["Business", "Devices + Hardware", "Education", "Humanitarian"])]
    LaptopFile = 0xE51D,

    /// <summary>
    /// The Font Awesome "laptop-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["laptop medical", "computer", "device", "ehr", "electronic health records", "history"])]
    [FontAwesomeCategories(["Medical + Health"])]
    LaptopMedical = 0xF812,

    /// <summary>
    /// The Font Awesome "lari-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["lari sign", "lari sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    LariSign = 0xE1C8,

    /// <summary>
    /// The Font Awesome "face-laugh" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face laugh", "lol", "emoticon", "face", "laugh", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    Laugh = 0xF599,

    /// <summary>
    /// The Font Awesome "face-laugh-beam" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face laugh beam", "lol", "beaming face with smiling eyes", "emoticon", "eye", "face", "grin", "happy", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    LaughBeam = 0xF59A,

    /// <summary>
    /// The Font Awesome "face-laugh-squint" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face laugh squint", "lol", "emoticon", "face", "happy", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    LaughSquint = 0xF59B,

    /// <summary>
    /// The Font Awesome "face-laugh-wink" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face laugh wink", "lol", "emoticon", "face", "happy", "smile"])]
    [FontAwesomeCategories(["Emoji"])]
    LaughWink = 0xF59C,

    /// <summary>
    /// The Font Awesome "layer-group" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["layer group", "arrange", "category", "develop", "layers", "map", "platform", "stack"])]
    [FontAwesomeCategories(["Design", "Maps"])]
    LayerGroup = 0xF5FD,

    /// <summary>
    /// The Font Awesome "leaf" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["leaf", "eco", "flora", "nature", "plant", "vegan"])]
    [FontAwesomeCategories(["Charity", "Energy", "Fruits + Vegetables", "Maps", "Nature"])]
    Leaf = 0xF06C,

    /// <summary>
    /// The Font Awesome "lemon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["citrus", "fruit", "lemon", "lemonade", "lime", "tart"])]
    [FontAwesomeCategories(["Food + Beverage", "Fruits + Vegetables", "Maps"])]
    Lemon = 0xF094,

    /// <summary>
    /// The Font Awesome "less-than" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x3C.
    /// </summary>
    [FontAwesomeSearchTerms(["less than", "less-than sign", "arithmetic", "compare", "math"])]
    [FontAwesomeCategories(["Mathematics", "Punctuation + Symbols"])]
    LessThan = 0xF536,

    /// <summary>
    /// The Font Awesome "less-than-equal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["less than equal", "arithmetic", "compare", "math"])]
    [FontAwesomeCategories(["Mathematics"])]
    LessThanEqual = 0xF537,

    /// <summary>
    /// The Font Awesome "turn-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["turn down", "arrow", "down", "level-down", "right arrow curving down"])]
    [FontAwesomeCategories(["Arrows"])]
    LevelDownAlt = 0xF3BE,

    /// <summary>
    /// The Font Awesome "turn-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["turn up", "arrow", "level-up", "right arrow curving up"])]
    [FontAwesomeCategories(["Arrows"])]
    LevelUpAlt = 0xF3BF,

    /// <summary>
    /// The Font Awesome "life-ring" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["life ring", "coast guard", "help", "overboard", "save", "support"])]
    [FontAwesomeCategories(["Humanitarian", "Maps", "Spinners"])]
    LifeRing = 0xF1CD,

    /// <summary>
    /// The Font Awesome "lightbulb" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["lightbulb", "bulb", "bulb", "comic", "comic", "electric", "electric", "energy", "idea", "idea", "innovation", "inspiration", "inspiration", "light", "light bulb", "mechanical"])]
    [FontAwesomeCategories(["Energy", "Household", "Maps", "Marketing"])]
    Lightbulb = 0xF0EB,

    /// <summary>
    /// The Font Awesome "lines-leaning" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["lines leaning", "canted", "domino", "falling", "resilience", "resilient", "tipped"])]
    [FontAwesomeCategories(["Design", "Humanitarian", "Shapes"])]
    LinesLeaning = 0xE51E,

    /// <summary>
    /// The Font Awesome "link" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["attach", "attachment", "chain", "connect", "lin", "link"])]
    [FontAwesomeCategories(["Editing"])]
    Link = 0xF0C1,

    /// <summary>
    /// The Font Awesome "lira-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["lira sign", "lira sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    LiraSign = 0xF195,

    /// <summary>
    /// The Font Awesome "list" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["list", "bullet", "category", "cheatsheet", "checklist", "completed", "done", "finished", "ol", "summary", "todo", "ul"])]
    [FontAwesomeCategories(["Text Formatting"])]
    List = 0xF03A,

    /// <summary>
    /// The Font Awesome "rectangle-list" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rectangle list", "cheatsheet", "checklist", "completed", "done", "finished", "ol", "summary", "todo", "ul"])]
    [FontAwesomeCategories(["Text Formatting"])]
    ListAlt = 0xF022,

    /// <summary>
    /// The Font Awesome "list-ol" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["list ol", "cheatsheet", "checklist", "completed", "done", "finished", "numbers", "ol", "summary", "todo", "ul"])]
    [FontAwesomeCategories(["Text Formatting"])]
    ListOl = 0xF0CB,

    /// <summary>
    /// The Font Awesome "list-ul" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["list ul", "bullet", "cheatsheet", "checklist", "completed", "done", "finished", "ol", "summary", "survey", "todo", "ul"])]
    [FontAwesomeCategories(["Text Formatting"])]
    ListUl = 0xF0CA,

    /// <summary>
    /// The Font Awesome "litecoin-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["litecoin sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    LitecoinSign = 0xE1D3,

    /// <summary>
    /// The Font Awesome "location-arrow" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["location arrow", "address", "compass", "coordinate", "direction", "gps", "map", "navigation", "place"])]
    [FontAwesomeCategories(["Arrows", "Maps"])]
    LocationArrow = 0xF124,

    /// <summary>
    /// The Font Awesome "location-crosshairs" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["location crosshairs", "address", "coordinate", "direction", "gps", "location", "map", "navigation", "place", "where"])]
    [FontAwesomeCategories(["Maps", "Toggle"])]
    LocationCrosshairs = 0xF601,

    /// <summary>
    /// The Font Awesome "location-pin-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["location pin lock", "closed", "lockdown", "map", "padlock", "privacy", "quarantine"])]
    [FontAwesomeCategories(["Humanitarian", "Maps"])]
    LocationPinLock = 0xE51F,

    /// <summary>
    /// The Font Awesome "lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["admin", "closed", "lock", "locked", "open", "padlock", "password", "privacy", "private", "protect", "security"])]
    [FontAwesomeCategories(["Security"])]
    Lock = 0xF023,

    /// <summary>
    /// The Font Awesome "lock-open" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["lock open", "admin", "lock", "open", "padlock", "password", "privacy", "private", "protect", "security", "unlock"])]
    [FontAwesomeCategories(["Security"])]
    LockOpen = 0xF3C1,

    /// <summary>
    /// The Font Awesome "locust" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["horde", "infestation", "locust", "plague", "swarm"])]
    [FontAwesomeCategories(["Animals", "Disaster + Crisis", "Humanitarian", "Nature"])]
    Locust = 0xE520,

    /// <summary>
    /// The Font Awesome "down-long" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["down long", "download", "long-arrow-down"])]
    [FontAwesomeCategories(["Arrows"])]
    LongArrowAltDown = 0xF309,

    /// <summary>
    /// The Font Awesome "left-long" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["left long", "back", "long-arrow-left", "previous"])]
    [FontAwesomeCategories(["Arrows"])]
    LongArrowAltLeft = 0xF30A,

    /// <summary>
    /// The Font Awesome "right-long" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["right long", "forward", "long-arrow-right", "next"])]
    [FontAwesomeCategories(["Arrows"])]
    LongArrowAltRight = 0xF30B,

    /// <summary>
    /// The Font Awesome "up-long" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["up long", "long-arrow-up", "upgrade", "upload"])]
    [FontAwesomeCategories(["Arrows"])]
    LongArrowAltUp = 0xF30C,

    /// <summary>
    /// The Font Awesome "eye-low-vision" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["eye low vision", "blind", "eye", "sight"])]
    [FontAwesomeCategories(["Accessibility", "Maps"])]
    LowVision = 0xF2A8,

    /// <summary>
    /// The Font Awesome "cart-flatbed-suitcase" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cart flatbed suitcase", "airport", "bag", "baggage", "suitcase", "travel"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    LuggageCart = 0xF59D,

    /// <summary>
    /// The Font Awesome "lungs" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["air", "breath", "covid-19", "exhalation", "inhalation", "lungs", "organ", "respiration", "respiratory"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    Lungs = 0xF604,

    /// <summary>
    /// The Font Awesome "lungs-virus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["lungs virus", "breath", "coronavirus", "covid-19", "flu", "infection", "pandemic", "respiratory", "sick"])]
    [FontAwesomeCategories(["Medical + Health"])]
    LungsVirus = 0xE067,

    /// <summary>
    /// The Font Awesome "wand-magic" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wand magic", "autocomplete", "automatic", "mage", "magic", "spell", "wand", "witch", "wizard"])]
    [FontAwesomeCategories(["Design", "Editing"])]
    Magic = 0xF0D0,

    /// <summary>
    /// The Font Awesome "magnet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["attract", "attraction", "horseshoe", "lodestone", "magnet", "magnetic", "tool"])]
    [FontAwesomeCategories(["Maps", "Science"])]
    Magnet = 0xF076,

    /// <summary>
    /// The Font Awesome "magnifying-glass-arrow-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["magnifying glass arrow right", "find", "magnifier", "next", "search"])]
    [FontAwesomeCategories(["Business", "Humanitarian", "Marketing"])]
    MagnifyingGlassArrowRight = 0xE521,

    /// <summary>
    /// The Font Awesome "magnifying-glass-chart" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["magnifying glass chart", "analysis", "chart", "data", "graph", "intelligence", "magnifier", "market", "revenue"])]
    [FontAwesomeCategories(["Business", "Humanitarian", "Marketing"])]
    MagnifyingGlassChart = 0xE522,

    /// <summary>
    /// The Font Awesome "envelopes-bulk" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["envelopes bulk", "archive", "envelope", "letter", "newsletter", "offer", "post office", "postal", "postcard", "send", "stamp", "usps"])]
    [FontAwesomeCategories(["Marketing"])]
    MailBulk = 0xF674,

    /// <summary>
    /// The Font Awesome "person" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person", "default", "man", "person standing", "stand", "standing", "uer", "woman"])]
    [FontAwesomeCategories(["Humanitarian", "Maps", "Users + People"])]
    Male = 0xF183,

    /// <summary>
    /// The Font Awesome "manat-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["manat sign", "manat sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    ManatSign = 0xE1D5,

    /// <summary>
    /// The Font Awesome "map" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["address", "coordinates", "destination", "gps", "localize", "location", "map", "navigation", "paper", "pin", "place", "point of interest", "position", "route", "travel", "world", "world map"])]
    [FontAwesomeCategories(["Camping", "Maps", "Travel + Hotel"])]
    Map = 0xF279,

    /// <summary>
    /// The Font Awesome "map-location" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["map location", "address", "coordinates", "destination", "gps", "localize", "location", "map", "navigation", "paper", "pin", "place", "point of interest", "position", "route", "travel"])]
    [FontAwesomeCategories(["Camping", "Travel + Hotel"])]
    MapMarked = 0xF59F,

    /// <summary>
    /// The Font Awesome "map-location-dot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["map location dot", "address", "coordinates", "destination", "gps", "localize", "location", "map", "navigation", "paper", "pin", "place", "point of interest", "position", "route", "travel"])]
    [FontAwesomeCategories(["Camping", "Travel + Hotel"])]
    MapMarkedAlt = 0xF5A0,

    /// <summary>
    /// The Font Awesome "location-pin" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["location pin", "address", "coordinates", "destination", "gps", "localize", "location", "map", "navigation", "paper", "pin", "place", "point of interest", "position", "route", "travel"])]
    [FontAwesomeCategories(["Maps", "Shapes", "Social"])]
    MapMarker = 0xF041,

    /// <summary>
    /// The Font Awesome "location-dot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["location dot", "address", "coordinates", "destination", "gps", "localize", "location", "map", "navigation", "paper", "pin", "place", "point of interest", "position", "route", "travel"])]
    [FontAwesomeCategories(["Maps", "Social"])]
    MapMarkerAlt = 0xF3C5,

    /// <summary>
    /// The Font Awesome "map-pin" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["map pin", "address", "agree", "coordinates", "destination", "gps", "localize", "location", "map", "marker", "navigation", "pin", "place", "position", "pushpin", "round pushpin", "travel"])]
    [FontAwesomeCategories(["Maps"])]
    MapPin = 0xF276,

    /// <summary>
    /// The Font Awesome "signs-post" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["signs post", "directions", "directory", "map", "signage", "wayfinding"])]
    [FontAwesomeCategories(["Camping", "Maps", "Nature"])]
    MapSigns = 0xF277,

    /// <summary>
    /// The Font Awesome "marker" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["marker", "design", "edit", "modify", "sharpie", "update", "write"])]
    [FontAwesomeCategories(["Business", "Design"])]
    Marker = 0xF5A1,

    /// <summary>
    /// The Font Awesome "mars" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mars", "gender", "male", "male sign", "man"])]
    [FontAwesomeCategories(["Genders"])]
    Mars = 0xF222,

    /// <summary>
    /// The Font Awesome "mars-and-venus-burst" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mars and venus burst", "gender", "uer", "violence"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    MarsAndVenusBurst = 0xE523,

    /// <summary>
    /// The Font Awesome "mars-double" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mars double", "doubled male sign", "gay", "gender", "male", "men"])]
    [FontAwesomeCategories(["Genders"])]
    MarsDouble = 0xF227,

    /// <summary>
    /// The Font Awesome "mars-stroke" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mars stroke", "male with stroke sign", "gender", "transgender"])]
    [FontAwesomeCategories(["Genders"])]
    MarsStroke = 0xF229,

    /// <summary>
    /// The Font Awesome "mars-stroke-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mars stroke right", "horizontal male with stroke sign", "gender"])]
    [FontAwesomeCategories(["Genders"])]
    MarsStrokeH = 0xF22B,

    /// <summary>
    /// The Font Awesome "mars-stroke-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mars stroke up", "vertical male with stroke sign", "gender"])]
    [FontAwesomeCategories(["Genders"])]
    MarsStrokeV = 0xF22A,

    /// <summary>
    /// The Font Awesome "mask" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mask", "carnivale", "costume", "disguise", "halloween", "secret", "super hero"])]
    [FontAwesomeCategories(["Halloween", "Security"])]
    Mask = 0xF6FA,

    /// <summary>
    /// The Font Awesome "mask-face" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mask face", "breath", "coronavirus", "covid-19", "filter", "flu", "infection", "pandemic", "respirator", "virus"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    MaskFace = 0xE1D7,

    /// <summary>
    /// The Font Awesome "mask-ventilator" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mask ventilator", "breath", "gas", "mask", "oxygen", "respirator", "ventilator"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    MaskVentilator = 0xE524,

    /// <summary>
    /// The Font Awesome "mattress-pillow" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mattress pillow", "air mattress", "mattress", "pillow", "rest", "sleep"])]
    [FontAwesomeCategories(["Camping", "Household", "Humanitarian"])]
    MattressPillow = 0xE525,

    /// <summary>
    /// The Font Awesome "medal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["award", "guarantee", "medal", "quality", "ribbon", "sports medal", "star", "trophy", "warranty"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    Medal = 0xF5A2,

    /// <summary>
    /// The Font Awesome "suitcase-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["suitcase medical", "first aid", "firstaid", "health", "help", "medical", "supply", "support"])]
    [FontAwesomeCategories(["Humanitarian", "Maps", "Medical + Health"])]
    Medkit = 0xF0FA,

    /// <summary>
    /// The Font Awesome "face-meh" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face meh", "deadpan", "default", "emoticon", "face", "meh", "neutral", "neutral face", "rating", "uer"])]
    [FontAwesomeCategories(["Communication", "Emoji", "Users + People"])]
    Meh = 0xF11A,

    /// <summary>
    /// The Font Awesome "face-meh-blank" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face meh blank", "emoticon", "face", "face without mouth", "mouth", "neutral", "quiet", "rating", "silent"])]
    [FontAwesomeCategories(["Emoji"])]
    MehBlank = 0xF5A4,

    /// <summary>
    /// The Font Awesome "face-rolling-eyes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face rolling eyes", "emoticon", "eyeroll", "eyes", "face", "face with rolling eyes", "neutral", "rating", "rolling"])]
    [FontAwesomeCategories(["Emoji"])]
    MehRollingEyes = 0xF5A5,

    /// <summary>
    /// The Font Awesome "memory" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["memory", "dimm", "ram", "hardware", "storage", "technology"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    Memory = 0xF538,

    /// <summary>
    /// The Font Awesome "menorah" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["menorah", "candle", "hanukkah", "jewish", "judaism", "light"])]
    [FontAwesomeCategories(["Holidays", "Religion"])]
    Menorah = 0xF676,

    /// <summary>
    /// The Font Awesome "mercury" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mercury", "mercury", "gender", "hybrid", "transgender"])]
    [FontAwesomeCategories(["Genders"])]
    Mercury = 0xF223,

    /// <summary>
    /// The Font Awesome "meteor" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["meteor", "armageddon", "asteroid", "comet", "shooting star", "space"])]
    [FontAwesomeCategories(["Astronomy", "Weather"])]
    Meteor = 0xF753,

    /// <summary>
    /// The Font Awesome "microchip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["microchip", "cpu", "hardware", "processor", "technology"])]
    [FontAwesomeCategories(["Coding", "Devices + Hardware"])]
    Microchip = 0xF2DB,

    /// <summary>
    /// The Font Awesome "microphone" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["microphone", "address", "audio", "information", "podcast", "public", "record", "sing", "sound", "talking", "voice"])]
    [FontAwesomeCategories(["Communication", "Film + Video", "Music + Audio", "Toggle"])]
    Microphone = 0xF130,

    /// <summary>
    /// The Font Awesome "microphone-lines" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["microphone lines", "audio", "mic", "microphone", "music", "podcast", "record", "sing", "sound", "studio", "studio microphone", "talking", "voice"])]
    [FontAwesomeCategories(["Communication", "Film + Video", "Music + Audio"])]
    MicrophoneAlt = 0xF3C9,

    /// <summary>
    /// The Font Awesome "microphone-lines-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["microphone lines slash", "audio", "disable", "disabled", "disconnect", "disconnect", "mute", "podcast", "record", "sing", "sound", "voice"])]
    [FontAwesomeCategories(["Communication", "Film + Video", "Music + Audio"])]
    MicrophoneAltSlash = 0xF539,

    /// <summary>
    /// The Font Awesome "microphone-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["microphone slash", "audio", "disable", "disabled", "mute", "podcast", "record", "sing", "sound", "voice"])]
    [FontAwesomeCategories(["Communication", "Film + Video", "Music + Audio", "Toggle"])]
    MicrophoneSlash = 0xF131,

    /// <summary>
    /// The Font Awesome "microscope" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["covid-19", "electron", "knowledge", "lens", "microscope", "optics", "science", "shrink", "testing", "tool"])]
    [FontAwesomeCategories(["Education", "Humanitarian", "Medical + Health", "Science"])]
    Microscope = 0xF610,

    /// <summary>
    /// The Font Awesome "mill-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mill sign", "mill sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    MillSign = 0xE1ED,

    /// <summary>
    /// The Font Awesome "minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["en dash", "minus sign", "collapse", "delete", "hide", "math", "minify", "minus", "negative", "remove", "sign", "trash", "−"])]
    [FontAwesomeCategories(["Editing", "Mathematics", "Punctuation + Symbols"])]
    Minus = 0xF068,

    /// <summary>
    /// The Font Awesome "circle-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle minus", "delete", "hide", "negative", "remove", "shape", "trash"])]
    [FontAwesomeCategories(["Mathematics"])]
    MinusCircle = 0xF056,

    /// <summary>
    /// The Font Awesome "square-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square minus", "collapse", "delete", "hide", "minify", "negative", "remove", "shape", "trash"])]
    [FontAwesomeCategories(["Mathematics"])]
    MinusSquare = 0xF146,

    /// <summary>
    /// The Font Awesome "mitten" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mitten", "clothing", "cold", "glove", "hands", "knitted", "seasonal", "warmth"])]
    [FontAwesomeCategories(["Childhood", "Clothing + Fashion"])]
    Mitten = 0xF7B5,

    /// <summary>
    /// The Font Awesome "mobile" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["android", "call", "cell", "cell phone", "device", "mobile", "mobile phone", "number", "phone", "screen", "telephone", "text"])]
    [FontAwesomeCategories(["Communication", "Devices + Hardware"])]
    Mobile = 0xF3CE,

    /// <summary>
    /// The Font Awesome "mobile-screen-button" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mobile screen button", "apple", "call", "cell phone", "device", "iphone", "number", "screen", "telephone"])]
    [FontAwesomeCategories(["Communication", "Devices + Hardware"])]
    MobileAlt = 0xF3CD,

    /// <summary>
    /// The Font Awesome "mobile-button" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mobile button", "apple", "call", "cell phone", "device", "iphone", "number", "screen", "telephone"])]
    [FontAwesomeCategories(["Communication", "Devices + Hardware"])]
    MobileButton = 0xF10B,

    /// <summary>
    /// The Font Awesome "mobile-retro" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mobile retro", "cellphone", "cellular", "phone"])]
    [FontAwesomeCategories(["Communication", "Devices + Hardware", "Humanitarian"])]
    MobileRetro = 0xE527,

    /// <summary>
    /// The Font Awesome "mobile-screen" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mobile screen", "android", "call", "cell phone", "device", "number", "screen", "telephone", "text"])]
    [FontAwesomeCategories(["Communication", "Devices + Hardware", "Humanitarian"])]
    MobileScreen = 0xF3CF,

    /// <summary>
    /// The Font Awesome "mobile-vibrate" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mobile vibrate", "android", "call", "cell", "cell phone", "device", "haptic", "mobile", "mobile phone", "notification", "number", "phone", "screen", "telephone", "text"])]
    [FontAwesomeCategories(["Communication", "Devices + Hardware"])]
    MobileVibrate = 0xE816,

    /// <summary>
    /// The Font Awesome "money-bill" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money bill", "buy", "cash", "checkout", "coupon", "investment", "money", "payment", "premium", "price", "purchase", "revenue", "salary"])]
    [FontAwesomeCategories(["Maps", "Money"])]
    MoneyBill = 0xF0D6,

    /// <summary>
    /// The Font Awesome "money-bill-1" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money bill 1", "buy", "cash", "checkout", "money", "payment", "premium", "price", "purchase", "salary"])]
    [FontAwesomeCategories(["Maps", "Money"])]
    MoneyBillAlt = 0xF3D1,

    /// <summary>
    /// The Font Awesome "money-bills" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money bills", "atm", "cash", "investment", "money", "moolah", "premium", "revenue", "salary"])]
    [FontAwesomeCategories(["Humanitarian", "Money"])]
    MoneyBills = 0xE1F3,

    /// <summary>
    /// The Font Awesome "money-bill-transfer" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money bill transfer", "bank", "conversion", "deposit", "investment", "money", "salary", "transfer", "withdrawal"])]
    [FontAwesomeCategories(["Humanitarian", "Money"])]
    MoneyBillTransfer = 0xE528,

    /// <summary>
    /// The Font Awesome "money-bill-trend-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money bill trend up", "bank", "bonds", "inflation", "investment", "market", "revenue", "salary", "stocks", "trade"])]
    [FontAwesomeCategories(["Humanitarian", "Money"])]
    MoneyBillTrendUp = 0xE529,

    /// <summary>
    /// The Font Awesome "money-bill-wave" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money bill wave", "buy", "cash", "checkout", "money", "payment", "premium", "price", "purchase", "salary"])]
    [FontAwesomeCategories(["Money"])]
    MoneyBillWave = 0xF53A,

    /// <summary>
    /// The Font Awesome "money-bill-1-wave" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money bill 1 wave", "buy", "cash", "checkout", "money", "payment", "premium", "price", "purchase", "salary"])]
    [FontAwesomeCategories(["Money"])]
    MoneyBillWaveAlt = 0xF53B,

    /// <summary>
    /// The Font Awesome "money-bill-wheat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money bill wheat", "agribusiness", "agriculture", "farming", "food", "investment", "livelihood", "subsidy"])]
    [FontAwesomeCategories(["Humanitarian", "Money"])]
    MoneyBillWheat = 0xE52A,

    /// <summary>
    /// The Font Awesome "money-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money check", "bank check", "buy", "checkout", "cheque", "money", "payment", "price", "purchase", "salary"])]
    [FontAwesomeCategories(["Money", "Shopping"])]
    MoneyCheck = 0xF53C,

    /// <summary>
    /// The Font Awesome "money-check-dollar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["money check dollar", "bank check", "buy", "checkout", "cheque", "money", "payment", "price", "purchase", "salary"])]
    [FontAwesomeCategories(["Money", "Shopping"])]
    MoneyCheckAlt = 0xF53D,

    /// <summary>
    /// The Font Awesome "monument" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["monument", "building", "historic", "landmark", "memorable"])]
    [FontAwesomeCategories(["Buildings", "Maps", "Travel + Hotel"])]
    Monument = 0xF5A6,

    /// <summary>
    /// The Font Awesome "moon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["power sleep symbol", "contrast", "crescent", "crescent moon", "dark", "lunar", "moon", "night"])]
    [FontAwesomeCategories(["Astronomy", "Weather"])]
    Moon = 0xF186,

    /// <summary>
    /// The Font Awesome "mortar-pestle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mortar pestle", "crush", "culinary", "grind", "medical", "mix", "pharmacy", "prescription", "spices"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    MortarPestle = 0xF5A7,

    /// <summary>
    /// The Font Awesome "mosque" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["muslim", "building", "islam", "landmark", "mosque", "muslim", "religion"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Religion"])]
    Mosque = 0xF678,

    /// <summary>
    /// The Font Awesome "mosquito" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bite", "bug", "mosquito", "west nile"])]
    [FontAwesomeCategories(["Animals", "Camping", "Disaster + Crisis", "Humanitarian", "Nature"])]
    Mosquito = 0xE52B,

    /// <summary>
    /// The Font Awesome "mosquito-net" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mosquito net", "bite", "malaria", "mosquito", "net"])]
    [FontAwesomeCategories(["Camping", "Humanitarian"])]
    MosquitoNet = 0xE52C,

    /// <summary>
    /// The Font Awesome "motorcycle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bike", "machine", "motorcycle", "racing", "transportation", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Maps", "Transportation"])]
    Motorcycle = 0xF21C,

    /// <summary>
    /// The Font Awesome "mound" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mound", "barrier", "hill", "pitcher", "speedbump"])]
    [FontAwesomeCategories(["Construction", "Humanitarian", "Nature", "Sports + Fitness", "Transportation"])]
    Mound = 0xE52D,

    /// <summary>
    /// The Font Awesome "mountain" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cold", "glacier", "hiking", "hill", "landscape", "mountain", "snow", "snow-capped mountain", "travel", "view"])]
    [FontAwesomeCategories(["Camping", "Nature"])]
    Mountain = 0xF6FC,

    /// <summary>
    /// The Font Awesome "mountain-city" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mountain city", "location", "rural", "urban"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Nature", "Travel + Hotel"])]
    MountainCity = 0xE52E,

    /// <summary>
    /// The Font Awesome "mountain-sun" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mountain sun", "country", "hiking", "landscape", "rural", "travel", "view"])]
    [FontAwesomeCategories(["Camping", "Humanitarian", "Maps", "Nature"])]
    MountainSun = 0xE52F,

    /// <summary>
    /// The Font Awesome "computer-mouse" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["computer mouse", "click", "computer", "computer mouse", "cursor", "input", "peripheral"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    Mouse = 0xF8CC,

    /// <summary>
    /// The Font Awesome "arrow-pointer" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow pointer", "arrow", "cursor", "select"])]
    [FontAwesomeCategories(["Arrows"])]
    MousePointer = 0xF245,

    /// <summary>
    /// The Font Awesome "mug-hot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mug hot", "beverage", "caliente", "cocoa", "coffee", "cup", "drink", "holiday", "hot", "hot beverage", "hot chocolate", "steam", "steaming", "tea", "warmth"])]
    [FontAwesomeCategories(["Food + Beverage", "Holidays"])]
    MugHot = 0xF7B6,

    /// <summary>
    /// The Font Awesome "music" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["lyrics", "melody", "music", "musical note", "note", "sing", "sound"])]
    [FontAwesomeCategories(["Education", "Maps", "Media Playback", "Music + Audio"])]
    Music = 0xF001,

    /// <summary>
    /// The Font Awesome "naira-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["naira sign", "naira sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    NairaSign = 0xE1F6,

    /// <summary>
    /// The Font Awesome "network-wired" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["network wired", "computer", "connect", "ethernet", "internet", "intranet"])]
    [FontAwesomeCategories(["Business", "Coding"])]
    NetworkWired = 0xF6FF,

    /// <summary>
    /// The Font Awesome "neuter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["neuter", "neuter", "gender"])]
    [FontAwesomeCategories(["Genders"])]
    Neuter = 0xF22C,

    /// <summary>
    /// The Font Awesome "newspaper" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["article", "editorial", "headline", "journal", "journalism", "news", "newsletter", "newspaper", "paper", "press"])]
    [FontAwesomeCategories(["Maps", "Writing"])]
    Newspaper = 0xF1EA,

    /// <summary>
    /// The Font Awesome "non-binary" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["non binary", "female", "gender", "male", "nb", "queer"])]
    [FontAwesomeCategories(["Genders"])]
    NonBinary = 0xE807,

    /// <summary>
    /// The Font Awesome "notdef" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["notdef", "404", "close", "missing", "not found"])]
    [FontAwesomeCategories(["Coding", "Writing"])]
    Notdef = 0xE1FE,

    /// <summary>
    /// The Font Awesome "not-equal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["not equal", "arithmetic", "compare", "math"])]
    [FontAwesomeCategories(["Mathematics"])]
    NotEqual = 0xF53E,

    /// <summary>
    /// The Font Awesome "notes-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["notes medical", "clipboard", "doctor", "ehr", "health", "history", "records"])]
    [FontAwesomeCategories(["Medical + Health"])]
    NotesMedical = 0xF481,

    /// <summary>
    /// The Font Awesome "object-group" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["object group", "combine", "copy", "design", "merge", "select"])]
    [FontAwesomeCategories(["Design"])]
    ObjectGroup = 0xF247,

    /// <summary>
    /// The Font Awesome "object-ungroup" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["object ungroup", "copy", "design", "merge", "select", "separate"])]
    [FontAwesomeCategories(["Design"])]
    ObjectUngroup = 0xF248,

    /// <summary>
    /// The Font Awesome "octagon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["octagon", "octagonal", "shape", "sign", "stop", "stop sign"])]
    [FontAwesomeCategories(["Shapes"])]
    Octagon = 0xF306,

    /// <summary>
    /// The Font Awesome "oil-can" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["oil can", "auto", "crude", "gasoline", "grease", "lubricate", "petroleum"])]
    [FontAwesomeCategories(["Automotive"])]
    OilCan = 0xF613,

    /// <summary>
    /// The Font Awesome "oil-well" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["oil well", "drill", "oil", "rig"])]
    [FontAwesomeCategories(["Buildings", "Energy", "Humanitarian"])]
    OilWell = 0xE532,

    /// <summary>
    /// The Font Awesome "om" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hindu", "buddhism", "hinduism", "jainism", "mantra", "om", "religion"])]
    [FontAwesomeCategories(["Religion"])]
    Om = 0xF679,

    /// <summary>
    /// The Font Awesome "otter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["animal", "badger", "fauna", "fishing", "fur", "mammal", "marten", "otter", "playful"])]
    [FontAwesomeCategories(["Animals", "Maritime"])]
    Otter = 0xF700,

    /// <summary>
    /// The Font Awesome "outdent" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["outdent", "align", "justify", "paragraph", "tab"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Outdent = 0xF03B,

    /// <summary>
    /// The Font Awesome "pager" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["beeper", "cell phone", "communication", "page", "pager"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Pager = 0xF815,

    /// <summary>
    /// The Font Awesome "paintbrush" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["acrylic", "art", "brush", "color", "fill", "modify", "paint", "paintbrush", "painting", "pigment", "watercolor"])]
    [FontAwesomeCategories(["Design", "Editing"])]
    PaintBrush = 0xF1FC,

    /// <summary>
    /// The Font Awesome "paint-roller" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["paint roller", "acrylic", "art", "brush", "color", "fill", "maintenance", "paint", "pigment", "watercolor"])]
    [FontAwesomeCategories(["Construction", "Design"])]
    PaintRoller = 0xF5AA,

    /// <summary>
    /// The Font Awesome "palette" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["acrylic", "art", "artist palette", "brush", "color", "fill", "museum", "paint", "painting", "palette", "pigment", "watercolor"])]
    [FontAwesomeCategories(["Design", "Spinners"])]
    Palette = 0xF53F,

    /// <summary>
    /// The Font Awesome "pallet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pallet", "archive", "box", "inventory", "shipping", "warehouse"])]
    [FontAwesomeCategories(["Logistics"])]
    Pallet = 0xF482,

    /// <summary>
    /// The Font Awesome "panorama" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["panorama", "image", "img", "landscape", "photo", "wide"])]
    [FontAwesomeCategories(["Photos + Images"])]
    Panorama = 0xE209,

    /// <summary>
    /// The Font Awesome "paperclip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["attach", "attachment", "connect", "link", "papercli", "paperclip"])]
    [FontAwesomeCategories(["Business", "Writing"])]
    Paperclip = 0xF0C6,

    /// <summary>
    /// The Font Awesome "paper-plane" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["paper plane", "air", "float", "fold", "mail", "paper", "send"])]
    [FontAwesomeCategories(["Communication", "Transportation", "Writing"])]
    PaperPlane = 0xF1D8,

    /// <summary>
    /// The Font Awesome "parachute-box" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["parachute box", "aid", "assistance", "goods", "relief", "rescue", "supplies"])]
    [FontAwesomeCategories(["Charity", "Humanitarian"])]
    ParachuteBox = 0xF4CD,

    /// <summary>
    /// The Font Awesome "paragraph" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["paragraph", "pilcrow sign", "edit", "format", "text", "writing"])]
    [FontAwesomeCategories(["Text Formatting", "Writing"])]
    Paragraph = 0xF1DD,

    /// <summary>
    /// The Font Awesome "square-parking" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square parking", "auto", "car", "garage", "meter", "parking"])]
    [FontAwesomeCategories(["Maps"])]
    Parking = 0xF540,

    /// <summary>
    /// The Font Awesome "passport" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["passport", "document", "id", "identification", "issued", "travel"])]
    [FontAwesomeCategories(["Security", "Travel + Hotel"])]
    Passport = 0xF5AB,

    /// <summary>
    /// The Font Awesome "spaghetti-monster-flying" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["spaghetti monster flying", "agnosticism", "atheism", "flying spaghetti monster", "fsm"])]
    [FontAwesomeCategories(["Religion"])]
    Pastafarianism = 0xF67B,

    /// <summary>
    /// The Font Awesome "paste" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["paste", "clipboard", "copy", "document", "paper"])]
    [FontAwesomeCategories(["Business", "Design", "Files"])]
    Paste = 0xF0EA,

    /// <summary>
    /// The Font Awesome "pause" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bar", "double", "hold", "pause", "pause button", "vertical", "wait"])]
    [FontAwesomeCategories(["Media Playback"])]
    Pause = 0xF04C,

    /// <summary>
    /// The Font Awesome "circle-pause" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle pause", "hold", "wait"])]
    [FontAwesomeCategories(["Media Playback"])]
    PauseCircle = 0xF28B,

    /// <summary>
    /// The Font Awesome "paw" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["paw", "animal", "cat", "dog", "pet", "print"])]
    [FontAwesomeCategories(["Animals", "Maps"])]
    Paw = 0xF1B0,

    /// <summary>
    /// The Font Awesome "peace" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["peace", "peace symbol", "serenity", "tranquility", "truce", "war"])]
    [FontAwesomeCategories(["Religion"])]
    Peace = 0xF67C,

    /// <summary>
    /// The Font Awesome "pen" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ballpoint", "design", "edit", "modify", "pen", "update", "write"])]
    [FontAwesomeCategories(["Business", "Design", "Editing", "Writing"])]
    Pen = 0xF304,

    /// <summary>
    /// The Font Awesome "pen-clip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pen clip", "design", "edit", "modify", "update", "write"])]
    [FontAwesomeCategories(["Business", "Design", "Editing", "Writing"])]
    PenAlt = 0xF305,

    /// <summary>
    /// The Font Awesome "pencil" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["lower left pencil", "design", "draw", "edit", "lead", "maintenance", "modify", "pencil", "update", "write"])]
    [FontAwesomeCategories(["Business", "Construction", "Design", "Editing", "Writing"])]
    PencilAlt = 0xF303,

    /// <summary>
    /// The Font Awesome "pen-ruler" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pen ruler", "design", "draft", "draw", "maintenance", "modify", "pencil"])]
    [FontAwesomeCategories(["Construction", "Design", "Editing"])]
    PencilRuler = 0xF5AE,

    /// <summary>
    /// The Font Awesome "pen-fancy" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pen fancy", "black nib", "design", "edit", "fountain", "fountain pen", "modify", "nib", "pen", "update", "write"])]
    [FontAwesomeCategories(["Business", "Design", "Editing"])]
    PenFancy = 0xF5AC,

    /// <summary>
    /// The Font Awesome "pen-nib" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pen nib", "design", "edit", "fountain pen", "modify", "update", "write"])]
    [FontAwesomeCategories(["Business", "Design", "Editing"])]
    PenNib = 0xF5AD,

    /// <summary>
    /// The Font Awesome "square-pen" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square pen", "edit", "modify", "pencil-square", "update", "write"])]
    [FontAwesomeCategories(["Business", "Editing", "Writing"])]
    PenSquare = 0xF14B,

    /// <summary>
    /// The Font Awesome "pentagon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["5", "five", "pentagon", "shape"])]
    [FontAwesomeCategories(["Shapes"])]
    Pentagon = 0xE790,

    /// <summary>
    /// The Font Awesome "people-arrows" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["people arrows", "conversation", "discussion", "distance", "insert", "isolation", "separate", "social distancing", "talk", "talking", "together", "uer", "users-people"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PeopleArrows = 0xE068,

    /// <summary>
    /// The Font Awesome "people-carry-box" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["people carry box", "together", "uer", "users-people"])]
    [FontAwesomeCategories(["Moving", "Users + People"])]
    PeopleCarry = 0xF4CE,

    /// <summary>
    /// The Font Awesome "people-group" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["people group", "crowd", "family", "group", "team", "together", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Marketing", "Users + People"])]
    PeopleGroup = 0xE533,

    /// <summary>
    /// The Font Awesome "people-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["people line", "crowd", "group", "need", "together", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PeopleLine = 0xE534,

    /// <summary>
    /// The Font Awesome "people-pulling" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["people pulling", "forced return", "together", "uer", "yanking"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PeoplePulling = 0xE535,

    /// <summary>
    /// The Font Awesome "people-robbery" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["people robbery", "criminal", "hands up", "looting", "robbery", "steal", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PeopleRobbery = 0xE536,

    /// <summary>
    /// The Font Awesome "people-roof" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["people roof", "crowd", "family", "group", "manage", "people", "safe", "shelter", "together", "uer"])]
    [FontAwesomeCategories(["Camping", "Household", "Humanitarian", "Users + People"])]
    PeopleRoof = 0xE537,

    /// <summary>
    /// The Font Awesome "pepper-hot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pepper hot", "buffalo wings", "capsicum", "chili", "chilli", "habanero", "hot", "hot pepper", "jalapeno", "mexican", "pepper", "spicy", "tabasco", "vegetable"])]
    [FontAwesomeCategories(["Food + Beverage", "Fruits + Vegetables"])]
    PepperHot = 0xF816,

    /// <summary>
    /// The Font Awesome "percent" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x25.
    /// </summary>
    [FontAwesomeSearchTerms(["percent", "percent sign", "discount", "fraction", "proportion", "rate", "ratio"])]
    [FontAwesomeCategories(["Business", "Mathematics", "Money", "Punctuation + Symbols"])]
    Percent = 0xF295,

    /// <summary>
    /// The Font Awesome "percent" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x25.
    /// </summary>
    [FontAwesomeSearchTerms(["percent", "percent sign", "discount", "fraction", "proportion", "rate", "ratio"])]
    [FontAwesomeCategories(["Business", "Mathematics", "Money", "Punctuation + Symbols"])]
    Percentage = 0xF541,

    /// <summary>
    /// The Font Awesome "person-arrow-down-to-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person arrow down to line", "ground", "indigenous", "insert", "native", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonArrowDownToLine = 0xE538,

    /// <summary>
    /// The Font Awesome "person-arrow-up-from-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person arrow up from line", "population", "rise", "uer", "upgrade"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonArrowUpFromLine = 0xE539,

    /// <summary>
    /// The Font Awesome "person-booth" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person booth", "changing room", "curtain", "uer", "vote", "voting"])]
    [FontAwesomeCategories(["Political", "Shopping", "Users + People"])]
    PersonBooth = 0xF756,

    /// <summary>
    /// The Font Awesome "person-breastfeeding" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person breastfeeding", "baby", "child", "infant", "mother", "nutrition", "parent", "sustenance", "uer"])]
    [FontAwesomeCategories(["Childhood", "Humanitarian", "Medical + Health", "Users + People"])]
    PersonBreastfeeding = 0xE53A,

    /// <summary>
    /// The Font Awesome "person-burst" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person burst", "abuse", "accident", "crash", "explode", "uer", "violence"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PersonBurst = 0xE53B,

    /// <summary>
    /// The Font Awesome "person-cane" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person cane", "aging", "cane", "elderly", "old", "staff", "uer"])]
    [FontAwesomeCategories(["Accessibility", "Humanitarian", "Medical + Health", "Users + People"])]
    PersonCane = 0xE53C,

    /// <summary>
    /// The Font Awesome "person-chalkboard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person chalkboard", "blackboard", "instructor", "keynote", "lesson", "presentation", "teacher", "uer"])]
    [FontAwesomeCategories(["Business", "Education", "Humanitarian", "Users + People"])]
    PersonChalkboard = 0xE53D,

    /// <summary>
    /// The Font Awesome "person-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person circle check", "approved", "enable", "not affected", "ok", "okay", "uer", "validate", "working"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonCircleCheck = 0xE53E,

    /// <summary>
    /// The Font Awesome "person-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person circle exclamation", "affected", "alert", "failed", "lost", "missing", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonCircleExclamation = 0xE53F,

    /// <summary>
    /// The Font Awesome "person-circle-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person circle minus", "delete", "remove", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonCircleMinus = 0xE540,

    /// <summary>
    /// The Font Awesome "person-circle-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person circle plus", "add", "follow", "found", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonCirclePlus = 0xE541,

    /// <summary>
    /// The Font Awesome "person-circle-question" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person circle question", "faq", "lost", "missing", "request", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonCircleQuestion = 0xE542,

    /// <summary>
    /// The Font Awesome "person-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person circle xmark", "dead", "removed", "uer", "uncheck"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonCircleXmark = 0xE543,

    /// <summary>
    /// The Font Awesome "person-digging" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person digging", "bury", "construction", "debris", "dig", "maintenance", "men at work", "uer"])]
    [FontAwesomeCategories(["Construction", "Humanitarian", "Users + People"])]
    PersonDigging = 0xF85E,

    /// <summary>
    /// The Font Awesome "person-dress-burst" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person dress burst", "abuse", "accident", "crash", "explode", "uer", "violence"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PersonDressBurst = 0xE544,

    /// <summary>
    /// The Font Awesome "person-drowning" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person drowning", "drown", "emergency", "swim"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Users + People"])]
    PersonDrowning = 0xE545,

    /// <summary>
    /// The Font Awesome "person-falling" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person falling", "accident", "fall", "trip", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonFalling = 0xE546,

    /// <summary>
    /// The Font Awesome "person-falling-burst" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person falling burst", "accident", "crash", "death", "fall", "homicide", "murder", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PersonFallingBurst = 0xE547,

    /// <summary>
    /// The Font Awesome "person-half-dress" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person half dress", "gender", "man", "restroom", "transgender", "uer", "woman"])]
    [FontAwesomeCategories(["Genders", "Humanitarian", "Medical + Health", "Users + People"])]
    PersonHalfDress = 0xE548,

    /// <summary>
    /// The Font Awesome "person-harassing" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person harassing", "abuse", "scream", "shame", "shout", "uer", "yell"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PersonHarassing = 0xE549,

    /// <summary>
    /// The Font Awesome "person-military-pointing" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person military pointing", "army", "customs", "guard", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PersonMilitaryPointing = 0xE54A,

    /// <summary>
    /// The Font Awesome "person-military-rifle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person military rifle", "armed forces", "army", "military", "rifle", "uer", "war"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PersonMilitaryRifle = 0xE54B,

    /// <summary>
    /// The Font Awesome "person-military-to-person" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person military to person", "civilian", "coordination", "military", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PersonMilitaryToPerson = 0xE54C,

    /// <summary>
    /// The Font Awesome "person-pregnant" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person pregnant", "baby", "birth", "child", "parent", "pregnant", "pregnant woman", "uer", "woman"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    PersonPregnant = 0xE31E,

    /// <summary>
    /// The Font Awesome "person-rays" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person rays", "affected", "focus", "shine", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Marketing", "Users + People"])]
    PersonRays = 0xE54D,

    /// <summary>
    /// The Font Awesome "person-rifle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person rifle", "army", "combatant", "gun", "military", "rifle", "uer", "war"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Security", "Users + People"])]
    PersonRifle = 0xE54E,

    /// <summary>
    /// The Font Awesome "person-shelter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person shelter", "house", "inside", "roof", "safe", "safety", "shelter", "uer"])]
    [FontAwesomeCategories(["Camping", "Humanitarian", "Security", "Users + People"])]
    PersonShelter = 0xE54F,

    /// <summary>
    /// The Font Awesome "person-through-window" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person through window", "door", "exit", "forced entry", "leave", "robbery", "steal", "uer", "window"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    PersonThroughWindow = 0xE5A9,

    /// <summary>
    /// The Font Awesome "person-walking-arrow-loop-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person walking arrow loop left", "follow", "population return", "return", "uer"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Users + People"])]
    PersonWalkingArrowLoopLeft = 0xE551,

    /// <summary>
    /// The Font Awesome "person-walking-arrow-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person walking arrow right", "exit", "follow", "internally displaced", "leave", "refugee", "uer"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Users + People"])]
    PersonWalkingArrowRight = 0xE552,

    /// <summary>
    /// The Font Awesome "person-walking-dashed-line-arrow-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person walking dashed line arrow right", "exit", "follow", "refugee", "uer"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Users + People"])]
    PersonWalkingDashedLineArrowRight = 0xE553,

    /// <summary>
    /// The Font Awesome "person-walking-luggage" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person walking luggage", "bag", "baggage", "briefcase", "carry-on", "deployment", "follow", "rolling", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Travel + Hotel", "Users + People"])]
    PersonWalkingLuggage = 0xE554,

    /// <summary>
    /// The Font Awesome "peseta-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["peseta sign", "peseta sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    PesetaSign = 0xE221,

    /// <summary>
    /// The Font Awesome "peso-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["peso sign", "peso sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    PesoSign = 0xE222,

    /// <summary>
    /// The Font Awesome "phone" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["left hand telephone receiver", "call", "earphone", "number", "phone", "receiver", "support", "talking", "telephone", "telephone receiver", "voice"])]
    [FontAwesomeCategories(["Business", "Communication", "Maps"])]
    Phone = 0xF095,

    /// <summary>
    /// The Font Awesome "phone-flip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["phone flip", "right hand telephone receiver", "call", "earphone", "number", "support", "telephone", "voice"])]
    [FontAwesomeCategories(["Business", "Communication", "Maps"])]
    PhoneAlt = 0xF879,

    /// <summary>
    /// The Font Awesome "phone-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["phone slash", "call", "cancel", "disabled", "disconnect", "earphone", "mute", "number", "support", "telephone", "voice"])]
    [FontAwesomeCategories(["Business", "Communication"])]
    PhoneSlash = 0xF3DD,

    /// <summary>
    /// The Font Awesome "square-phone" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square phone", "call", "earphone", "number", "support", "telephone", "voice"])]
    [FontAwesomeCategories(["Business", "Communication", "Maps"])]
    PhoneSquare = 0xF098,

    /// <summary>
    /// The Font Awesome "square-phone-flip" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square phone flip", "call", "earphone", "number", "support", "telephone", "voice"])]
    [FontAwesomeCategories(["Business", "Communication", "Maps"])]
    PhoneSquareAlt = 0xF87B,

    /// <summary>
    /// The Font Awesome "phone-volume" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["phone volume", "call", "earphone", "number", "ring", "ringing", "sound", "support", "talking", "telephone", "voice", "volume-control-phone"])]
    [FontAwesomeCategories(["Accessibility", "Business", "Communication", "Maps", "Media Playback"])]
    PhoneVolume = 0xF2A0,

    /// <summary>
    /// The Font Awesome "photo-film" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["photo film", "av", "film", "image", "library", "media"])]
    [FontAwesomeCategories(["Files", "Film + Video", "Photos + Images", "Social"])]
    PhotoVideo = 0xF87C,

    /// <summary>
    /// The Font Awesome "piggy-bank" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["piggy bank", "bank", "salary", "save", "savings"])]
    [FontAwesomeCategories(["Charity", "Money", "Political"])]
    PiggyBank = 0xF4D3,

    /// <summary>
    /// The Font Awesome "pills" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pills", "drugs", "medicine", "prescription", "tablets"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health", "Science"])]
    Pills = 0xF484,

    /// <summary>
    /// The Font Awesome "pizza-slice" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pizza slice", "cheese", "chicago", "italian", "mozzarella", "new york", "pepperoni", "pie", "slice", "teenage mutant ninja turtles", "tomato"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    PizzaSlice = 0xF818,

    /// <summary>
    /// The Font Awesome "place-of-worship" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["place of worship", "building", "church", "holy", "mosque", "synagogue"])]
    [FontAwesomeCategories(["Buildings", "Religion"])]
    PlaceOfWorship = 0xF67F,

    /// <summary>
    /// The Font Awesome "plane" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane", "airplane", "airport", "destination", "fly", "location", "mode", "travel", "trip"])]
    [FontAwesomeCategories(["Maps", "Transportation", "Travel + Hotel"])]
    Plane = 0xF072,

    /// <summary>
    /// The Font Awesome "plane-arrival" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane arrival", "aeroplane", "airplane", "airplane arrival", "airport", "arrivals", "arriving", "destination", "fly", "land", "landing", "location", "mode", "travel", "trip"])]
    [FontAwesomeCategories(["Transportation", "Travel + Hotel"])]
    PlaneArrival = 0xF5AF,

    /// <summary>
    /// The Font Awesome "plane-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane circle check", "airplane", "airport", "enable", "flight", "fly", "not affected", "ok", "okay", "travel", "validate", "working"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Travel + Hotel"])]
    PlaneCircleCheck = 0xE555,

    /// <summary>
    /// The Font Awesome "plane-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane circle exclamation", "affected", "airplane", "airport", "failed", "flight", "fly", "travel"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Travel + Hotel"])]
    PlaneCircleExclamation = 0xE556,

    /// <summary>
    /// The Font Awesome "plane-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane circle xmark", "airplane", "airport", "destroy", "flight", "fly", "travel", "uncheck"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Travel + Hotel"])]
    PlaneCircleXmark = 0xE557,

    /// <summary>
    /// The Font Awesome "plane-departure" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane departure", "aeroplane", "airplane", "airplane departure", "airport", "check-in", "departing", "departure", "departures", "destination", "fly", "location", "mode", "take off", "taking off", "travel", "trip"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    PlaneDeparture = 0xF5B0,

    /// <summary>
    /// The Font Awesome "plane-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane lock", "airplane", "airport", "closed", "flight", "fly", "lockdown", "padlock", "privacy", "quarantine", "travel"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Travel + Hotel"])]
    PlaneLock = 0xE558,

    /// <summary>
    /// The Font Awesome "plane-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane slash", "airplane mode", "airport", "canceled", "covid-19", "delayed", "disabled", "grounded", "travel"])]
    [FontAwesomeCategories(["Transportation", "Travel + Hotel"])]
    PlaneSlash = 0xE069,

    /// <summary>
    /// The Font Awesome "plane-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plane up", "airplane", "airport", "internet", "signal", "sky", "wifi", "wireless"])]
    [FontAwesomeCategories(["Humanitarian", "Toggle", "Transportation", "Travel + Hotel"])]
    PlaneUp = 0xE22D,

    /// <summary>
    /// The Font Awesome "plant-wilt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plant wilt", "drought", "planting", "vegetation", "wilt"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Nature"])]
    PlantWilt = 0xE5AA,

    /// <summary>
    /// The Font Awesome "plate-wheat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plate wheat", "bowl", "hunger", "rations", "wheat"])]
    [FontAwesomeCategories(["Food + Beverage", "Humanitarian"])]
    PlateWheat = 0xE55A,

    /// <summary>
    /// The Font Awesome "play" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow", "audio", "music", "play", "play button", "playing", "right", "sound", "start", "triangle", "video"])]
    [FontAwesomeCategories(["Media Playback", "Shapes"])]
    Play = 0xF04B,

    /// <summary>
    /// The Font Awesome "circle-play" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle play", "audio", "music", "playing", "sound", "start", "video"])]
    [FontAwesomeCategories(["Media Playback"])]
    PlayCircle = 0xF144,

    /// <summary>
    /// The Font Awesome "plug" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["connect", "electric", "electric plug", "electricity", "online", "plug", "power"])]
    [FontAwesomeCategories(["Devices + Hardware", "Energy", "Household", "Humanitarian", "Maps"])]
    Plug = 0xF1E6,

    /// <summary>
    /// The Font Awesome "plug-circle-bolt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plug circle bolt", "electric", "electricity", "plug", "power"])]
    [FontAwesomeCategories(["Energy", "Humanitarian"])]
    PlugCircleBolt = 0xE55B,

    /// <summary>
    /// The Font Awesome "plug-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plug circle check", "electric", "electricity", "enable", "not affected", "ok", "okay", "plug", "power", "validate", "working"])]
    [FontAwesomeCategories(["Energy", "Humanitarian"])]
    PlugCircleCheck = 0xE55C,

    /// <summary>
    /// The Font Awesome "plug-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plug circle exclamation", "affected", "electric", "electricity", "failed", "plug", "power"])]
    [FontAwesomeCategories(["Energy", "Humanitarian"])]
    PlugCircleExclamation = 0xE55D,

    /// <summary>
    /// The Font Awesome "plug-circle-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plug circle minus", "disconnect", "electric", "electricity", "plug", "power"])]
    [FontAwesomeCategories(["Energy", "Humanitarian"])]
    PlugCircleMinus = 0xE55E,

    /// <summary>
    /// The Font Awesome "plug-circle-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plug circle plus", "electric", "electricity", "plug", "power"])]
    [FontAwesomeCategories(["Energy", "Humanitarian"])]
    PlugCirclePlus = 0xE55F,

    /// <summary>
    /// The Font Awesome "plug-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plug circle xmark", "destroy", "disconnect", "electric", "electricity", "outage", "plug", "power", "uncheck"])]
    [FontAwesomeCategories(["Energy", "Humanitarian"])]
    PlugCircleXmark = 0xE560,

    /// <summary>
    /// The Font Awesome "plus" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x2B.
    /// </summary>
    [FontAwesomeSearchTerms(["+", "plus sign", "add", "create", "expand", "follow", "math", "modify", "new", "plus", "positive", "shape", "sign"])]
    [FontAwesomeCategories(["Editing", "Maps", "Mathematics", "Medical + Health", "Punctuation + Symbols"])]
    Plus = 0xF067,

    /// <summary>
    /// The Font Awesome "circle-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle plus", "add", "create", "expand", "new", "positive", "shape"])]
    [FontAwesomeCategories(["Mathematics"])]
    PlusCircle = 0xF055,

    /// <summary>
    /// The Font Awesome "plus-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["plus minus", "plus-minus sign", "add", "math", "subtract"])]
    [FontAwesomeCategories(["Mathematics", "Media Playback"])]
    PlusMinus = 0xE43C,

    /// <summary>
    /// The Font Awesome "square-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square plus", "add", "create", "expand", "new", "positive", "shape"])]
    [FontAwesomeCategories(["Maps", "Medical + Health"])]
    PlusSquare = 0xF0FE,

    /// <summary>
    /// The Font Awesome "podcast" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["podcast", "audio", "broadcast", "music", "sound"])]
    [FontAwesomeCategories(["Film + Video"])]
    Podcast = 0xF2CE,

    /// <summary>
    /// The Font Awesome "square-poll-vertical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square poll vertical", "chart", "graph", "results", "revenue", "statistics", "survey", "trend", "vote", "voting"])]
    [FontAwesomeCategories(["Business", "Charts + Diagrams", "Marketing", "Social"])]
    Poll = 0xF681,

    /// <summary>
    /// The Font Awesome "square-poll-horizontal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square poll horizontal", "chart", "graph", "results", "statistics", "survey", "trend", "vote", "voting"])]
    [FontAwesomeCategories(["Business", "Charts + Diagrams", "Marketing", "Social"])]
    PollH = 0xF682,

    /// <summary>
    /// The Font Awesome "poo" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["crap", "dung", "face", "monster", "pile of poo", "poo", "poop", "shit", "smile", "turd", "uer"])]
    [FontAwesomeCategories(["Communication", "Users + People"])]
    Poo = 0xF2FE,

    /// <summary>
    /// The Font Awesome "poop" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["crap", "poop", "shit", "smile", "turd"])]
    [FontAwesomeCategories(["Energy", "Medical + Health"])]
    Poop = 0xF619,

    /// <summary>
    /// The Font Awesome "poo-storm" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["poo storm", "bolt", "cloud", "euphemism", "lightning", "mess", "poop", "shit", "turd"])]
    [FontAwesomeCategories(["Weather"])]
    PooStorm = 0xF75A,

    /// <summary>
    /// The Font Awesome "image-portrait" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["image portrait", "id", "image", "img", "photo", "picture", "selfie", "uer", "username"])]
    [FontAwesomeCategories(["Photos + Images", "Users + People"])]
    Portrait = 0xF3E0,

    /// <summary>
    /// The Font Awesome "sterling-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sterling sign", "pound sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    PoundSign = 0xF154,

    /// <summary>
    /// The Font Awesome "power-off" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["power off", "power symbol", "cancel", "computer", "on", "reboot", "restart"])]
    [FontAwesomeCategories(["Devices + Hardware", "Energy"])]
    PowerOff = 0xF011,

    /// <summary>
    /// The Font Awesome "person-praying" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person praying", "kneel", "place of worship", "religion", "thank", "uer", "worship"])]
    [FontAwesomeCategories(["Religion", "Users + People"])]
    Pray = 0xF683,

    /// <summary>
    /// The Font Awesome "hands-praying" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["hands praying", "kneel", "preach", "religion", "worship"])]
    [FontAwesomeCategories(["Hands", "Religion"])]
    PrayingHands = 0xF684,

    /// <summary>
    /// The Font Awesome "prescription" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["prescription", "drugs", "medical", "medicine", "pharmacy", "rx"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Prescription = 0xF5B1,

    /// <summary>
    /// The Font Awesome "prescription-bottle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["prescription bottle", "drugs", "medical", "medicine", "pharmacy", "rx"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    PrescriptionBottle = 0xF485,

    /// <summary>
    /// The Font Awesome "prescription-bottle-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["prescription bottle medical", "drugs", "medical", "medicine", "pharmacy", "rx"])]
    [FontAwesomeCategories(["Medical + Health"])]
    PrescriptionBottleAlt = 0xF486,

    /// <summary>
    /// The Font Awesome "print" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["print", "print screen symbol", "printer icon", "business", "computer", "copy", "document", "office", "paper", "printer"])]
    [FontAwesomeCategories(["Business", "Devices + Hardware", "Maps"])]
    Print = 0xF02F,

    /// <summary>
    /// The Font Awesome "bed-pulse" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bed pulse", "ekg", "bed", "electrocardiogram", "health", "hospital", "life", "patient", "vital"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Procedures = 0xF487,

    /// <summary>
    /// The Font Awesome "diagram-project" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["diagram project", "chart", "graph", "network", "pert", "statistics"])]
    [FontAwesomeCategories(["Charts + Diagrams", "Coding"])]
    ProjectDiagram = 0xF542,

    /// <summary>
    /// The Font Awesome "pump-medical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pump medical", "anti-bacterial", "clean", "covid-19", "disinfect", "hygiene", "medical grade", "sanitizer", "soap"])]
    [FontAwesomeCategories(["Medical + Health"])]
    PumpMedical = 0xE06A,

    /// <summary>
    /// The Font Awesome "pump-soap" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["pump soap", "anti-bacterial", "clean", "covid-19", "disinfect", "hygiene", "sanitizer", "soap"])]
    [FontAwesomeCategories(["Household", "Humanitarian"])]
    PumpSoap = 0xE06B,

    /// <summary>
    /// The Font Awesome "puzzle-piece" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["puzzle piece", "add-on", "addon", "clue", "game", "interlocking", "jigsaw", "piece", "puzzle", "puzzle piece", "section"])]
    [FontAwesomeCategories(["Childhood", "Gaming"])]
    PuzzlePiece = 0xF12E,

    /// <summary>
    /// The Font Awesome "qrcode" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["qrcode", "barcode", "info", "information", "qr", "qr-code", "scan"])]
    [FontAwesomeCategories(["Coding", "Shopping"])]
    Qrcode = 0xF029,

    /// <summary>
    /// The Font Awesome "question" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0x3F.
    /// </summary>
    [FontAwesomeSearchTerms(["?", "question mark", "faq", "help", "information", "mark", "outlined", "punctuation", "question", "red question mark", "request", "support", "unknown", "white question mark"])]
    [FontAwesomeCategories(["Accessibility", "Alert", "Punctuation + Symbols"])]
    Question = 0xF128,

    /// <summary>
    /// The Font Awesome "circle-question" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle question", "faq", "help", "information", "support", "unknown"])]
    [FontAwesomeCategories(["Accessibility", "Punctuation + Symbols"])]
    QuestionCircle = 0xF059,

    /// <summary>
    /// The Font Awesome "broom-ball" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["broom ball", "ball", "bludger", "broom", "golden snitch", "harry potter", "hogwarts", "quaffle", "sport", "wizard"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    Quidditch = 0xF458,

    /// <summary>
    /// The Font Awesome "quote-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["quote left", "left double quotation mark", "mention", "note", "phrase", "text", "type"])]
    [FontAwesomeCategories(["Communication", "Punctuation + Symbols", "Writing"])]
    QuoteLeft = 0xF10D,

    /// <summary>
    /// The Font Awesome "quote-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["quote right", "right double quotation mark", "mention", "note", "phrase", "text", "type"])]
    [FontAwesomeCategories(["Communication", "Punctuation + Symbols", "Writing"])]
    QuoteRight = 0xF10E,

    /// <summary>
    /// The Font Awesome "book-quran" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["book quran", "book", "islam", "muslim", "religion"])]
    [FontAwesomeCategories(["Religion"])]
    Quran = 0xF687,

    /// <summary>
    /// The Font Awesome "radiation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["radiation", "danger", "dangerous", "deadly", "hazard", "nuclear", "radioactive", "warning"])]
    [FontAwesomeCategories(["Alert", "Disaster + Crisis", "Energy", "Humanitarian", "Medical + Health", "Science"])]
    Radiation = 0xF7B9,

    /// <summary>
    /// The Font Awesome "circle-radiation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle radiation", "danger", "dangerous", "deadly", "hazard", "nuclear", "radioactive", "sign", "warning"])]
    [FontAwesomeCategories(["Alert", "Disaster + Crisis", "Energy", "Medical + Health", "Science"])]
    RadiationAlt = 0xF7BA,

    /// <summary>
    /// The Font Awesome "radio" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["am", "broadcast", "fm", "frequency", "music", "news", "radio", "receiver", "transmitter", "tuner", "video"])]
    [FontAwesomeCategories(["Humanitarian", "Music + Audio"])]
    Radio = 0xF8D7,

    /// <summary>
    /// The Font Awesome "rainbow" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["gold", "leprechaun", "prism", "rain", "rainbow", "sky"])]
    [FontAwesomeCategories(["Weather"])]
    Rainbow = 0xF75B,

    /// <summary>
    /// The Font Awesome "shuffle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow", "arrows", "crossed", "shuffle", "shuffle tracks button", "sort", "swap", "switch", "transfer"])]
    [FontAwesomeCategories(["Arrows", "Media Playback"])]
    Random = 0xF074,

    /// <summary>
    /// The Font Awesome "ranking-star" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ranking star", "chart", "first place", "podium", "quality", "rank", "revenue", "win"])]
    [FontAwesomeCategories(["Humanitarian", "Marketing", "Sports + Fitness"])]
    RankingStar = 0xE561,

    /// <summary>
    /// The Font Awesome "receipt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["accounting", "bookkeeping", "check", "coupon", "evidence", "invoice", "money", "pay", "proof", "receipt", "table"])]
    [FontAwesomeCategories(["Medical + Health", "Money", "Shopping"])]
    Receipt = 0xF543,

    /// <summary>
    /// The Font Awesome "record-vinyl" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["record vinyl", "lp", "album", "analog", "music", "phonograph", "sound"])]
    [FontAwesomeCategories(["Music + Audio"])]
    RecordVinyl = 0xF8D9,

    /// <summary>
    /// The Font Awesome "recycle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["recycling symbol for generic materials", "universal recycling symbol", "waste", "compost", "garbage", "recycle", "recycling symbol", "reuse", "trash"])]
    [FontAwesomeCategories(["Arrows", "Maps"])]
    Recycle = 0xF1B8,

    /// <summary>
    /// The Font Awesome "arrow-rotate-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow rotate right", "clockwise open circle arrow", "forward", "refresh", "reload", "renew", "repeat", "retry"])]
    [FontAwesomeCategories(["Arrows", "Media Playback", "Spinners"])]
    Redo = 0xF01E,

    /// <summary>
    /// The Font Awesome "rotate-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rotate right", "forward", "refresh", "reload", "renew", "repeat", "retry"])]
    [FontAwesomeCategories(["Arrows", "Media Playback", "Spinners"])]
    RedoAlt = 0xF2F9,

    /// <summary>
    /// The Font Awesome "registered" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["copyright", "mark", "r", "registered", "trademark"])]
    [FontAwesomeCategories(["Business"])]
    Registered = 0xF25D,

    /// <summary>
    /// The Font Awesome "text-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["text slash", "cancel", "disabled", "font", "format", "remove", "style", "text"])]
    [FontAwesomeCategories(["Text Formatting"])]
    RemoveFormat = 0xF87D,

    /// <summary>
    /// The Font Awesome "repeat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow", "clockwise", "flip", "reload", "renew", "repeat", "repeat button", "retry", "rewind", "switch"])]
    [FontAwesomeCategories(["Arrows", "Media Playback"])]
    Repeat = 0xF363,

    /// <summary>
    /// The Font Awesome "reply" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["reply", "mail", "message", "respond"])]
    [FontAwesomeCategories(["Arrows"])]
    Reply = 0xF3E5,

    /// <summary>
    /// The Font Awesome "reply-all" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["reply all", "mail", "message", "respond"])]
    [FontAwesomeCategories(["Arrows"])]
    ReplyAll = 0xF122,

    /// <summary>
    /// The Font Awesome "republican" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["republican", "american", "conservative", "election", "elephant", "politics", "republican party", "right", "right-wing", "usa"])]
    [FontAwesomeCategories(["Political"])]
    Republican = 0xF75E,

    /// <summary>
    /// The Font Awesome "restroom" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["restroom", "bathroom", "toilet", "uer", "water closet", "wc"])]
    [FontAwesomeCategories(["Maps", "Users + People"])]
    Restroom = 0xF7BD,

    /// <summary>
    /// The Font Awesome "retweet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["retweet", "refresh", "reload", "renew", "retry", "share", "swap"])]
    [FontAwesomeCategories(["Arrows", "Social"])]
    Retweet = 0xF079,

    /// <summary>
    /// The Font Awesome "ribbon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["badge", "cause", "celebration", "lapel", "pin", "reminder", "reminder ribbon", "ribbon"])]
    [FontAwesomeCategories(["Charity"])]
    Ribbon = 0xF4D6,

    /// <summary>
    /// The Font Awesome "ring" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ring", "dungeons & dragons", "gollum", "band", "binding", "d&d", "dnd", "engagement", "fantasy", "gold", "jewelry", "marriage", "precious", "premium"])]
    [FontAwesomeCategories(["Gaming", "Spinners"])]
    Ring = 0xF70B,

    /// <summary>
    /// The Font Awesome "road" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["highway", "map", "motorway", "pavement", "road", "route", "street", "travel"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maps", "Transportation"])]
    Road = 0xF018,

    /// <summary>
    /// The Font Awesome "road-barrier" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["road barrier", "block", "border", "no entry", "roadblock"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Transportation"])]
    RoadBarrier = 0xE562,

    /// <summary>
    /// The Font Awesome "road-bridge" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["road bridge", "bridge", "infrastructure", "road", "travel"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    RoadBridge = 0xE563,

    /// <summary>
    /// The Font Awesome "road-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["road circle check", "enable", "freeway", "highway", "not affected", "ok", "okay", "pavement", "road", "validate", "working"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    RoadCircleCheck = 0xE564,

    /// <summary>
    /// The Font Awesome "road-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["road circle exclamation", "affected", "failed", "freeway", "highway", "pavement", "road"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    RoadCircleExclamation = 0xE565,

    /// <summary>
    /// The Font Awesome "road-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["road circle xmark", "destroy", "freeway", "highway", "pavement", "road", "uncheck"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    RoadCircleXmark = 0xE566,

    /// <summary>
    /// The Font Awesome "road-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["road lock", "closed", "freeway", "highway", "lockdown", "padlock", "pavement", "privacy", "quarantine", "road"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    RoadLock = 0xE567,

    /// <summary>
    /// The Font Awesome "road-spikes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["road spikes", "barrier", "roadblock", "spikes"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Transportation"])]
    RoadSpikes = 0xE568,

    /// <summary>
    /// The Font Awesome "robot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["android", "automate", "computer", "cyborg", "face", "monster", "robot"])]
    [FontAwesomeCategories(["Childhood", "Science Fiction"])]
    Robot = 0xF544,

    /// <summary>
    /// The Font Awesome "rocket" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rocket", "aircraft", "app", "jet", "launch", "nasa", "space"])]
    [FontAwesomeCategories(["Maps", "Science Fiction", "Transportation"])]
    Rocket = 0xF135,

    /// <summary>
    /// The Font Awesome "route" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["route", "directions", "navigation", "travel"])]
    [FontAwesomeCategories(["Camping", "Maps", "Moving"])]
    Route = 0xF4D7,

    /// <summary>
    /// The Font Awesome "rss" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rss", "blog", "feed", "journal", "news", "writing"])]
    [FontAwesomeCategories(["Connectivity", "Media Playback"])]
    Rss = 0xF09E,

    /// <summary>
    /// The Font Awesome "square-rss" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square rss", "blog", "feed", "journal", "news", "writing"])]
    [FontAwesomeCategories(["Communication", "Film + Video"])]
    RssSquare = 0xF143,

    /// <summary>
    /// The Font Awesome "ruble-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ruble sign", "ruble sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    RubleSign = 0xF158,

    /// <summary>
    /// The Font Awesome "rug" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["blanket", "carpet", "rug", "textile"])]
    [FontAwesomeCategories(["Household", "Humanitarian"])]
    Rug = 0xE569,

    /// <summary>
    /// The Font Awesome "ruler" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["design", "draft", "length", "measure", "planning", "ruler", "straight edge", "straight ruler"])]
    [FontAwesomeCategories(["Construction"])]
    Ruler = 0xF545,

    /// <summary>
    /// The Font Awesome "ruler-combined" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ruler combined", "design", "draft", "length", "measure", "planning"])]
    [FontAwesomeCategories(["Construction", "Design"])]
    RulerCombined = 0xF546,

    /// <summary>
    /// The Font Awesome "ruler-horizontal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ruler horizontal", "design", "draft", "length", "measure", "planning"])]
    [FontAwesomeCategories(["Construction", "Design"])]
    RulerHorizontal = 0xF547,

    /// <summary>
    /// The Font Awesome "ruler-vertical" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ruler vertical", "design", "draft", "length", "measure", "planning"])]
    [FontAwesomeCategories(["Construction", "Design"])]
    RulerVertical = 0xF548,

    /// <summary>
    /// The Font Awesome "person-running" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person running", "exit", "flee", "follow", "marathon", "person running", "race", "running", "uer", "workout"])]
    [FontAwesomeCategories(["Sports + Fitness", "Users + People"])]
    Running = 0xF70C,

    /// <summary>
    /// The Font Awesome "rupee-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rupee sign", "rupee sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    RupeeSign = 0xF156,

    /// <summary>
    /// The Font Awesome "rupiah-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rupiah sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    RupiahSign = 0xE23D,

    /// <summary>
    /// The Font Awesome "sack-dollar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sack dollar", "bag", "burlap", "cash", "dollar", "investment", "money", "money bag", "moneybag", "premium", "robber", "salary", "santa", "usd"])]
    [FontAwesomeCategories(["Humanitarian", "Money"])]
    SackDollar = 0xF81D,

    /// <summary>
    /// The Font Awesome "sack-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sack xmark", "bag", "burlap", "coupon", "rations", "salary", "uncheck"])]
    [FontAwesomeCategories(["Humanitarian", "Money"])]
    SackXmark = 0xE56A,

    /// <summary>
    /// The Font Awesome "face-sad-cry" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face sad cry", "cry", "emoticon", "face", "loudly crying face", "sad", "sob", "tear", "tears"])]
    [FontAwesomeCategories(["Emoji"])]
    SadCry = 0xF5B3,

    /// <summary>
    /// The Font Awesome "face-sad-tear" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face sad tear", "cry", "crying face", "emoticon", "face", "sad", "tear", "tears"])]
    [FontAwesomeCategories(["Emoji"])]
    SadTear = 0xF5B4,

    /// <summary>
    /// The Font Awesome "sailboat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dinghy", "mast", "sailboat", "sailing", "yacht"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maritime", "Transportation"])]
    Sailboat = 0xE445,

    /// <summary>
    /// The Font Awesome "satellite" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["communications", "hardware", "orbit", "satellite", "space"])]
    [FontAwesomeCategories(["Astronomy", "Devices + Hardware"])]
    Satellite = 0xF7BF,

    /// <summary>
    /// The Font Awesome "satellite-dish" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["satellite dish", "seti", "antenna", "communications", "dish", "hardware", "radar", "receiver", "satellite", "satellite antenna", "saucer", "signal", "space"])]
    [FontAwesomeCategories(["Astronomy", "Connectivity", "Devices + Hardware", "Humanitarian"])]
    SatelliteDish = 0xF7C0,

    /// <summary>
    /// The Font Awesome "floppy-disk" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["floppy disk", "black hard shell floppy disk", "computer", "disk", "download", "floppy", "floppy disk", "floppy-o"])]
    [FontAwesomeCategories(["Business", "Design", "Devices + Hardware", "Files"])]
    Save = 0xF0C7,

    /// <summary>
    /// The Font Awesome "school" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building", "education", "learn", "school", "student", "teacher"])]
    [FontAwesomeCategories(["Buildings", "Childhood", "Education", "Humanitarian"])]
    School = 0xF549,

    /// <summary>
    /// The Font Awesome "school-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["school circle check", "enable", "not affected", "ok", "okay", "schoolhouse", "validate", "working"])]
    [FontAwesomeCategories(["Buildings", "Education", "Humanitarian"])]
    SchoolCircleCheck = 0xE56B,

    /// <summary>
    /// The Font Awesome "school-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["school circle exclamation", "affected", "failed", "schoolhouse"])]
    [FontAwesomeCategories(["Buildings", "Education", "Humanitarian"])]
    SchoolCircleExclamation = 0xE56C,

    /// <summary>
    /// The Font Awesome "school-circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["school circle xmark", "destroy", "schoolhouse", "uncheck"])]
    [FontAwesomeCategories(["Buildings", "Education", "Humanitarian"])]
    SchoolCircleXmark = 0xE56D,

    /// <summary>
    /// The Font Awesome "school-flag" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["school flag", "educate", "flag", "school", "schoolhouse"])]
    [FontAwesomeCategories(["Buildings", "Education", "Humanitarian"])]
    SchoolFlag = 0xE56E,

    /// <summary>
    /// The Font Awesome "school-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["school lock", "closed", "lockdown", "padlock", "privacy", "quarantine", "schoolhouse"])]
    [FontAwesomeCategories(["Buildings", "Education", "Humanitarian"])]
    SchoolLock = 0xE56F,

    /// <summary>
    /// The Font Awesome "screwdriver" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["admin", "configuration", "equipment", "fix", "maintenance", "mechanic", "modify", "repair", "screw", "screwdriver", "settings", "tool"])]
    [FontAwesomeCategories(["Construction"])]
    Screwdriver = 0xF54A,

    /// <summary>
    /// The Font Awesome "scroll" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dungeons & dragons", "announcement", "d&d", "dnd", "fantasy", "paper", "scholar", "script", "scroll"])]
    [FontAwesomeCategories(["Gaming"])]
    Scroll = 0xF70E,

    /// <summary>
    /// The Font Awesome "sd-card" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sd card", "image", "img", "memory", "photo", "save"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    SdCard = 0xF7C2,

    /// <summary>
    /// The Font Awesome "magnifying-glass" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["magnifying glass", "bigger", "enlarge", "equipment", "find", "glass", "inspection", "magnifier", "magnify", "magnifying", "magnifying glass tilted left", "preview", "search", "tool", "zoom"])]
    [FontAwesomeCategories(["Maps"])]
    Search = 0xF002,

    /// <summary>
    /// The Font Awesome "magnifying-glass-dollar" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["magnifying glass dollar", "bigger", "enlarge", "find", "magnifier", "magnify", "money", "preview", "zoom"])]
    [FontAwesomeCategories(["Marketing"])]
    SearchDollar = 0xF688,

    /// <summary>
    /// The Font Awesome "magnifying-glass-location" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["magnifying glass location", "bigger", "enlarge", "find", "magnifier", "magnify", "preview", "zoom"])]
    [FontAwesomeCategories(["Maps", "Marketing"])]
    SearchLocation = 0xF689,

    /// <summary>
    /// The Font Awesome "magnifying-glass-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["magnifying glass minus", "magnifier", "minify", "negative", "smaller", "zoom", "zoom out"])]
    [FontAwesomeCategories(["Maps"])]
    SearchMinus = 0xF010,

    /// <summary>
    /// The Font Awesome "magnifying-glass-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["magnifying glass plus", "bigger", "enlarge", "magnifier", "magnify", "positive", "zoom", "zoom in"])]
    [FontAwesomeCategories(["Maps"])]
    SearchPlus = 0xF00E,

    /// <summary>
    /// The Font Awesome "section" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["section", "section sign", "law", "legal", "silcrow"])]
    [FontAwesomeCategories(["Punctuation + Symbols"])]
    Section = 0xE447,

    /// <summary>
    /// The Font Awesome "seedling" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["environment", "flora", "grow", "investment", "plant", "sapling", "seedling", "vegan", "young"])]
    [FontAwesomeCategories(["Charity", "Energy", "Food + Beverage", "Fruits + Vegetables", "Humanitarian", "Nature", "Science"])]
    Seedling = 0xF4D8,

    /// <summary>
    /// The Font Awesome "septagon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["septagon", "7", "heptagon", "seven", "shape"])]
    [FontAwesomeCategories(["Shapes"])]
    Septagon = 0xE820,

    /// <summary>
    /// The Font Awesome "server" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["server", "computer", "cpu", "database", "hardware", "mysql", "network", "sql"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    Server = 0xF233,

    /// <summary>
    /// The Font Awesome "shapes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shapes", "blocks", "build", "circle", "square", "triangle"])]
    [FontAwesomeCategories(["Childhood", "Education", "Shapes"])]
    Shapes = 0xF61F,

    /// <summary>
    /// The Font Awesome "share" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["share", "forward", "save", "send", "social"])]
    [FontAwesomeCategories(["Arrows", "Social"])]
    Share = 0xF064,

    /// <summary>
    /// The Font Awesome "share-nodes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["share nodes", "forward", "save", "send", "social"])]
    [FontAwesomeCategories(["Social"])]
    ShareAlt = 0xF1E0,

    /// <summary>
    /// The Font Awesome "square-share-nodes" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square share nodes", "forward", "save", "send", "social"])]
    [FontAwesomeCategories(["Social"])]
    ShareAltSquare = 0xF1E1,

    /// <summary>
    /// The Font Awesome "share-from-square" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["share from square", "forward", "save", "send", "social"])]
    [FontAwesomeCategories(["Arrows", "Social"])]
    ShareSquare = 0xF14D,

    /// <summary>
    /// The Font Awesome "sheet-plastic" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sheet plastic", "plastic", "plastic wrap", "protect", "tarp", "tarpaulin", "waterproof"])]
    [FontAwesomeCategories(["Construction", "Household", "Humanitarian"])]
    SheetPlastic = 0xE571,

    /// <summary>
    /// The Font Awesome "shekel-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shekel sign", "new sheqel sign", "currency", "ils", "money"])]
    [FontAwesomeCategories(["Money"])]
    ShekelSign = 0xF20B,

    /// <summary>
    /// The Font Awesome "shield" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["achievement", "armor", "award", "block", "cleric", "defend", "defense", "holy", "paladin", "protect", "safety", "security", "shield", "weapon", "winner"])]
    [FontAwesomeCategories(["Coding", "Security", "Shapes"])]
    Shield = 0xF132,

    /// <summary>
    /// The Font Awesome "shield-halved" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shield halved", "achievement", "armor", "award", "block", "cleric", "defend", "defense", "holy", "paladin", "privacy", "security", "shield", "weapon", "winner"])]
    [FontAwesomeCategories(["Coding", "Gaming", "Security"])]
    ShieldAlt = 0xF3ED,

    /// <summary>
    /// The Font Awesome "shield-cat" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shield cat", "animal", "feline", "pet", "protect", "safety", "veterinary"])]
    [FontAwesomeCategories(["Animals", "Humanitarian", "Security"])]
    ShieldCat = 0xE572,

    /// <summary>
    /// The Font Awesome "shield-dog" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shield dog", "animal", "canine", "pet", "protect", "safety", "veterinary"])]
    [FontAwesomeCategories(["Animals", "Humanitarian", "Security"])]
    ShieldDog = 0xE573,

    /// <summary>
    /// The Font Awesome "shield-heart" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shield heart", "love", "protect", "safe", "safety", "shield", "wishlist"])]
    [FontAwesomeCategories(["Humanitarian", "Security"])]
    ShieldHeart = 0xE574,

    /// <summary>
    /// The Font Awesome "shield-virus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shield virus", "antibodies", "barrier", "coronavirus", "covid-19", "flu", "health", "infection", "pandemic", "protect", "safety", "vaccine"])]
    [FontAwesomeCategories(["Medical + Health"])]
    ShieldVirus = 0xE06C,

    /// <summary>
    /// The Font Awesome "ship" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["boat", "passenger", "sea", "ship", "water"])]
    [FontAwesomeCategories(["Humanitarian", "Maps", "Maritime", "Transportation"])]
    Ship = 0xF21A,

    /// <summary>
    /// The Font Awesome "truck-fast" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck fast", "express", "fedex", "mail", "overnight", "package", "quick", "ups"])]
    [FontAwesomeCategories(["Logistics", "Shopping"])]
    ShippingFast = 0xF48B,

    /// <summary>
    /// The Font Awesome "shoe-prints" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shoe prints", "feet", "footprints", "steps", "walk"])]
    [FontAwesomeCategories(["Clothing + Fashion", "Maps", "Sports + Fitness"])]
    ShoePrints = 0xF54B,

    /// <summary>
    /// The Font Awesome "shop-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shop lock", "bodega", "building", "buy", "closed", "lock", "lockdown", "market", "padlock", "privacy", "purchase", "quarantine", "shop", "shopping", "store"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Shopping"])]
    ShopLock = 0xE4A5,

    /// <summary>
    /// The Font Awesome "bag-shopping" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bag shopping", "buy", "checkout", "grocery", "payment", "purchase"])]
    [FontAwesomeCategories(["Maps", "Shopping"])]
    ShoppingBag = 0xF290,

    /// <summary>
    /// The Font Awesome "basket-shopping" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["basket shopping", "buy", "checkout", "grocery", "payment", "purchase"])]
    [FontAwesomeCategories(["Maps", "Shopping"])]
    ShoppingBasket = 0xF291,

    /// <summary>
    /// The Font Awesome "cart-shopping" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cart shopping", "buy", "cart", "checkout", "grocery", "payment", "purchase", "shopping", "shopping cart", "trolley"])]
    [FontAwesomeCategories(["Maps", "Shopping", "Transportation"])]
    ShoppingCart = 0xF07A,

    /// <summary>
    /// The Font Awesome "shop-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shop slash", "building", "buy", "closed", "disabled", "purchase", "shopping"])]
    [FontAwesomeCategories(["Shopping"])]
    ShopSlash = 0xE070,

    /// <summary>
    /// The Font Awesome "shower" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bath", "clean", "faucet", "shower", "water"])]
    [FontAwesomeCategories(["Household", "Humanitarian", "Maps", "Travel + Hotel"])]
    Shower = 0xF2CC,

    /// <summary>
    /// The Font Awesome "shrimp" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["allergy", "crustacean", "prawn", "seafood", "shellfish", "shrimp", "tail"])]
    [FontAwesomeCategories(["Animals", "Food + Beverage", "Maritime"])]
    Shrimp = 0xE448,

    /// <summary>
    /// The Font Awesome "van-shuttle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["van shuttle", "airport", "bus", "minibus", "public-transportation", "transportation", "travel", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Transportation", "Travel + Hotel"])]
    ShuttleVan = 0xF5B6,

    /// <summary>
    /// The Font Awesome "sign-hanging" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sign hanging", "directions", "real estate", "signage", "wayfinding"])]
    [FontAwesomeCategories(["Moving"])]
    Sign = 0xF4D9,

    /// <summary>
    /// The Font Awesome "signal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["signal", "antenna", "antenna bars", "bar", "bars", "cell", "graph", "mobile", "online", "phone", "reception", "status"])]
    [FontAwesomeCategories(["Connectivity", "Toggle"])]
    Signal = 0xF012,

    /// <summary>
    /// The Font Awesome "signature" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["signature", "john hancock", "cursive", "name", "username", "writing"])]
    [FontAwesomeCategories(["Business", "Editing", "Writing"])]
    Signature = 0xF5B7,

    /// <summary>
    /// The Font Awesome "right-to-bracket" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["right to bracket", "arrow", "enter", "join", "log in", "login", "sign in", "sign up", "sign-in", "signin", "signup"])]
    [FontAwesomeCategories(["Arrows"])]
    SignInAlt = 0xF2F6,

    /// <summary>
    /// The Font Awesome "hands" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["translate", "asl", "deaf", "hands"])]
    [FontAwesomeCategories(["Accessibility"])]
    SignLanguage = 0xF2A7,

    /// <summary>
    /// The Font Awesome "right-from-bracket" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["right from bracket", "arrow", "exit", "leave", "log out", "logout", "sign-out"])]
    [FontAwesomeCategories(["Arrows"])]
    SignOutAlt = 0xF2F5,

    /// <summary>
    /// The Font Awesome "sim-card" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sim card", "hard drive", "hardware", "portable", "storage", "technology", "tiny"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    SimCard = 0xF7C4,

    /// <summary>
    /// The Font Awesome "single-quote-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["single quote left", "left single quotation mark", "mention", "note", "phrase", "text", "type"])]
    [FontAwesomeCategories(["Communication", "Punctuation + Symbols", "Writing"])]
    SingleQuoteLeft = 0xE81B,

    /// <summary>
    /// The Font Awesome "single-quote-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["single quote right", "mention", "note", "phrase", "right single quotation mark", "text", "type"])]
    [FontAwesomeCategories(["Communication", "Punctuation + Symbols", "Writing"])]
    SingleQuoteRight = 0xE81C,

    /// <summary>
    /// The Font Awesome "sink" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sink", "bathroom", "covid-19", "faucet", "kitchen", "wash"])]
    [FontAwesomeCategories(["Household"])]
    Sink = 0xE06D,

    /// <summary>
    /// The Font Awesome "sitemap" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sitemap", "directory", "hierarchy", "ia", "information architecture", "organization"])]
    [FontAwesomeCategories(["Business", "Coding"])]
    Sitemap = 0xF0E8,

    /// <summary>
    /// The Font Awesome "person-skating" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person skating", "figure skating", "ice", "olympics", "rink", "skate", "uer", "winter"])]
    [FontAwesomeCategories(["Sports + Fitness", "Users + People"])]
    Skating = 0xF7C5,

    /// <summary>
    /// The Font Awesome "person-skiing" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person skiing", "downhill", "olympics", "ski", "skier", "snow", "uer", "winter"])]
    [FontAwesomeCategories(["Sports + Fitness", "Users + People"])]
    Skiing = 0xF7C9,

    /// <summary>
    /// The Font Awesome "person-skiing-nordic" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person skiing nordic", "cross country", "olympics", "uer", "winter"])]
    [FontAwesomeCategories(["Sports + Fitness", "Users + People"])]
    SkiingNordic = 0xF7CA,

    /// <summary>
    /// The Font Awesome "skull" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bones", "death", "face", "fairy tale", "monster", "skeleton", "skull", "uer", "x-ray", "yorick"])]
    [FontAwesomeCategories(["Halloween", "Medical + Health", "Users + People"])]
    Skull = 0xF54C,

    /// <summary>
    /// The Font Awesome "skull-crossbones" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["skull crossbones", "black skull and crossbones", "dungeons & dragons", "alert", "bones", "crossbones", "d&d", "danger", "dangerous area", "dead", "deadly", "death", "dnd", "face", "fantasy", "halloween", "holiday", "jolly-roger", "monster", "pirate", "poison", "skeleton", "skull", "skull and crossbones", "warning"])]
    [FontAwesomeCategories(["Alert", "Gaming", "Halloween", "Humanitarian", "Medical + Health", "Science", "Security"])]
    SkullCrossbones = 0xF714,

    /// <summary>
    /// The Font Awesome "slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["slash", "cancel", "close", "mute", "off", "stop", "x"])]
    [FontAwesomeCategories(["Spinners"])]
    Slash = 0xF715,

    /// <summary>
    /// The Font Awesome "sleigh" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sleigh", "christmas", "claus", "fly", "holiday", "santa", "sled", "snow", "xmas"])]
    [FontAwesomeCategories(["Holidays", "Transportation"])]
    Sleigh = 0xF7CC,

    /// <summary>
    /// The Font Awesome "sliders" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["adjust", "configuration", "modify", "settings", "sliders", "toggle"])]
    [FontAwesomeCategories(["Editing", "Media Playback", "Music + Audio", "Photos + Images", "Toggle"])]
    SlidersH = 0xF1DE,

    /// <summary>
    /// The Font Awesome "face-smile" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face smile", "approve", "default", "emoticon", "face", "happy", "rating", "satisfied", "slightly smiling face", "smile", "uer"])]
    [FontAwesomeCategories(["Communication", "Emoji", "Users + People"])]
    Smile = 0xF118,

    /// <summary>
    /// The Font Awesome "face-smile-beam" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face smile beam", "blush", "emoticon", "eye", "face", "happy", "positive", "smile", "smiling face with smiling eyes"])]
    [FontAwesomeCategories(["Emoji"])]
    SmileBeam = 0xF5B8,

    /// <summary>
    /// The Font Awesome "face-smile-wink" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face smile wink", "emoticon", "face", "happy", "hint", "joke", "wink", "winking face"])]
    [FontAwesomeCategories(["Emoji"])]
    SmileWink = 0xF4DA,

    /// <summary>
    /// The Font Awesome "smog" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["smog", "dragon", "fog", "haze", "pollution", "smoke", "weather"])]
    [FontAwesomeCategories(["Weather"])]
    Smog = 0xF75F,

    /// <summary>
    /// The Font Awesome "smoking" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cancer", "cigarette", "nicotine", "smoking", "smoking status", "tobacco"])]
    [FontAwesomeCategories(["Medical + Health", "Travel + Hotel"])]
    Smoking = 0xF48D,

    /// <summary>
    /// The Font Awesome "ban-smoking" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ban smoking", "ban", "cancel", "circle", "deny", "disabled", "forbidden", "no", "no smoking", "non-smoking", "not", "prohibited", "slash", "smoking"])]
    [FontAwesomeCategories(["Medical + Health", "Travel + Hotel"])]
    SmokingBan = 0xF54D,

    /// <summary>
    /// The Font Awesome "comment-sms" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["comment sms", "answer", "chat", "conversation", "message", "mobile", "notification", "phone", "sms", "texting"])]
    [FontAwesomeCategories(["Communication"])]
    Sms = 0xF7CD,

    /// <summary>
    /// The Font Awesome "person-snowboarding" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person snowboarding", "olympics", "ski", "snow", "snowboard", "snowboarder", "uer", "winter"])]
    [FontAwesomeCategories(["Sports + Fitness", "Users + People"])]
    Snowboarding = 0xF7CE,

    /// <summary>
    /// The Font Awesome "snowflake" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["heavy chevron snowflake", "cold", "precipitation", "rain", "snow", "snowfall", "snowflake", "winter"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Household", "Humanitarian", "Spinners", "Travel + Hotel", "Weather"])]
    Snowflake = 0xF2DC,

    /// <summary>
    /// The Font Awesome "snowman" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cold", "decoration", "frost", "frosty", "holiday", "snow", "snowman", "snowman without snow"])]
    [FontAwesomeCategories(["Childhood", "Holidays"])]
    Snowman = 0xF7D0,

    /// <summary>
    /// The Font Awesome "snowplow" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["snowplow", "clean up", "cold", "road", "storm", "winter"])]
    [FontAwesomeCategories(["Maps", "Transportation"])]
    Snowplow = 0xF7D2,

    /// <summary>
    /// The Font Awesome "soap" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bar", "bathing", "bubbles", "clean", "cleaning", "covid-19", "hygiene", "lather", "soap", "soapdish", "wash"])]
    [FontAwesomeCategories(["Household", "Humanitarian"])]
    Soap = 0xE06E,

    /// <summary>
    /// The Font Awesome "socks" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["business socks", "business time", "clothing", "feet", "flight of the conchords", "socks", "stocking", "wednesday"])]
    [FontAwesomeCategories(["Business", "Clothing + Fashion"])]
    Socks = 0xF696,

    /// <summary>
    /// The Font Awesome "solar-panel" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["solar panel", "clean", "eco-friendly", "energy", "green", "sun"])]
    [FontAwesomeCategories(["Energy"])]
    SolarPanel = 0xF5BA,

    /// <summary>
    /// The Font Awesome "sort" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sort", "filter", "order"])]
    [FontAwesomeCategories(["Arrows"])]
    Sort = 0xF0DC,

    /// <summary>
    /// The Font Awesome "arrow-down-a-z" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down a z", "alphabetical", "arrange", "filter", "order", "sort-alpha-asc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortAlphaDown = 0xF15D,

    /// <summary>
    /// The Font Awesome "arrow-down-z-a" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down z a", "alphabetical", "arrange", "filter", "order", "sort-alpha-asc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortAlphaDownAlt = 0xF881,

    /// <summary>
    /// The Font Awesome "arrow-up-a-z" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up a z", "alphabetical", "arrange", "filter", "order", "sort-alpha-desc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortAlphaUp = 0xF15E,

    /// <summary>
    /// The Font Awesome "arrow-up-z-a" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up z a", "alphabetical", "arrange", "filter", "order", "sort-alpha-desc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortAlphaUpAlt = 0xF882,

    /// <summary>
    /// The Font Awesome "arrow-down-wide-short" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down wide short", "arrange", "filter", "number", "order", "sort-amount-asc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortAmountDown = 0xF160,

    /// <summary>
    /// The Font Awesome "arrow-down-short-wide" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down short wide", "arrange", "filter", "order", "sort-amount-asc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortAmountDownAlt = 0xF884,

    /// <summary>
    /// The Font Awesome "arrow-up-wide-short" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up wide short", "arrange", "filter", "order", "sort-amount-desc", "upgrade"])]
    [FontAwesomeCategories(["Arrows"])]
    SortAmountUp = 0xF161,

    /// <summary>
    /// The Font Awesome "arrow-up-short-wide" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up short wide", "arrange", "filter", "order", "sort-amount-desc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortAmountUpAlt = 0xF885,

    /// <summary>
    /// The Font Awesome "sort-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sort down", "arrow", "descending", "filter", "insert", "order", "sort-desc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortDown = 0xF0DD,

    /// <summary>
    /// The Font Awesome "arrow-down-1-9" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down 1 9", "arrange", "filter", "numbers", "order", "sort-numeric-asc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortNumericDown = 0xF162,

    /// <summary>
    /// The Font Awesome "arrow-down-9-1" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow down 9 1", "arrange", "filter", "numbers", "order", "sort-numeric-asc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortNumericDownAlt = 0xF886,

    /// <summary>
    /// The Font Awesome "arrow-up-1-9" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up 1 9", "arrange", "filter", "numbers", "order", "sort-numeric-desc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortNumericUp = 0xF163,

    /// <summary>
    /// The Font Awesome "arrow-up-9-1" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow up 9 1", "arrange", "filter", "numbers", "order", "sort-numeric-desc"])]
    [FontAwesomeCategories(["Arrows"])]
    SortNumericUpAlt = 0xF887,

    /// <summary>
    /// The Font Awesome "sort-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sort up", "arrow", "ascending", "filter", "order", "sort-asc", "upgrade"])]
    [FontAwesomeCategories(["Arrows"])]
    SortUp = 0xF0DE,

    /// <summary>
    /// The Font Awesome "spa" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["spa", "flora", "massage", "mindfulness", "plant", "wellness"])]
    [FontAwesomeCategories(["Sports + Fitness", "Travel + Hotel"])]
    Spa = 0xF5BB,

    /// <summary>
    /// The Font Awesome "shuttle-space" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shuttle space", "astronaut", "machine", "nasa", "rocket", "space", "transportation"])]
    [FontAwesomeCategories(["Astronomy", "Transportation"])]
    SpaceShuttle = 0xF197,

    /// <summary>
    /// The Font Awesome "spell-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["spell check", "dictionary", "edit", "editor", "enable", "grammar", "text", "validate", "working"])]
    [FontAwesomeCategories(["Text Formatting"])]
    SpellCheck = 0xF891,

    /// <summary>
    /// The Font Awesome "spider" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arachnid", "bug", "charlotte", "crawl", "eight", "halloween", "insect", "spider"])]
    [FontAwesomeCategories(["Animals", "Halloween", "Nature"])]
    Spider = 0xF717,

    /// <summary>
    /// The Font Awesome "spinner" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["spinner", "circle", "loading", "pending", "progress"])]
    [FontAwesomeCategories(["Spinners"])]
    Spinner = 0xF110,

    /// <summary>
    /// The Font Awesome "spiral" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["spiral", "design", "dizzy", "rotate", "spin", "swirl", "twist"])]
    [FontAwesomeCategories(["Design", "Shapes"])]
    Spiral = 0xE80A,

    /// <summary>
    /// The Font Awesome "splotch" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["splotch", "ink", "blob", "blotch", "glob", "stain"])]
    [FontAwesomeCategories(["Design"])]
    Splotch = 0xF5BC,

    /// <summary>
    /// The Font Awesome "spray-can" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["spray can", "paint", "aerosol", "design", "graffiti", "tag"])]
    [FontAwesomeCategories(["Design"])]
    SprayCan = 0xF5BD,

    /// <summary>
    /// The Font Awesome "square" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["black square", "black medium square", "block", "box", "geometric", "shape", "square", "white medium square"])]
    [FontAwesomeCategories(["Shapes"])]
    Square = 0xF0C8,

    /// <summary>
    /// The Font Awesome "square-arrow-up-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square arrow up right", "diagonal", "new", "open", "send", "share"])]
    [FontAwesomeCategories(["Arrows"])]
    SquareArrowUpRight = 0xF14C,

    /// <summary>
    /// The Font Awesome "square-binary" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square binary", "ai", "data", "language", "llm", "model", "programming", "token"])]
    [FontAwesomeCategories(["Coding", "Shapes"])]
    SquareBinary = 0xE69B,

    /// <summary>
    /// The Font Awesome "square-full" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square full", "black large square", "block", "blue", "blue square", "box", "brown", "brown square", "geometric", "green", "green square", "orange", "orange square", "purple", "purple square", "red", "red square", "shape", "square", "white large square", "yellow", "yellow square"])]
    [FontAwesomeCategories(["Gaming"])]
    SquareFull = 0xF45C,

    /// <summary>
    /// The Font Awesome "square-nfi" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square nfi", "non-food item", "supplies"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics"])]
    SquareNfi = 0xE576,

    /// <summary>
    /// The Font Awesome "square-person-confined" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square person confined", "captivity", "confined", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Security", "Users + People"])]
    SquarePersonConfined = 0xE577,

    /// <summary>
    /// The Font Awesome "square-root-variable" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square root variable", "arithmetic", "calculus", "division", "math"])]
    [FontAwesomeCategories(["Mathematics"])]
    SquareRootAlt = 0xF698,

    /// <summary>
    /// The Font Awesome "square-virus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square virus", "coronavirus", "covid-19", "disease", "flu", "infection", "pandemic"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health", "Science"])]
    SquareVirus = 0xE578,

    /// <summary>
    /// The Font Awesome "square-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["square xmark", "close", "cross", "cross mark button", "incorrect", "mark", "notice", "notification", "notify", "problem", "square", "uncheck", "window", "wrong", "x", "×"])]
    [FontAwesomeCategories(["Mathematics"])]
    SquareXmark = 0xF2D3,

    /// <summary>
    /// The Font Awesome "staff-snake" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["staff snake", "asclepius", "asklepian", "health", "serpent", "wellness"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    StaffSnake = 0xE579,

    /// <summary>
    /// The Font Awesome "stairs" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["stairs", "exit", "steps", "up"])]
    [FontAwesomeCategories(["Household", "Travel + Hotel"])]
    Stairs = 0xE289,

    /// <summary>
    /// The Font Awesome "stamp" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["stamp", "art", "certificate", "imprint", "rubber", "seal"])]
    [FontAwesomeCategories(["Design", "Money"])]
    Stamp = 0xF5BF,

    /// <summary>
    /// The Font Awesome "stapler" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["stapler", "desktop", "milton", "office", "paperclip", "staple"])]
    [FontAwesomeCategories(["Business", "Design"])]
    Stapler = 0xE5AF,

    /// <summary>
    /// The Font Awesome "star" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["achievement", "award", "favorite", "important", "night", "quality", "rating", "score", "star", "vip"])]
    [FontAwesomeCategories(["Shapes", "Shopping", "Social", "Toggle"])]
    Star = 0xF005,

    /// <summary>
    /// The Font Awesome "star-and-crescent" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["star and crescent", "muslim", "islam", "muslim", "religion", "star and crescent"])]
    [FontAwesomeCategories(["Religion"])]
    StarAndCrescent = 0xF699,

    /// <summary>
    /// The Font Awesome "star-half" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["star half", "achievement", "award", "rating", "score", "star-half-empty", "star-half-full"])]
    [FontAwesomeCategories(["Toggle"])]
    StarHalf = 0xF089,

    /// <summary>
    /// The Font Awesome "star-half-stroke" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["star half stroke", "achievement", "award", "rating", "score", "star-half-empty", "star-half-full"])]
    [FontAwesomeCategories(["Toggle"])]
    StarHalfAlt = 0xF5C0,

    /// <summary>
    /// The Font Awesome "star-of-david" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["star of david", "david", "jew", "jewish", "jewish", "judaism", "religion", "star", "star of david"])]
    [FontAwesomeCategories(["Religion"])]
    StarOfDavid = 0xF69A,

    /// <summary>
    /// The Font Awesome "star-of-life" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["star of life", "doctor", "emt", "first aid", "health", "medical"])]
    [FontAwesomeCategories(["Medical + Health"])]
    StarOfLife = 0xF621,

    /// <summary>
    /// The Font Awesome "backward-step" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["backward step", "beginning", "first", "previous", "rewind", "start"])]
    [FontAwesomeCategories(["Media Playback"])]
    StepBackward = 0xF048,

    /// <summary>
    /// The Font Awesome "forward-step" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["forward step", "end", "last", "next"])]
    [FontAwesomeCategories(["Media Playback"])]
    StepForward = 0xF051,

    /// <summary>
    /// The Font Awesome "stethoscope" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["covid-19", "diagnosis", "doctor", "general practitioner", "heart", "hospital", "infirmary", "medicine", "office", "outpatient", "stethoscope"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    Stethoscope = 0xF0F1,

    /// <summary>
    /// The Font Awesome "note-sticky" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["note sticky", "message", "note", "paper", "reminder", "sticker"])]
    [FontAwesomeCategories(["Business", "Files", "Writing"])]
    StickyNote = 0xF249,

    /// <summary>
    /// The Font Awesome "stop" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["block", "box", "square", "stop", "stop button"])]
    [FontAwesomeCategories(["Media Playback"])]
    Stop = 0xF04D,

    /// <summary>
    /// The Font Awesome "circle-stop" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle stop", "block", "box", "circle", "square"])]
    [FontAwesomeCategories(["Media Playback"])]
    StopCircle = 0xF28D,

    /// <summary>
    /// The Font Awesome "stopwatch" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clock", "reminder", "stopwatch", "time", "waiting"])]
    [FontAwesomeCategories(["Time"])]
    Stopwatch = 0xF2F2,

    /// <summary>
    /// The Font Awesome "stopwatch-20" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["stopwatch 20", "abcs", "countdown", "covid-19", "happy birthday", "i will survive", "reminder", "seconds", "time", "timer"])]
    [FontAwesomeCategories(["Sports + Fitness", "Time"])]
    Stopwatch20 = 0xE06F,

    /// <summary>
    /// The Font Awesome "store" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bodega", "building", "buy", "market", "purchase", "shopping", "store"])]
    [FontAwesomeCategories(["Buildings", "Shopping"])]
    Store = 0xF54E,

    /// <summary>
    /// The Font Awesome "shop" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["shop", "bodega", "building", "buy", "market", "purchase", "shopping", "store"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Shopping"])]
    StoreAlt = 0xF54F,

    /// <summary>
    /// The Font Awesome "store-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["store slash", "building", "buy", "closed", "disabled", "purchase", "shopping"])]
    [FontAwesomeCategories(["Shopping"])]
    StoreSlash = 0xE071,

    /// <summary>
    /// The Font Awesome "bars-staggered" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bars staggered", "flow", "list", "timeline"])]
    [FontAwesomeCategories(["Business", "Coding"])]
    Stream = 0xF550,

    /// <summary>
    /// The Font Awesome "street-view" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["street view", "directions", "location", "map", "navigation", "uer"])]
    [FontAwesomeCategories(["Maps", "Users + People"])]
    StreetView = 0xF21D,

    /// <summary>
    /// The Font Awesome "strikethrough" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["strikethrough", "cancel", "edit", "font", "format", "modify", "text", "type"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Strikethrough = 0xF0CC,

    /// <summary>
    /// The Font Awesome "stroopwafel" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["stroopwafel", "caramel", "cookie", "dessert", "sweets", "waffle"])]
    [FontAwesomeCategories(["Food + Beverage", "Spinners"])]
    Stroopwafel = 0xF551,

    /// <summary>
    /// The Font Awesome "subscript" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["subscript", "edit", "font", "format", "text", "type"])]
    [FontAwesomeCategories(["Mathematics", "Text Formatting"])]
    Subscript = 0xF12C,

    /// <summary>
    /// The Font Awesome "train-subway" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["train subway", "machine", "railway", "train", "transportation", "vehicle"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Maps", "Transportation"])]
    Subway = 0xF239,

    /// <summary>
    /// The Font Awesome "suitcase" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["baggage", "luggage", "move", "packing", "suitcase", "travel", "trip"])]
    [FontAwesomeCategories(["Maps", "Moving", "Travel + Hotel"])]
    Suitcase = 0xF0F2,

    /// <summary>
    /// The Font Awesome "suitcase-rolling" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["suitcase rolling", "baggage", "luggage", "move", "suitcase", "travel", "trip"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    SuitcaseRolling = 0xF5C1,

    /// <summary>
    /// The Font Awesome "sun" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bright", "brighten", "contrast", "day", "lighter", "rays", "sol", "solar", "star", "sun", "sunny", "weather"])]
    [FontAwesomeCategories(["Energy", "Spinners", "Weather"])]
    Sun = 0xF185,

    /// <summary>
    /// The Font Awesome "sun-plant-wilt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["sun plant wilt", "arid", "droop", "drought"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Weather"])]
    SunPlantWilt = 0xE57A,

    /// <summary>
    /// The Font Awesome "superscript" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["superscript", "edit", "exponential", "font", "format", "text", "type"])]
    [FontAwesomeCategories(["Mathematics", "Text Formatting"])]
    Superscript = 0xF12B,

    /// <summary>
    /// The Font Awesome "face-surprise" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face surprise", "emoticon", "face", "face with open mouth", "mouth", "open", "shocked", "sympathy"])]
    [FontAwesomeCategories(["Emoji"])]
    Surprise = 0xF5C2,

    /// <summary>
    /// The Font Awesome "swatchbook" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["swatchbook", "pantone", "color", "design", "hue", "palette"])]
    [FontAwesomeCategories(["Design"])]
    Swatchbook = 0xF5C3,

    /// <summary>
    /// The Font Awesome "person-swimming" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person swimming", "ocean", "person swimming", "pool", "sea", "swim", "uer", "water"])]
    [FontAwesomeCategories(["Maritime", "Sports + Fitness", "Travel + Hotel", "Users + People"])]
    Swimmer = 0xF5C4,

    /// <summary>
    /// The Font Awesome "water-ladder" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["water ladder", "ladder", "recreation", "swim", "water"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    SwimmingPool = 0xF5C5,

    /// <summary>
    /// The Font Awesome "synagogue" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["jew", "jewish", "building", "jewish", "judaism", "religion", "star of david", "synagogue", "temple"])]
    [FontAwesomeCategories(["Buildings", "Religion"])]
    Synagogue = 0xF69B,

    /// <summary>
    /// The Font Awesome "arrows-rotate" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrows rotate", "clockwise right and left semicircle arrows", "clockwise", "exchange", "modify", "refresh", "reload", "renew", "retry", "rotate", "swap"])]
    [FontAwesomeCategories(["Arrows", "Editing", "Media Playback", "Spinners"])]
    Sync = 0xF021,

    /// <summary>
    /// The Font Awesome "rotate" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow", "clockwise", "exchange", "modify", "refresh", "reload", "renew", "retry", "rotate", "swap", "withershins"])]
    [FontAwesomeCategories(["Arrows", "Editing", "Media Playback", "Spinners"])]
    SyncAlt = 0xF2F1,

    /// <summary>
    /// The Font Awesome "syringe" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["covid-19", "doctor", "immunizations", "medical", "medicine", "needle", "shot", "sick", "syringe", "vaccinate", "vaccine"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health", "Science"])]
    Syringe = 0xF48E,

    /// <summary>
    /// The Font Awesome "table" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table", "category", "data", "excel", "spreadsheet"])]
    [FontAwesomeCategories(["Business", "Text Formatting"])]
    Table = 0xF0CE,

    /// <summary>
    /// The Font Awesome "table-cells-column-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table cells column lock", "blocks", "boxes", "category", "column", "excel", "grid", "lock", "spreadsheet", "squares"])]
    [FontAwesomeCategories(["Text Formatting"])]
    TableCellsColumnLock = 0xE678,

    /// <summary>
    /// The Font Awesome "table-cells-row-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table cells row lock", "blocks", "boxes", "category", "column", "column", "excel", "grid", "lock", "lock", "spreadsheet", "squares"])]
    [FontAwesomeCategories(["Text Formatting"])]
    TableCellsRowLock = 0xE67A,

    /// <summary>
    /// The Font Awesome "table-cells-row-unlock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table cells row unlock", "blocks", "boxes", "category", "column", "column", "excel", "grid", "lock", "lock", "spreadsheet", "squares", "unlock"])]
    [FontAwesomeCategories(["Text Formatting"])]
    TableCellsRowUnlock = 0xE691,

    /// <summary>
    /// The Font Awesome "tablet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tablet", "device", "kindle", "screen"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    Tablet = 0xF3FB,

    /// <summary>
    /// The Font Awesome "tablet-screen-button" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tablet screen button", "apple", "device", "ipad", "kindle", "screen"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    TabletAlt = 0xF3FA,

    /// <summary>
    /// The Font Awesome "tablet-button" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tablet button", "apple", "device", "ipad", "kindle", "screen"])]
    [FontAwesomeCategories(["Devices + Hardware"])]
    TabletButton = 0xF10A,

    /// <summary>
    /// The Font Awesome "table-tennis-paddle-ball" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table tennis paddle ball", "ball", "bat", "game", "paddle", "ping pong", "table tennis"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    TableTennis = 0xF45D,

    /// <summary>
    /// The Font Awesome "tablets" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tablets", "drugs", "medicine", "pills", "prescription"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    Tablets = 0xF490,

    /// <summary>
    /// The Font Awesome "gauge-high" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF625.
    /// </summary>
    [FontAwesomeSearchTerms(["gauge high", "dashboard", "fast", "odometer", "quick", "speed", "speedometer"])]
    [FontAwesomeCategories(["Automotive"])]
    TachometerAlt = 0xF3FD,

    /// <summary>
    /// The Font Awesome "tag" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tag", "discount", "labe", "label", "price", "shopping"])]
    [FontAwesomeCategories(["Business", "Maps", "Shopping"])]
    Tag = 0xF02B,

    /// <summary>
    /// The Font Awesome "tags" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tags", "discount", "label", "price", "shopping"])]
    [FontAwesomeCategories(["Business", "Maps", "Shopping"])]
    Tags = 0xF02C,

    /// <summary>
    /// The Font Awesome "tape" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tape", "design", "package", "sticky"])]
    [FontAwesomeCategories(["Moving"])]
    Tape = 0xF4DB,

    /// <summary>
    /// The Font Awesome "tarp" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["protection", "tarp", "tent", "waterproof"])]
    [FontAwesomeCategories(["Camping", "Construction", "Humanitarian"])]
    Tarp = 0xE57B,

    /// <summary>
    /// The Font Awesome "tarp-droplet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tarp droplet", "protection", "tarp", "tent", "waterproof"])]
    [FontAwesomeCategories(["Camping", "Construction", "Humanitarian"])]
    TarpDroplet = 0xE57C,

    /// <summary>
    /// The Font Awesome "list-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["list check", "bullet", "cheatsheet", "checklist", "downloading", "downloads", "enable", "loading", "progress", "project management", "settings", "summary", "to do", "validate", "working"])]
    [FontAwesomeCategories(["Business", "Text Formatting"])]
    Tasks = 0xF0AE,

    /// <summary>
    /// The Font Awesome "taxi" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cab", "cabbie", "car", "car service", "lyft", "machine", "oncoming", "oncoming taxi", "taxi", "transportation", "travel", "uber", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Maps", "Transportation", "Travel + Hotel"])]
    Taxi = 0xF1BA,

    /// <summary>
    /// The Font Awesome "teeth" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["teeth", "bite", "dental", "dentist", "gums", "mouth", "smile", "tooth"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Teeth = 0xF62E,

    /// <summary>
    /// The Font Awesome "teeth-open" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["teeth open", "dental", "dentist", "gums bite", "mouth", "smile", "tooth"])]
    [FontAwesomeCategories(["Medical + Health"])]
    TeethOpen = 0xF62F,

    /// <summary>
    /// The Font Awesome "temperature-arrow-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature arrow down", "air conditioner", "cold", "heater", "mercury", "thermometer", "winter"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Household", "Humanitarian", "Weather"])]
    TemperatureArrowDown = 0xE03F,

    /// <summary>
    /// The Font Awesome "temperature-arrow-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature arrow up", "air conditioner", "cold", "heater", "mercury", "thermometer", "winter"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Household", "Humanitarian", "Weather"])]
    TemperatureArrowUp = 0xE040,

    /// <summary>
    /// The Font Awesome "temperature-high" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature high", "cook", "covid-19", "mercury", "summer", "thermometer", "warm"])]
    [FontAwesomeCategories(["Science", "Weather"])]
    TemperatureHigh = 0xF769,

    /// <summary>
    /// The Font Awesome "temperature-low" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature low", "cold", "cool", "covid-19", "mercury", "thermometer", "winter"])]
    [FontAwesomeCategories(["Science", "Weather"])]
    TemperatureLow = 0xF76B,

    /// <summary>
    /// The Font Awesome "tenge-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tenge sign", "tenge sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    Tenge = 0xF7D7,

    /// <summary>
    /// The Font Awesome "tent" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bivouac", "campground", "campsite", "refugee", "shelter", "tent"])]
    [FontAwesomeCategories(["Buildings", "Camping", "Humanitarian"])]
    Tent = 0xE57D,

    /// <summary>
    /// The Font Awesome "tent-arrow-down-to-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tent arrow down to line", "bivouac", "campground", "campsite", "permanent", "refugee", "refugee", "shelter", "shelter", "tent"])]
    [FontAwesomeCategories(["Buildings", "Camping", "Humanitarian"])]
    TentArrowDownToLine = 0xE57E,

    /// <summary>
    /// The Font Awesome "tent-arrow-left-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tent arrow left right", "bivouac", "campground", "campsite", "refugee", "refugee", "shelter", "shelter", "tent", "transition"])]
    [FontAwesomeCategories(["Buildings", "Camping", "Humanitarian"])]
    TentArrowLeftRight = 0xE57F,

    /// <summary>
    /// The Font Awesome "tent-arrows-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tent arrows down", "bivouac", "campground", "campsite", "insert", "refugee", "refugee", "shelter", "shelter", "spontaneous", "tent"])]
    [FontAwesomeCategories(["Buildings", "Camping", "Humanitarian"])]
    TentArrowsDown = 0xE581,

    /// <summary>
    /// The Font Awesome "tent-arrow-turn-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tent arrow turn left", "bivouac", "campground", "campsite", "refugee", "refugee", "shelter", "shelter", "temporary", "tent"])]
    [FontAwesomeCategories(["Buildings", "Camping", "Humanitarian"])]
    TentArrowTurnLeft = 0xE580,

    /// <summary>
    /// The Font Awesome "tents" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tents", "bivouac", "bivouac", "campground", "campground", "campsite", "refugee", "refugee", "shelter", "shelter", "tent", "tent"])]
    [FontAwesomeCategories(["Buildings", "Camping", "Humanitarian"])]
    Tents = 0xE582,

    /// <summary>
    /// The Font Awesome "terminal" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["code", "coding", "command", "console", "development", "prompt", "terminal"])]
    [FontAwesomeCategories(["Coding"])]
    Terminal = 0xF120,

    /// <summary>
    /// The Font Awesome "text-height" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["text height", "edit", "font", "format", "modify", "text", "type"])]
    [FontAwesomeCategories(["Text Formatting"])]
    TextHeight = 0xF034,

    /// <summary>
    /// The Font Awesome "text-width" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["text width", "edit", "font", "format", "modify", "text", "type"])]
    [FontAwesomeCategories(["Text Formatting"])]
    TextWidth = 0xF035,

    /// <summary>
    /// The Font Awesome "table-cells" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table cells", "blocks", "boxes", "category", "excel", "grid", "spreadsheet", "squares"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Th = 0xF00A,

    /// <summary>
    /// The Font Awesome "masks-theater" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["masks theater", "art", "comedy", "mask", "perform", "performing", "performing arts", "theater", "theatre", "tragedy"])]
    [FontAwesomeCategories(["Education"])]
    TheaterMasks = 0xF630,

    /// <summary>
    /// The Font Awesome "thermometer" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["thermometer", "covid-19", "mercury", "status", "temperature"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Thermometer = 0xF491,

    /// <summary>
    /// The Font Awesome "temperature-empty" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature empty", "cold", "mercury", "status", "temperature"])]
    [FontAwesomeCategories(["Weather"])]
    ThermometerEmpty = 0xF2CB,

    /// <summary>
    /// The Font Awesome "temperature-full" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature full", "fever", "hot", "mercury", "status", "temperature"])]
    [FontAwesomeCategories(["Weather"])]
    ThermometerFull = 0xF2C7,

    /// <summary>
    /// The Font Awesome "temperature-half" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature half", "mercury", "status", "temperature", "thermometer", "weather"])]
    [FontAwesomeCategories(["Weather"])]
    ThermometerHalf = 0xF2C9,

    /// <summary>
    /// The Font Awesome "temperature-quarter" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature quarter", "mercury", "status", "temperature"])]
    [FontAwesomeCategories(["Weather"])]
    ThermometerQuarter = 0xF2CA,

    /// <summary>
    /// The Font Awesome "temperature-three-quarters" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["temperature three quarters", "mercury", "status", "temperature"])]
    [FontAwesomeCategories(["Weather"])]
    ThermometerThreeQuarters = 0xF2C8,

    /// <summary>
    /// The Font Awesome "table-cells-large" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table cells large", "blocks", "boxes", "category", "excel", "grid", "spreadsheet", "squares"])]
    [FontAwesomeCategories(["Text Formatting"])]
    ThLarge = 0xF009,

    /// <summary>
    /// The Font Awesome "table-list" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["table list", "category", "cheatsheet", "checklist", "completed", "done", "finished", "ol", "summary", "todo", "ul"])]
    [FontAwesomeCategories(["Text Formatting"])]
    ThList = 0xF00B,

    /// <summary>
    /// The Font Awesome "thumbs-down" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["thumbs down", "-1", "disagree", "disapprove", "dislike", "down", "hand", "social", "thumb", "thumbs down", "thumbs-o-down"])]
    [FontAwesomeCategories(["Hands", "Shopping", "Social"])]
    ThumbsDown = 0xF165,

    /// <summary>
    /// The Font Awesome "thumbs-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["thumbs up", "+1", "agree", "approve", "favorite", "hand", "like", "ok", "okay", "social", "success", "thumb", "thumbs up", "thumbs-o-up", "up", "yes", "you got it dude"])]
    [FontAwesomeCategories(["Hands", "Shopping", "Social"])]
    ThumbsUp = 0xF164,

    /// <summary>
    /// The Font Awesome "thumbtack" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["thumbtack", "black pushpin", "coordinates", "location", "marker", "pin", "pushpin", "thumb-tack"])]
    [FontAwesomeCategories(["Business", "Maps", "Social", "Writing"])]
    Thumbtack = 0xF08D,

    /// <summary>
    /// The Font Awesome "thumbtack-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["thumbtack slash", "black pushpin", "coordinates", "location", "marker", "pin", "pushpin", "thumb-tack", "unpin"])]
    [FontAwesomeCategories(["Business", "Maps", "Social", "Writing"])]
    ThumbtackSlash = 0xE68F,

    /// <summary>
    /// The Font Awesome "ticket" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["admission", "admission tickets", "coupon", "movie", "pass", "support", "ticket", "voucher"])]
    [FontAwesomeCategories(["Film + Video", "Maps"])]
    Ticket = 0xF145,

    /// <summary>
    /// The Font Awesome "ticket-simple" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ticket simple", "admission", "coupon", "movie", "pass", "support", "ticket", "voucher"])]
    [FontAwesomeCategories(["Maps", "Shapes"])]
    TicketAlt = 0xF3FF,

    /// <summary>
    /// The Font Awesome "timeline" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["timeline", "chronological", "deadline", "history", "linear"])]
    [FontAwesomeCategories(["Business", "Marketing"])]
    Timeline = 0xE29C,

    /// <summary>
    /// The Font Awesome "xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["xmark", "cancellation x", "multiplication sign", "multiplication x", "cancel", "close", "cross", "cross mark", "error", "exit", "incorrect", "mark", "multiplication", "multiply", "notice", "notification", "notify", "problem", "sign", "uncheck", "wrong", "x", "×"])]
    [FontAwesomeCategories(["Editing", "Mathematics"])]
    Times = 0xF00D,

    /// <summary>
    /// The Font Awesome "circle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle xmark", "close", "cross", "destroy", "exit", "incorrect", "notice", "notification", "notify", "problem", "uncheck", "wrong", "x"])]
    [FontAwesomeCategories(["Mathematics"])]
    TimesCircle = 0xF057,

    /// <summary>
    /// The Font Awesome "droplet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["blood", "cold", "color", "comic", "drop", "droplet", "raindrop", "sweat", "waterdrop"])]
    [FontAwesomeCategories(["Design", "Humanitarian", "Maps", "Medical + Health", "Photos + Images"])]
    Tint = 0xF043,

    /// <summary>
    /// The Font Awesome "droplet-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["droplet slash", "blood", "color", "disabled", "drop", "droplet", "raindrop", "waterdrop"])]
    [FontAwesomeCategories(["Design", "Medical + Health"])]
    TintSlash = 0xF5C7,

    /// <summary>
    /// The Font Awesome "face-tired" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["face tired", "angry", "emoticon", "face", "grumpy", "tired", "tired face", "upset"])]
    [FontAwesomeCategories(["Emoji"])]
    Tired = 0xF5C8,

    /// <summary>
    /// The Font Awesome "toggle-off" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["toggle off", "button", "off", "on", "switch"])]
    [FontAwesomeCategories(["Toggle"])]
    ToggleOff = 0xF204,

    /// <summary>
    /// The Font Awesome "toggle-on" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["toggle on", "button", "off", "on", "switch"])]
    [FontAwesomeCategories(["Toggle"])]
    ToggleOn = 0xF205,

    /// <summary>
    /// The Font Awesome "toilet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bathroom", "flush", "john", "loo", "pee", "plumbing", "poop", "porcelain", "potty", "restroom", "throne", "toile", "toilet", "washroom", "waste", "wc"])]
    [FontAwesomeCategories(["Household", "Humanitarian", "Travel + Hotel"])]
    Toilet = 0xF7D8,

    /// <summary>
    /// The Font Awesome "toilet-paper" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["toilet paper", "bathroom", "covid-19", "halloween", "holiday", "lavatory", "paper towels", "prank", "privy", "restroom", "roll", "roll of paper", "toilet", "toilet paper", "wipe"])]
    [FontAwesomeCategories(["Camping", "Halloween", "Household", "Travel + Hotel"])]
    ToiletPaper = 0xF71E,

    /// <summary>
    /// The Font Awesome "toilet-paper-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["toilet paper slash", "bathroom", "covid-19", "disabled", "halloween", "holiday", "lavatory", "leaves", "prank", "privy", "restroom", "roll", "toilet", "trouble", "ut oh", "wipe"])]
    [FontAwesomeCategories(["Household"])]
    ToiletPaperSlash = 0xE072,

    /// <summary>
    /// The Font Awesome "toilet-portable" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["toilet portable", "outhouse", "toilet"])]
    [FontAwesomeCategories(["Buildings", "Construction", "Humanitarian"])]
    ToiletPortable = 0xE583,

    /// <summary>
    /// The Font Awesome "toilets-portable" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["toilets portable", "outhouse", "toilet"])]
    [FontAwesomeCategories(["Buildings", "Construction", "Humanitarian"])]
    ToiletsPortable = 0xE584,

    /// <summary>
    /// The Font Awesome "toolbox" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["admin", "chest", "configuration", "container", "equipment", "fix", "maintenance", "mechanic", "modify", "repair", "settings", "tool", "toolbox", "tools"])]
    [FontAwesomeCategories(["Construction"])]
    Toolbox = 0xF552,

    /// <summary>
    /// The Font Awesome "screwdriver-wrench" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["screwdriver wrench", "admin", "configuration", "equipment", "fix", "maintenance", "modify", "repair", "screwdriver", "settings", "tools", "wrench"])]
    [FontAwesomeCategories(["Construction"])]
    Tools = 0xF7D9,

    /// <summary>
    /// The Font Awesome "tooth" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bicuspid", "dental", "dentist", "molar", "mouth", "teeth", "tooth"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Tooth = 0xF5C9,

    /// <summary>
    /// The Font Awesome "scroll-torah" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["scroll torah", "book", "jewish", "judaism", "religion", "scroll"])]
    [FontAwesomeCategories(["Religion"])]
    Torah = 0xF6A0,

    /// <summary>
    /// The Font Awesome "torii-gate" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["torii gate", "building", "religion", "shinto", "shinto shrine", "shintoism", "shrine"])]
    [FontAwesomeCategories(["Buildings", "Religion"])]
    ToriiGate = 0xF6A1,

    /// <summary>
    /// The Font Awesome "tornado" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cloud", "cyclone", "dorothy", "landspout", "tornado", "toto", "twister", "vortext", "waterspout", "weather", "whirlwind"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Weather"])]
    Tornado = 0xF76F,

    /// <summary>
    /// The Font Awesome "tower-cell" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tower cell", "airwaves", "antenna", "communication", "radio", "reception", "signal", "waves"])]
    [FontAwesomeCategories(["Communication", "Connectivity", "Film + Video", "Humanitarian"])]
    TowerCell = 0xE585,

    /// <summary>
    /// The Font Awesome "tower-observation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tower observation", "fire tower", "view"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Security"])]
    TowerObservation = 0xE586,

    /// <summary>
    /// The Font Awesome "tractor" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["agriculture", "farm", "tractor", "vehicle"])]
    [FontAwesomeCategories(["Transportation"])]
    Tractor = 0xF722,

    /// <summary>
    /// The Font Awesome "trademark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["copyright", "mark", "register", "symbol", "tm", "trade mark", "trademark"])]
    [FontAwesomeCategories(["Business"])]
    Trademark = 0xF25C,

    /// <summary>
    /// The Font Awesome "traffic-light" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["traffic light", "direction", "go", "light", "road", "signal", "slow", "stop", "traffic", "travel", "vertical traffic light"])]
    [FontAwesomeCategories(["Maps"])]
    TrafficLight = 0xF637,

    /// <summary>
    /// The Font Awesome "train" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bullet", "commute", "locomotive", "railway", "subway", "train"])]
    [FontAwesomeCategories(["Logistics", "Maps", "Transportation"])]
    Train = 0xF238,

    /// <summary>
    /// The Font Awesome "train-tram" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["train tram", "crossing", "machine", "mountains", "seasonal", "tram", "transportation", "trolleybus"])]
    [FontAwesomeCategories(["Maps", "Transportation", "Travel + Hotel"])]
    TrainTram = 0xE5B4,

    /// <summary>
    /// The Font Awesome "cable-car" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cable car", "aerial tramway", "cable", "gondola", "lift", "mountain", "mountain cableway", "tram", "tramway", "trolley"])]
    [FontAwesomeCategories(["Transportation", "Travel + Hotel"])]
    Tram = 0xF7DA,

    /// <summary>
    /// The Font Awesome "mars-and-venus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["mars and venus", "male and female sign", "female", "gender", "intersex", "male", "transgender"])]
    [FontAwesomeCategories(["Genders", "Humanitarian"])]
    Transgender = 0xF224,

    /// <summary>
    /// The Font Awesome "transgender" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["female", "gender", "intersex", "male", "transgender", "transgender symbol"])]
    [FontAwesomeCategories(["Genders"])]
    TransgenderAlt = 0xF225,

    /// <summary>
    /// The Font Awesome "trash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["trash", "delete", "garbage", "hide", "remove"])]
    [FontAwesomeCategories(["Editing"])]
    Trash = 0xF1F8,

    /// <summary>
    /// The Font Awesome "trash-can" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["trash can", "delete", "garbage", "hide", "remove", "trash-o"])]
    [FontAwesomeCategories(["Editing", "Humanitarian"])]
    TrashAlt = 0xF2ED,

    /// <summary>
    /// The Font Awesome "trash-arrow-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["trash arrow up", "back", "control z", "delete", "garbage", "hide", "oops", "remove", "undo", "upgrade"])]
    [FontAwesomeCategories(["Editing"])]
    TrashRestore = 0xF829,

    /// <summary>
    /// The Font Awesome "trash-can-arrow-up" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["trash can arrow up", "back", "control z", "delete", "garbage", "hide", "oops", "remove", "undo", "upgrade"])]
    [FontAwesomeCategories(["Editing"])]
    TrashRestoreAlt = 0xF82A,

    /// <summary>
    /// The Font Awesome "tree" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["bark", "evergreen tree", "fall", "flora", "forest", "investment", "nature", "plant", "seasonal", "tree"])]
    [FontAwesomeCategories(["Camping", "Maps", "Nature"])]
    Tree = 0xF1BB,

    /// <summary>
    /// The Font Awesome "tree-city" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tree city", "building", "city", "urban"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Travel + Hotel"])]
    TreeCity = 0xE587,

    /// <summary>
    /// The Font Awesome "trophy" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["achievement", "award", "cup", "game", "prize", "trophy", "winner"])]
    [FontAwesomeCategories(["Maps", "Shopping"])]
    Trophy = 0xF091,

    /// <summary>
    /// The Font Awesome "trowel" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["trowel", "build", "construction", "equipment", "maintenance", "tool"])]
    [FontAwesomeCategories(["Construction", "Humanitarian"])]
    Trowel = 0xE589,

    /// <summary>
    /// The Font Awesome "trowel-bricks" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["trowel bricks", "build", "construction", "maintenance", "reconstruction", "tool"])]
    [FontAwesomeCategories(["Construction", "Humanitarian"])]
    TrowelBricks = 0xE58A,

    /// <summary>
    /// The Font Awesome "truck" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["black truck", "cargo", "delivery", "delivery truck", "shipping", "truck", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Logistics", "Maps", "Shopping", "Transportation"])]
    Truck = 0xF0D1,

    /// <summary>
    /// The Font Awesome "truck-arrow-right" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck arrow right", "access", "fast", "shipping", "transport"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Transportation"])]
    TruckArrowRight = 0xE58B,

    /// <summary>
    /// The Font Awesome "truck-droplet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck droplet", "blood", "thirst", "truck", "water", "water supply"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health", "Transportation"])]
    TruckDroplet = 0xE58C,

    /// <summary>
    /// The Font Awesome "truck-field" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck field", "supplies", "truck"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Logistics", "Transportation"])]
    TruckField = 0xE58D,

    /// <summary>
    /// The Font Awesome "truck-field-un" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck field un", "supplies", "truck", "united nations"])]
    [FontAwesomeCategories(["Automotive", "Humanitarian", "Logistics", "Transportation"])]
    TruckFieldUn = 0xE58E,

    /// <summary>
    /// The Font Awesome "truck-front" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck front", "shuttle", "truck", "van"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Transportation"])]
    TruckFront = 0xE2B7,

    /// <summary>
    /// The Font Awesome "truck-ramp-box" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck ramp box", "box", "cargo", "delivery", "inventory", "moving", "rental", "vehicle"])]
    [FontAwesomeCategories(["Moving"])]
    TruckLoading = 0xF4DE,

    /// <summary>
    /// The Font Awesome "truck-monster" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck monster", "offroad", "vehicle", "wheel"])]
    [FontAwesomeCategories(["Automotive", "Transportation"])]
    TruckMonster = 0xF63B,

    /// <summary>
    /// The Font Awesome "truck-moving" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck moving", "cargo", "inventory", "rental", "vehicle"])]
    [FontAwesomeCategories(["Moving"])]
    TruckMoving = 0xF4DF,

    /// <summary>
    /// The Font Awesome "truck-pickup" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck pickup", "cargo", "maintenance", "pick-up", "pickup", "pickup truck", "truck", "vehicle"])]
    [FontAwesomeCategories(["Automotive", "Construction", "Transportation"])]
    TruckPickup = 0xF63C,

    /// <summary>
    /// The Font Awesome "truck-plane" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["truck plane", "airplane", "plane", "transportation", "truck", "vehicle"])]
    [FontAwesomeCategories(["Humanitarian", "Logistics", "Transportation"])]
    TruckPlane = 0xE58F,

    /// <summary>
    /// The Font Awesome "shirt" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["clothing", "fashion", "garment", "shirt", "short sleeve", "t-shirt", "tshirt"])]
    [FontAwesomeCategories(["Clothing + Fashion", "Humanitarian", "Shopping"])]
    Tshirt = 0xF553,

    /// <summary>
    /// The Font Awesome "tty" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tty", "communication", "deaf", "telephone", "teletypewriter", "text"])]
    [FontAwesomeCategories(["Accessibility", "Communication", "Maps"])]
    Tty = 0xF1E4,

    /// <summary>
    /// The Font Awesome "turkish-lira-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["turkish lira sign", "turkish lira sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    TurkishLiraSign = 0xE2BB,

    /// <summary>
    /// The Font Awesome "tv" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["tv", "computer", "display", "monitor", "television"])]
    [FontAwesomeCategories(["Devices + Hardware", "Film + Video", "Household", "Travel + Hotel"])]
    Tv = 0xF26C,

    /// <summary>
    /// The Font Awesome "umbrella" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["umbrella", "protection", "rain", "storm", "wet"])]
    [FontAwesomeCategories(["Maps", "Weather"])]
    Umbrella = 0xF0E9,

    /// <summary>
    /// The Font Awesome "umbrella-beach" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["umbrella beach", "beach", "beach with umbrella", "protection", "recreation", "sand", "shade", "summer", "sun", "umbrella"])]
    [FontAwesomeCategories(["Travel + Hotel"])]
    UmbrellaBeach = 0xF5CA,

    /// <summary>
    /// The Font Awesome "underline" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["underline", "edit", "emphasis", "format", "modify", "text", "writing"])]
    [FontAwesomeCategories(["Text Formatting"])]
    Underline = 0xF0CD,

    /// <summary>
    /// The Font Awesome "arrow-rotate-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["arrow rotate left", "anticlockwise open circle arrow", "back", "control z", "exchange", "oops", "return", "rotate", "swap"])]
    [FontAwesomeCategories(["Arrows", "Media Playback", "Spinners"])]
    Undo = 0xF0E2,

    /// <summary>
    /// The Font Awesome "rotate-left" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rotate left", "back", "control z", "exchange", "oops", "return", "swap"])]
    [FontAwesomeCategories(["Arrows", "Media Playback", "Spinners"])]
    UndoAlt = 0xF2EA,

    /// <summary>
    /// The Font Awesome "universal-access" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["universal access", "uer", "users-people"])]
    [FontAwesomeCategories(["Accessibility"])]
    UniversalAccess = 0xF29A,

    /// <summary>
    /// The Font Awesome "building-columns" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["building columns", "bank", "building", "college", "education", "institution", "museum", "students"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Maps"])]
    University = 0xF19C,

    /// <summary>
    /// The Font Awesome "link-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["link slash", "attachment", "chain", "chain-broken", "disabled", "disconnect", "remove"])]
    [FontAwesomeCategories(["Editing"])]
    Unlink = 0xF127,

    /// <summary>
    /// The Font Awesome "unlock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["admin", "lock", "open", "padlock", "password", "privacy", "private", "protect", "unlock", "unlocked"])]
    [FontAwesomeCategories(["Security"])]
    Unlock = 0xF09C,

    /// <summary>
    /// The Font Awesome "unlock-keyhole" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["unlock keyhole", "admin", "lock", "padlock", "password", "privacy", "private", "protect"])]
    [FontAwesomeCategories(["Security"])]
    UnlockAlt = 0xF13E,

    /// <summary>
    /// The Font Awesome "upload" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["upload", "hard drive", "import", "publish", "upgrade"])]
    [FontAwesomeCategories(["Arrows", "Devices + Hardware"])]
    Upload = 0xF093,

    /// <summary>
    /// The Font Awesome "user" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user", "adult", "bust", "bust in silhouette", "default", "employee", "gender-neutral", "person", "profile", "silhouette", "uer", "unspecified gender", "username", "users-people"])]
    [FontAwesomeCategories(["Social", "Users + People"])]
    User = 0xF007,

    /// <summary>
    /// The Font Awesome "user" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF007.
    /// </summary>
    [FontAwesomeSearchTerms(["user", "adult", "bust", "bust in silhouette", "default", "employee", "gender-neutral", "person", "profile", "silhouette", "uer", "unspecified gender", "username", "users-people"])]
    [FontAwesomeCategories(["Social", "Users + People"])]
    UserAlt = 0xF406,

    /// <summary>
    /// The Font Awesome "user-slash" icon unicode character.
    /// Uses a legacy unicode value for backwards compatability. The current unicode value is 0xF506.
    /// </summary>
    [FontAwesomeSearchTerms(["user slash", "ban", "delete", "deny", "disabled", "disconnect", "employee", "remove", "uer"])]
    [FontAwesomeCategories(["Users + People"])]
    UserAltSlash = 0xF4FA,

    /// <summary>
    /// The Font Awesome "user-astronaut" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user astronaut", "avatar", "clothing", "cosmonaut", "nasa", "space", "suit", "uer"])]
    [FontAwesomeCategories(["Astronomy", "Science Fiction", "Users + People"])]
    UserAstronaut = 0xF4FB,

    /// <summary>
    /// The Font Awesome "user-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user check", "employee", "enable", "uer", "users-people", "validate", "working"])]
    [FontAwesomeCategories(["Users + People"])]
    UserCheck = 0xF4FC,

    /// <summary>
    /// The Font Awesome "circle-user" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["circle user", "employee", "uer", "username", "users-people"])]
    [FontAwesomeCategories(["Social", "Users + People"])]
    UserCircle = 0xF2BD,

    /// <summary>
    /// The Font Awesome "user-clock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user clock", "employee", "uer", "users-people"])]
    [FontAwesomeCategories(["Users + People"])]
    UserClock = 0xF4FD,

    /// <summary>
    /// The Font Awesome "user-gear" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user gear", "employee", "together", "uer", "users-people"])]
    [FontAwesomeCategories(["Users + People"])]
    UserCog = 0xF4FE,

    /// <summary>
    /// The Font Awesome "user-pen" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user pen", "employee", "modify", "uer", "users-people"])]
    [FontAwesomeCategories(["Users + People"])]
    UserEdit = 0xF4FF,

    /// <summary>
    /// The Font Awesome "user-group" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user group", "bust", "busts in silhouette", "crowd", "employee", "silhouette", "together", "uer", "users-people"])]
    [FontAwesomeCategories(["Social", "Users + People"])]
    UserFriends = 0xF500,

    /// <summary>
    /// The Font Awesome "user-graduate" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user graduate", "uer", "users-people"])]
    [FontAwesomeCategories(["Education", "Users + People"])]
    UserGraduate = 0xF501,

    /// <summary>
    /// The Font Awesome "user-injured" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user injured", "employee", "uer", "users-people"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    UserInjured = 0xF728,

    /// <summary>
    /// The Font Awesome "user-lock" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user lock", "employee", "padlock", "privacy", "uer", "users-people"])]
    [FontAwesomeCategories(["Security", "Users + People"])]
    UserLock = 0xF502,

    /// <summary>
    /// The Font Awesome "user-doctor" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user doctor", "covid-19", "health", "job", "medical", "nurse", "occupation", "physician", "profile", "surgeon", "uer", "worker"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health", "Users + People"])]
    UserMd = 0xF0F0,

    /// <summary>
    /// The Font Awesome "user-minus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user minus", "delete", "employee", "negative", "remove", "uer"])]
    [FontAwesomeCategories(["Users + People"])]
    UserMinus = 0xF503,

    /// <summary>
    /// The Font Awesome "user-ninja" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user ninja", "assassin", "avatar", "dangerous", "deadly", "fighter", "hidden", "ninja", "sneaky", "stealth", "uer"])]
    [FontAwesomeCategories(["Users + People"])]
    UserNinja = 0xF504,

    /// <summary>
    /// The Font Awesome "user-nurse" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user nurse", "covid-19", "doctor", "health", "md", "medical", "midwife", "physician", "practitioner", "surgeon", "uer", "worker"])]
    [FontAwesomeCategories(["Medical + Health", "Users + People"])]
    UserNurse = 0xF82F,

    /// <summary>
    /// The Font Awesome "user-plus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user plus", "add", "avatar", "employee", "follow", "positive", "sign up", "signup", "team", "user"])]
    [FontAwesomeCategories(["Social", "Users + People"])]
    UserPlus = 0xF234,

    /// <summary>
    /// The Font Awesome "users" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["users", "employee", "together", "uer", "users-people"])]
    [FontAwesomeCategories(["Social", "Users + People"])]
    Users = 0xF0C0,

    /// <summary>
    /// The Font Awesome "users-between-lines" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["users between lines", "covered", "crowd", "employee", "group", "people", "together", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    UsersBetweenLines = 0xE591,

    /// <summary>
    /// The Font Awesome "users-gear" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["users gear", "employee", "uer", "users-people"])]
    [FontAwesomeCategories(["Users + People"])]
    UsersCog = 0xF509,

    /// <summary>
    /// The Font Awesome "user-secret" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user secret", "detective", "sleuth", "spy", "uer", "users-people"])]
    [FontAwesomeCategories(["Coding", "Security", "Users + People"])]
    UserSecret = 0xF21B,

    /// <summary>
    /// The Font Awesome "user-shield" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user shield", "employee", "protect", "safety", "security", "uer"])]
    [FontAwesomeCategories(["Security", "Users + People"])]
    UserShield = 0xF505,

    /// <summary>
    /// The Font Awesome "user-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user slash", "ban", "delete", "deny", "disabled", "disconnect", "employee", "remove", "uer"])]
    [FontAwesomeCategories(["Users + People"])]
    UserSlash = 0xF506,

    /// <summary>
    /// The Font Awesome "users-line" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["users line", "crowd", "employee", "group", "need", "people", "together", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    UsersLine = 0xE592,

    /// <summary>
    /// The Font Awesome "users-rays" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["users rays", "affected", "crowd", "employee", "focused", "group", "people", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    UsersRays = 0xE593,

    /// <summary>
    /// The Font Awesome "users-rectangle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["users rectangle", "crowd", "employee", "focus", "group", "people", "reached", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    UsersRectangle = 0xE594,

    /// <summary>
    /// The Font Awesome "users-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["users slash", "disabled", "disconnect", "employee", "together", "uer", "users-people"])]
    [FontAwesomeCategories(["Users + People"])]
    UsersSlash = 0xE073,

    /// <summary>
    /// The Font Awesome "users-viewfinder" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["users viewfinder", "crowd", "focus", "group", "people", "targeted", "uer"])]
    [FontAwesomeCategories(["Humanitarian", "Users + People"])]
    UsersViewfinder = 0xE595,

    /// <summary>
    /// The Font Awesome "user-tag" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user tag", "employee", "uer", "users-people"])]
    [FontAwesomeCategories(["Users + People"])]
    UserTag = 0xF507,

    /// <summary>
    /// The Font Awesome "user-tie" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user tie", "administrator", "avatar", "business", "clothing", "employee", "formal", "offer", "portfolio", "professional", "suit", "uer"])]
    [FontAwesomeCategories(["Clothing + Fashion", "Users + People"])]
    UserTie = 0xF508,

    /// <summary>
    /// The Font Awesome "user-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["user xmark", "archive", "delete", "employee", "remove", "uer", "uncheck", "x"])]
    [FontAwesomeCategories(["Users + People"])]
    UserTimes = 0xF235,

    /// <summary>
    /// The Font Awesome "utensils" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["utensils", "cooking", "cutlery", "dining", "dinner", "eat", "food", "fork", "fork and knife", "knife", "restaurant"])]
    [FontAwesomeCategories(["Household", "Maps", "Travel + Hotel"])]
    Utensils = 0xF2E7,

    /// <summary>
    /// The Font Awesome "spoon" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["cutlery", "dining", "scoop", "silverware", "spoon", "tableware"])]
    [FontAwesomeCategories(["Household", "Maps"])]
    UtensilSpoon = 0xF2E5,

    /// <summary>
    /// The Font Awesome "vault" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vault", "bank", "important", "investment", "lock", "money", "premium", "privacy", "safe", "salary"])]
    [FontAwesomeCategories(["Business", "Money", "Security"])]
    Vault = 0xE2C5,

    /// <summary>
    /// The Font Awesome "vectorsquare" icon unicode character.
    /// </summary>
    [Obsolete]
    VectorSquare = 0xF5CB,

    /// <summary>
    /// The Font Awesome "venus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["venus", "female", "female sign", "gender", "woman"])]
    [FontAwesomeCategories(["Genders"])]
    Venus = 0xF221,

    /// <summary>
    /// The Font Awesome "venus-double" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["venus double", "doubled female sign", "female", "gender", "lesbian"])]
    [FontAwesomeCategories(["Genders"])]
    VenusDouble = 0xF226,

    /// <summary>
    /// The Font Awesome "venus-mars" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["venus mars", "interlocked female and male sign", "female", "gender", "heterosexual", "male"])]
    [FontAwesomeCategories(["Genders"])]
    VenusMars = 0xF228,

    /// <summary>
    /// The Font Awesome "vest" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vest", "biker", "fashion", "style"])]
    [FontAwesomeCategories(["Clothing + Fashion", "Maps"])]
    Vest = 0xE085,

    /// <summary>
    /// The Font Awesome "vest-patches" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vest patches", "biker", "fashion", "style"])]
    [FontAwesomeCategories(["Clothing + Fashion", "Maps"])]
    VestPatches = 0xE086,

    /// <summary>
    /// The Font Awesome "vial" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vial", "ampule", "chemist", "chemistry", "experiment", "knowledge", "lab", "sample", "science", "test", "test tube"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    Vial = 0xF492,

    /// <summary>
    /// The Font Awesome "vial-circle-check" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vial circle check", "ampule", "chemist", "chemistry", "enable", "not affected", "ok", "okay", "success", "test tube", "tube", "vaccine", "validate", "working"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health", "Science"])]
    VialCircleCheck = 0xE596,

    /// <summary>
    /// The Font Awesome "vials" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vials", "ampule", "experiment", "knowledge", "lab", "sample", "science", "test", "test tube"])]
    [FontAwesomeCategories(["Medical + Health", "Science"])]
    Vials = 0xF493,

    /// <summary>
    /// The Font Awesome "vial-virus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vial virus", "ampule", "coronavirus", "covid-19", "flue", "infection", "lab", "laboratory", "pandemic", "test", "test tube", "vaccine"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health", "Science"])]
    VialVirus = 0xE597,

    /// <summary>
    /// The Font Awesome "video" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["video", "camera", "film", "movie", "record", "video-camera"])]
    [FontAwesomeCategories(["Communication", "Film + Video", "Social"])]
    Video = 0xF03D,

    /// <summary>
    /// The Font Awesome "video-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["video slash", "add", "create", "disabled", "disconnect", "film", "new", "positive", "record", "video"])]
    [FontAwesomeCategories(["Communication", "Film + Video"])]
    VideoSlash = 0xF4E2,

    /// <summary>
    /// The Font Awesome "vihara" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vihara", "buddhism", "buddhist", "building", "monastery"])]
    [FontAwesomeCategories(["Buildings", "Humanitarian", "Religion"])]
    Vihara = 0xF6A7,

    /// <summary>
    /// The Font Awesome "virus" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["virus", "bug", "coronavirus", "covid-19", "flu", "health", "infection", "pandemic", "sick", "vaccine", "viral"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    Virus = 0xE074,

    /// <summary>
    /// The Font Awesome "virus-covid" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["virus covid", "bug", "covid-19", "flu", "health", "infection", "pandemic", "vaccine", "viral", "virus"])]
    [FontAwesomeCategories(["Humanitarian", "Medical + Health"])]
    VirusCovid = 0xE4A8,

    /// <summary>
    /// The Font Awesome "virus-covid-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["virus covid slash", "bug", "covid-19", "disabled", "flu", "health", "infection", "pandemic", "vaccine", "viral", "virus"])]
    [FontAwesomeCategories(["Medical + Health"])]
    VirusCovidSlash = 0xE4A9,

    /// <summary>
    /// The Font Awesome "viruses" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["viruses", "bugs", "coronavirus", "covid-19", "flu", "health", "infection", "multiply", "pandemic", "sick", "spread", "vaccine", "viral"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Viruses = 0xE076,

    /// <summary>
    /// The Font Awesome "virus-slash" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["virus slash", "bug", "coronavirus", "covid-19", "cure", "disabled", "eliminate", "flu", "health", "infection", "pandemic", "sick", "vaccine", "viral"])]
    [FontAwesomeCategories(["Medical + Health"])]
    VirusSlash = 0xE075,

    /// <summary>
    /// The Font Awesome "voicemail" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["voicemail", "answer", "inbox", "message", "phone"])]
    [FontAwesomeCategories(["Communication"])]
    Voicemail = 0xF897,

    /// <summary>
    /// The Font Awesome "volcano" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["caldera", "eruption", "lava", "magma", "mountain", "smoke", "volcano"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Nature", "Weather"])]
    Volcano = 0xF770,

    /// <summary>
    /// The Font Awesome "volleyball" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["ball", "beach", "game", "olympics", "sport", "volleyball"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    VolleyballBall = 0xF45F,

    /// <summary>
    /// The Font Awesome "volume-low" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["volume low", "audio", "lower", "music", "quieter", "soft", "sound", "speaker", "speaker low volume"])]
    [FontAwesomeCategories(["Media Playback", "Music + Audio"])]
    VolumeDown = 0xF027,

    /// <summary>
    /// The Font Awesome "volume-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["volume xmark", "audio", "music", "quiet", "sound", "speaker"])]
    [FontAwesomeCategories(["Media Playback", "Music + Audio"])]
    VolumeMute = 0xF6A9,

    /// <summary>
    /// The Font Awesome "volume-off" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["volume off", "audio", "ban", "music", "mute", "quiet", "silent", "sound"])]
    [FontAwesomeCategories(["Media Playback", "Music + Audio"])]
    VolumeOff = 0xF026,

    /// <summary>
    /// The Font Awesome "volume-high" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["volume high", "audio", "higher", "loud", "louder", "music", "sound", "speaker", "speaker high volume"])]
    [FontAwesomeCategories(["Media Playback", "Music + Audio"])]
    VolumeUp = 0xF028,

    /// <summary>
    /// The Font Awesome "check-to-slot" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["check to slot", "accept", "cast", "election", "enable", "politics", "positive", "validate", "voting", "working", "yes"])]
    [FontAwesomeCategories(["Political"])]
    VoteYea = 0xF772,

    /// <summary>
    /// The Font Awesome "vr-cardboard" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["vr cardboard", "3d", "augment", "google", "reality", "virtual"])]
    [FontAwesomeCategories(["Gaming"])]
    VrCardboard = 0xF729,

    /// <summary>
    /// The Font Awesome "walkie-talkie" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["walkie talkie", "communication", "copy", "intercom", "over", "portable", "radio", "two way radio"])]
    [FontAwesomeCategories(["Communication", "Devices + Hardware", "Humanitarian"])]
    WalkieTalkie = 0xF8EF,

    /// <summary>
    /// The Font Awesome "person-walking" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["person walking", "crosswalk", "exercise", "follow", "hike", "move", "person walking", "uer", "walk", "walking", "workout"])]
    [FontAwesomeCategories(["Humanitarian", "Sports + Fitness", "Users + People"])]
    Walking = 0xF554,

    /// <summary>
    /// The Font Awesome "wallet" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wallet", "billfold", "cash", "currency", "money", "salary"])]
    [FontAwesomeCategories(["Business", "Money"])]
    Wallet = 0xF555,

    /// <summary>
    /// The Font Awesome "wand-magic-sparkles" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wand magic sparkles", "auto", "magic", "magic wand", "trick", "witch", "wizard"])]
    [FontAwesomeCategories(["Design", "Editing"])]
    WandMagicSparkles = 0xE2CA,

    /// <summary>
    /// The Font Awesome "wand-sparkles" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wand sparkles", "autocomplete", "automatic", "fantasy", "halloween", "holiday", "magic", "weapon", "witch", "wizard"])]
    [FontAwesomeCategories(["Gaming", "Halloween"])]
    WandSparkles = 0xF72B,

    /// <summary>
    /// The Font Awesome "warehouse" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["warehouse", "building", "capacity", "garage", "inventory", "storage"])]
    [FontAwesomeCategories(["Buildings", "Logistics"])]
    Warehouse = 0xF494,

    /// <summary>
    /// The Font Awesome "water" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["water", "lake", "liquid", "ocean", "sea", "swim", "wet"])]
    [FontAwesomeCategories(["Energy", "Maritime", "Nature", "Weather"])]
    Water = 0xF773,

    /// <summary>
    /// The Font Awesome "wave-square" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wave square", "frequency", "pulse", "signal"])]
    [FontAwesomeCategories(["Mathematics", "Music + Audio"])]
    WaveSquare = 0xF83E,

    /// <summary>
    /// The Font Awesome "web-awesome" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["web awesome", "awesome", "coding", "components", "crown", "web"])]
    [FontAwesomeCategories(["Coding", "Design"])]
    WebAwesome = 0xE682,

    /// <summary>
    /// The Font Awesome "weight-scale" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["weight scale", "health", "measurement", "scale", "weight"])]
    [FontAwesomeCategories(["Medical + Health"])]
    Weight = 0xF496,

    /// <summary>
    /// The Font Awesome "weight-hanging" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["weight hanging", "anvil", "heavy", "measurement"])]
    [FontAwesomeCategories(["Sports + Fitness"])]
    WeightHanging = 0xF5CD,

    /// <summary>
    /// The Font Awesome "wheat-awn" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wheat awn", "agriculture", "autumn", "fall", "farming", "grain"])]
    [FontAwesomeCategories(["Food + Beverage", "Humanitarian"])]
    WheatAwn = 0xE2CD,

    /// <summary>
    /// The Font Awesome "wheat-awn-circle-exclamation" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wheat awn circle exclamation", "affected", "failed", "famine", "food", "gluten", "hunger", "starve", "straw"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Food + Beverage", "Humanitarian"])]
    WheatAwnCircleExclamation = 0xE598,

    /// <summary>
    /// The Font Awesome "wheelchair" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wheelchair", "disabled", "uer", "users-people"])]
    [FontAwesomeCategories(["Accessibility", "Maps", "Medical + Health", "Transportation", "Travel + Hotel", "Users + People"])]
    Wheelchair = 0xF193,

    /// <summary>
    /// The Font Awesome "wheelchair-move" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wheelchair move", "access", "disabled", "handicap", "impairment", "physical", "uer", "wheelchair symbol"])]
    [FontAwesomeCategories(["Accessibility", "Humanitarian", "Maps", "Medical + Health", "Transportation", "Travel + Hotel", "Users + People"])]
    WheelchairMove = 0xE2CE,

    /// <summary>
    /// The Font Awesome "wifi" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wifi", "connection", "hotspot", "internet", "network", "signal", "wireless", "www"])]
    [FontAwesomeCategories(["Connectivity", "Humanitarian", "Maps", "Toggle", "Travel + Hotel"])]
    Wifi = 0xF1EB,

    /// <summary>
    /// The Font Awesome "wind" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wind", "air", "blow", "breeze", "fall", "seasonal", "weather"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Energy", "Humanitarian", "Nature", "Weather"])]
    Wind = 0xF72E,

    /// <summary>
    /// The Font Awesome "rectangle-xmark" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["rectangle xmark", "browser", "cancel", "computer", "development", "uncheck"])]
    [FontAwesomeCategories(["Coding"])]
    WindowClose = 0xF410,

    /// <summary>
    /// The Font Awesome "window-maximize" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["window maximize", "maximize", "browser", "computer", "development", "expand"])]
    [FontAwesomeCategories(["Coding"])]
    WindowMaximize = 0xF2D0,

    /// <summary>
    /// The Font Awesome "window-minimize" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["window minimize", "minimize", "browser", "collapse", "computer", "development"])]
    [FontAwesomeCategories(["Coding"])]
    WindowMinimize = 0xF2D1,

    /// <summary>
    /// The Font Awesome "window-restore" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["window restore", "browser", "computer", "development"])]
    [FontAwesomeCategories(["Coding"])]
    WindowRestore = 0xF2D2,

    /// <summary>
    /// The Font Awesome "wine-bottle" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wine bottle", "alcohol", "beverage", "cabernet", "drink", "glass", "grapes", "merlot", "sauvignon"])]
    [FontAwesomeCategories(["Food + Beverage"])]
    WineBottle = 0xF72F,

    /// <summary>
    /// The Font Awesome "wine-glass" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wine glass", "alcohol", "bar", "beverage", "cabernet", "drink", "glass", "grapes", "merlot", "sauvignon", "wine", "wine glass"])]
    [FontAwesomeCategories(["Food + Beverage", "Maps", "Moving", "Travel + Hotel"])]
    WineGlass = 0xF4E3,

    /// <summary>
    /// The Font Awesome "wine-glass-empty" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["wine glass empty", "alcohol", "beverage", "cabernet", "drink", "grapes", "merlot", "sauvignon"])]
    [FontAwesomeCategories(["Food + Beverage", "Travel + Hotel"])]
    WineGlassAlt = 0xF5CE,

    /// <summary>
    /// The Font Awesome "won-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["won sign", "won sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    WonSign = 0xF159,

    /// <summary>
    /// The Font Awesome "worm" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["dirt", "garden", "worm", "wriggle"])]
    [FontAwesomeCategories(["Animals", "Disaster + Crisis", "Humanitarian", "Nature"])]
    Worm = 0xE599,

    /// <summary>
    /// The Font Awesome "wrench" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["configuration", "construction", "equipment", "fix", "mechanic", "modify", "plumbing", "settings", "spanner", "tool", "update", "wrench"])]
    [FontAwesomeCategories(["Construction", "Maps"])]
    Wrench = 0xF0AD,

    /// <summary>
    /// The Font Awesome "xmarks-lines" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["xmarks lines", "barricade", "barrier", "fence", "poison", "roadblock"])]
    [FontAwesomeCategories(["Disaster + Crisis", "Humanitarian", "Logistics"])]
    XmarksLines = 0xE59A,

    /// <summary>
    /// The Font Awesome "x-ray" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["x ray", "health", "medical", "radiological images", "radiology", "skeleton"])]
    [FontAwesomeCategories(["Medical + Health"])]
    XRay = 0xF497,

    /// <summary>
    /// The Font Awesome "yen-sign" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["yen sign", "yen sign", "currency"])]
    [FontAwesomeCategories(["Money"])]
    YenSign = 0xF157,

    /// <summary>
    /// The Font Awesome "yin-yang" icon unicode character.
    /// </summary>
    [FontAwesomeSearchTerms(["yin yang", "daoism", "opposites", "religion", "tao", "taoism", "taoist", "yang", "yin", "yin yang"])]
    [FontAwesomeCategories(["Religion", "Spinners"])]
    YinYang = 0xF6AD,

}
