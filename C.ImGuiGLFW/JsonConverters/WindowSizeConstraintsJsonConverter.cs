using System.Text.Json;
using System.Text.Json.Serialization;

namespace C.ImGuiGLFW.JsonConverters;

internal class WindowSizeConstraintsJsonConverter : JsonConverter<WindowSizeConstraints?>
{
    public override WindowSizeConstraints? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected start of object");
        }

        Vector2? minSize = null;
        Vector2? maxSize = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString()!;
                reader.Read();

                switch (propertyName.ToLower())
                {
                    case "minsize":
                        minSize = ReadVector2UsingConverter(ref reader, options);
                        break;
                    case "maxsize":
                        maxSize = ReadVector2UsingConverter(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        if (!minSize.HasValue)
            minSize = new Vector2(0);
        if (!maxSize.HasValue)
            maxSize = new Vector2(WindowSizeConstraints.MaxLimitInt);

        return new WindowSizeConstraints(minSize.Value, maxSize.Value);
    }

    public override void Write(Utf8JsonWriter writer, WindowSizeConstraints? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartObject();
        writer.WritePropertyName("minSize");
        WriteVector2UsingConverter(writer, value.Value.MinSize, options);
        writer.WritePropertyName("maxSize");
        WriteVector2UsingConverter(writer, value.Value.MaxSize, options);
        writer.WriteEndObject();
    }

    private static Vector2 ReadVector2UsingConverter(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (options.GetConverter(typeof(Vector2)) is JsonConverter<Vector2> converter)
        {
            return converter.Read(ref reader, typeof(Vector2), options);
        }
        return ReadVector2Fallback(ref reader);
    }

    private static void WriteVector2UsingConverter(Utf8JsonWriter writer, Vector2 vector, JsonSerializerOptions options)
    {
        if (options.GetConverter(typeof(Vector2)) is JsonConverter<Vector2> converter)
        {
            converter.Write(writer, vector, options);
        }
        else
        {
            WriteVector2Fallback(writer, vector);
        }
    }

    private static Vector2 ReadVector2Fallback(ref Utf8JsonReader reader)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected start of Vector2 object");
        }

        float x = 0;
        float y = 0;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString()!;
                reader.Read();

                switch (propertyName.ToLower())
                {
                    case "x":
                        if (reader.TokenType == JsonTokenType.Number)
                        {
                            x = reader.GetSingle();
                        }
                        break;
                    case "y":
                        if (reader.TokenType == JsonTokenType.Number)
                        {
                            y = reader.GetSingle();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        return new Vector2(x, y);
    }

    private static void WriteVector2Fallback(Utf8JsonWriter writer, Vector2 vector)
    {
        writer.WriteStartObject();
        writer.WriteNumber("x", vector.X);
        writer.WriteNumber("y", vector.Y);
        writer.WriteEndObject();
    }
}
