# ASP.NET Core MVC

Target framework: ASP.NET Core 2.0

- Google authentication
- Fixed port number (44320) (o.w.v. instelling in google dashboard)

# logboek

## Model-classes

- `VragenLijst`
- `Vraag`
- `Antwoord`
- `AntwoordCommentaar`

Bij elke property v.d. Model-classes staat commentaar.

## 2018-04-18

- Controllers gescaffold
	- de ref-key naar `Antwoord` kan niet ingesteld worden in het Create-view
	- TODO: maak een nieuwe Controller/ViewModel om dit wel te doen (admin-style)

- Iedereen heeft momenteel toegang tot het (experimentele) admin-gedeelte
	- TODO: authorisation

