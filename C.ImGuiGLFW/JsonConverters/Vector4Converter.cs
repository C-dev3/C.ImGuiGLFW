using System.Text.Json;
using System.Text.Json.Serialization;

namespace C.ImGuiGLFW.JsonConverters;

internal class Vector4Converter : JsonConverter<Vector4>
{
    public override Vector4 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            float x = 0, y = 0, z = 0, w = 0;

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
                        case "z":
                            if (reader.TokenType == JsonTokenType.Number)
                            {
                                z = reader.GetSingle();
                            }
                            break;
                        case "w":
                            if (reader.TokenType == JsonTokenType.Number)
                            {
                                w = reader.GetSingle();
                            }
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            return new Vector4(x, y, z, w);
        }

        throw new JsonException("Invalid Vector4 format");
    }

    public override void Write(Utf8JsonWriter writer, Vector4 value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteNumber("x", value.X);
        writer.WriteNumber("y", value.Y);
        writer.WriteNumber("z", value.Z);
        writer.WriteNumber("w", value.W);
        writer.WriteEndObject();
    }
}
