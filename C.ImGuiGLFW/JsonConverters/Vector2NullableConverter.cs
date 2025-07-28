using System.Text.Json;
using System.Text.Json.Serialization;

namespace C.ImGuiGLFW.JsonConverters;

internal class Vector2NullableConverter : JsonConverter<Vector2?>
{
    public override Vector2? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.StartObject)
        {
            float x = 0, y = 0;

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

        throw new JsonException("Invalid Vector2 format");
    }

    public override void Write(Utf8JsonWriter writer, Vector2? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartObject();
            writer.WriteNumber("x", value.Value.X);
            writer.WriteNumber("y", value.Value.Y);
            writer.WriteEndObject();
        }
    }
}
