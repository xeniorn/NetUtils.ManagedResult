![Status](https://github.com/xeniorn/NetUtils.ManagedResult/actions/workflows/dotnet.yml/badge.svg?branch=develop)

Utility classes for returning result objects encapsulating success, result, and issues.


### Examples
```
public ManagedResult<List<int>> GetCounts(MyProvider provider){

	try{
		List<int> res = provider.FetchCounts();
		return ManagedResult<List<int>>.Successful(res);
	}
	catch (Exception ex){
		return ManagedResult<List<int>>.Failed(["Could not fetch stuff", ex.ToString()]);
	}
}
```

```
public ManagedResult<List<int>> GetCounts(MyProvider provider){

	try{
		List<int> res = provider.FetchCounts();
		return ManagedResultFactory.Successful(res);
	}
	catch (Exception ex){
		return ManagedResultFactory.Failed<List<int>>(["Could not fetch stuff", ex.ToString()]);
	}
}
```

```
public Process(){

	var provider = new MyProvider();
	
	var res = GetCounts(provider);
	if (res.Fail) return;
	var items = res.Result!;
	
	DownstreamProcess(items);
	
}
```