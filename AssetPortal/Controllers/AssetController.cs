using AssetPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetPortal.Controllers;

public class AssetsController : Controller
{
    private static readonly List<Asset> Assets =
    [
        new Asset
        {
            Id = 1,
            AssetTag = "LT-001",
            AssetName = "Security Analyst Laptop",
            Owner = "Tyler",
            PurchaseDate = new DateTime(2024, 1, 15)
        },
        new Asset
        {
            Id = 2,
            AssetTag = "FW-001",
            AssetName = "Palo Alto Firewall",
            Owner = "Infrastructure",
            PurchaseDate = new DateTime(2023, 8, 1)
        },
        new Asset
        {
            Id = 3,
            AssetTag = "SVR-001",
            AssetName = "SQL Server",
            Owner = "Applications",
            PurchaseDate = new DateTime(2022, 5, 20)
        }
    ];
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Edit(int id)
    {
        Asset? asset = Assets.FirstOrDefault(a => a.Id == id);

        if (asset is null)
        {
            return NotFound();
        }

        return View(asset);
    }

    [HttpPost]
    public IActionResult Edit(Asset updatedAsset)
    {
        if (!ModelState.IsValid)
        {
            return View(updatedAsset);
        }

        Asset? existingAsset =
            Assets.FirstOrDefault(a => a.Id == updatedAsset.Id);

        if (existingAsset is null)
        {
            return NotFound();
        }

        existingAsset.AssetTag = updatedAsset.AssetTag;
        existingAsset.AssetName = updatedAsset.AssetName;
        existingAsset.Owner = updatedAsset.Owner;
        existingAsset.PurchaseDate = updatedAsset.PurchaseDate;

        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult Create(Asset asset)
    {
        if (!ModelState.IsValid)
        {
            return View(asset);
        }

        asset.Id = Assets.Max(a => a.Id) + 1;

        Assets.Add(asset);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Index()
    {
        return View(Assets);
    }

    public IActionResult Details(int id)
    {
        Asset? asset = Assets.FirstOrDefault(a => a.Id == id);

        if (asset is null)
        {
            return NotFound();
        }

        return View(asset);
    }
}