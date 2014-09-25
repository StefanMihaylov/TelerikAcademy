<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />
  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
</xsl:text>
    <html>
      <body>
        <h2>Catalog</h2>
        <table border="1">
          <tr bgcolor="#CCCCCC">
            <th align="left">Artist Name</th>
            <th align="left">Album Name</th>
            <th align="left">Year</th>
            <th align="left">Price</th>
            <th align="left">Producer</th>
          </tr>
          <xsl:for-each select="catalog/album">
            <tr>
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="Name" />
              </td>
              <td>
                <xsl:value-of select="year"/>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
              <td>
                <xsl:value-of select="producer"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
