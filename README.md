<h1>ASP.NET Core application with Domain Driven Design</h1>
<p>An application I wrote as an assignment that felt wasted, so I published it here.</p>
<p>I tried building an .NET application using ASP.NET, EntityFramework and Domain Driven Design. For DDD I mostly used Microsoft's documentation.</p>
<h2>Layers</h2>
<ul>
	<li>
		<span>Web layer</span>	
		<ul>
			<li>ASP.NET Core</li>
			<li>HTTP requests, dependancy injection, views, models, controllers</li>
		</ul>
	</li>
	<li>
		<span>API layer</span>
		<ul>
			<li>This is layer just has services. According to documentation this layer usually contains an API, but it felt like overengineering in this application's context, so I just used services.</li>
		</ul>
	</li>
	<li>
		<span>Domain layer</span>
		<ul>
			<li>Houses Domain Entities that are used throughout this API and Infrastructure layers.</li>
			<li>Made with EntityFramework.</li>
			<li>They accordingly contain business logic and are not dependant on any other class.</li>
			<li>Also this layer contains all "data contracts" (interfaces)</li>
			<li>In the aggregate context the Aggregate Root is PartyDomainEntity. PersonPartyGoerDomainEntity and FirmPartyGoerDomainEntity are Value Objects</li>
		</ul>
	</li>
	<li>
		<span>Infrastructure layer</span>
		<ul>
			<li>This layer contains repositories and the database context all in the name of persistance.</li>
		</ul>
	</li>
	<li>
		<span>Database</span>
		<ul>
			<li>Uses SQLite3</li>
			<li>Houses parties, firm_party_goers and person_party_goers tables.</li>
		</ul>
	</li>
</ul>
