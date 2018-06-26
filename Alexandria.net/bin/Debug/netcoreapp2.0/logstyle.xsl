<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">

<html> 
<body>
<div style="margin:50px">
  <h2 style="text-align:center">Wallet Functions</h2>

    <xsl:for-each select="doc/members/member">

    <xsl:choose>
    <xsl:when test="para !=''">

        <h3 style="background:gray; color:white; text-align:center"><b><xsl:value-of select="para"/></b></h3>

    </xsl:when>
    <xsl:otherwise>
        
<h4 style="color:teal"><xsl:value-of select="@name"/></h4>


  
<div>
<p><xsl:value-of select="summary"/></p>

<p><xsl:value-of select="param"/></p>

<p><xsl:value-of select="returns"/></p>

  </div>  </xsl:otherwise>
</xsl:choose>


    </xsl:for-each>

 </div>
</body>
</html>
</xsl:template>
</xsl:stylesheet>


