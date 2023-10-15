package com.example.myapp.presentation.onboarding

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import androidx.preference.PreferenceManager
import androidx.viewpager2.widget.ViewPager2
import com.example.myapp.R
import com.example.myapp.databinding.FragmentOnboardingBinding

class OnboardingFragment : Fragment() {
    private lateinit var binding: FragmentOnboardingBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        binding = FragmentOnboardingBinding.inflate(inflater, container, false)
        val fragmentList = arrayListOf(
            OnboardingFirstPageFragment(),
            OnboardingSecondPageFragment(),
            OnboardingThirdPageFragment()
        )

        binding.viewPager.adapter = OnboardingAdapter(fragmentList,
            requireActivity().supportFragmentManager, lifecycle)

        binding.dotsIndicator.setViewPager2(viewPager2 = binding.viewPager)

        setupViewPagerListener()
        setupButtonListeners()

        return binding.root
    }

    private fun setupViewPagerListener() {
        binding.viewPager.registerOnPageChangeCallback(object: ViewPager2.OnPageChangeCallback() {
            override fun onPageSelected(position: Int) {
                super.onPageSelected(position)
                if (position == 2) {
                    binding.buttonsGroup.visibility = View.GONE
                    binding.exploreButton.visibility = View.VISIBLE
                } else {
                    binding.exploreButton.visibility = View.GONE
                    binding.buttonsGroup.visibility = View.VISIBLE
                }
            }
        })
    }

    private fun setupButtonListeners() {
        binding.nextButton.setOnClickListener {
            binding.viewPager.currentItem++
        }

        binding.exploreButton.setOnClickListener { completeOnboarding() }
        binding.skipTextview.setOnClickListener{ completeOnboarding() }
    }

    private fun completeOnboarding() {
        context?.let { ctx ->
            PreferenceManager.getDefaultSharedPreferences(ctx).edit().apply {
                putBoolean(ONBOARDING_COMPLETED_PREF_NAME, true)
                apply()
            }
        }

        findNavController().navigate(R.id.action_onboardingFragment_to_homeFragment)
    }

    companion object {
        const val ONBOARDING_COMPLETED_PREF_NAME: String = "ONBOARDING_COMPLETED"
    }
}