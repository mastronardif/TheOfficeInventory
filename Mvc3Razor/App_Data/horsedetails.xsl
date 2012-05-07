<?xml version="1.0" encoding="ISO-8859-1"?>
<!-- Edited by XMLSpy® -->
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:sa="http://www.Sarnoff.com/IOM/GAM/Messages"
>



<xsl:template match="/">

  <html>
  <body>
  <h2>My Buddy</h2>

  <table border="1">
      <tr bgcolor="#9acd32">
        <th>horse-name</th>
        <th>email</th>
        <th>Id</th>
      </tr>

      <xsl:for-each select="/sa:gam-eyeD-message/sa:horseCredentials">
      <tr>
        <td><xsl:value-of select="sa:horse-name"/></td>
        <td><xsl:value-of select="sa:owner-email"/></td>
        <td><xsl:value-of select="sa:horse-eyeD-id"/></td>
      </tr>

      </xsl:for-each>
    </table>

  <table border="1">
      <tr bgcolor="#9acd32">
        <th>Front</th>
      </tr>

      <xsl:for-each select="/sa:gam-eyeD-message/sa:horsePhysicalDetail">
      <tr>

        <td>
<xsl:text disable-output-escaping="yes">&#60;</xsl:text>
<xsl:text>img alt="front" src="data:image/png;base64,</xsl:text>
<xsl:value-of select="sa:portraits/sa:front"/><xsl:text>"/></xsl:text>
</td>

      </tr>

      </xsl:for-each>
    </table>


  </body>
  </html>
</xsl:template>

</xsl:stylesheet>
