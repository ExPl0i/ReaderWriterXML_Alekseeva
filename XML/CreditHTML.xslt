<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns="http://www.credit.darom/credits"
				xmlns:t="http://www.credit.darom/credits"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt"
				exclude-result-prefixes="msxsl">

	<xsl:output method="html" indent="yes"/>

	<xsl:template match="кредиты">
		<html>
			<head>
				<style type="text/css">
					body {background-color: rgb{47, 79, 79};}
					h1, h2 {text-align: center;}
					table {bprder: thin solid rgb{255, 255, 255};}
					thead {
						font-weight: bold;
						text-align: center;}
					td {
						padding: 5 px;
						border: thin solid white; }
					ul {font-weight: bold;}
					ol {font-style: italic;}
				</style>
				<title>Список заемщиков</title>
			</head>
			<body>
				<h1>Данные о кредитах</h1>

				<h2>Заемщики</h2>
				<!--Размещение данных в многоуровневом списке-->
				<ul>
					<xsl:for-each select="t:кредит">
						<li>
							<xsl:for-each select="t:кредит/t:получатель">
								<li>
									<xsl:value-of select="t:фио"/>
									<xsl:text>(</xsl:text>
									<xsl:value-of select="t:пасп_данные"/>
									<xsl:text>)</xsl:text>
								</li>
							</xsl:for-each>
							<ol>
								<xsl:text>Сумма</xsl:text>
								<xsl:value-of select="t:кредит/t:сумма"/>
								<xsl:text>Срок</xsl:text>
								<xsl:value-of select="t:кредит/t:срок"/>
							</ol>
						</li>
					</xsl:for-each>
				</ul>
				<h2>Кредиты</h2>
				<!--Размещение даных в таблице-->
				<table>
					<thead>
						<tr>
							<td rowspan="2">Код</td>
							<td rowspan="2">Сумма</td>
							<td rowspan="2">Процентная ставка</td>
							<td rowspan="2">Срок</td>
							<td colspan="2">Получатель</td>
						</tr>
						<tr>
							<td>ФИО</td>
							<td>Паспортные данные</td>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="//t:кредит">
							<tr>
								<td>
									<xsl:value-of select="@код"/>
								</td>
								<td>
									<xsl:value-of select="t:сумма"/>
								</td>
								<td>
									<xsl:value-of select="t:сумма/@проц_ставка"/>
								</td>
								<td>
									<xsl:value-of select="t:срок"/>
								</td>
								<td>
									<xsl:value-of select="parent::t:кредит/t:получатель/t:фио"/>
								</td>
								<td>
									<xsl:value-of select="parent::t:кредит/t:получатель/t:пасп_данные"/>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>