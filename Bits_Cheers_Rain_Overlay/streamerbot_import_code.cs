using System;

public class CPHInline
{
    public bool Execute()
    {
        try
        {
            int bits = 0;

            if (!CPH.TryGetArg("bits", out bits))
            {
                CPH.LogWarn("[Bits Overlay] Missing arg: bits");
                return false;
            }

            if (bits < 1)
                bits = 1;

            if (bits > 1000)
                bits = 1000;

            string json = "{"
                + "\"type\":\"custom.bits.overlay\","
                + "\"payload\":{"
                + "\"bits\":" + bits
                + "}"
                + "}";

            CPH.WebsocketBroadcastJson(json);
            CPH.LogInfo("[Bits Overlay] Broadcast sent with bits=" + bits);

            return true;
        }
        catch (Exception ex)
        {
            CPH.LogError("[Bits Overlay] " + ex.ToString());
            return false;
        }
    }
}